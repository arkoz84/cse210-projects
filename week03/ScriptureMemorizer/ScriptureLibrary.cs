using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureLibrary
{
    public static List<(Reference Reference, string Text)> Load(string path)
    {
        var passages = new List<(Reference Reference, string Text)>();
        int lineNumber = 0;

        foreach (string line in File.ReadLines(path))
        {
            lineNumber++;
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] fields = line.Split('|', 5, StringSplitOptions.TrimEntries);
            if (fields.Length != 5 || fields[0].Length == 0 || fields[4].Length == 0
                || !int.TryParse(fields[1], out int chapter) || chapter < 1
                || !int.TryParse(fields[2], out int startVerse) || startVerse < 1)
            {
                throw new FormatException($"Invalid scripture on line {lineNumber}.");
            }

            Reference reference;
            if (fields[3].Length == 0)
            {
                reference = new Reference(fields[0], chapter, startVerse);
            }
            else
            {
                if (!int.TryParse(fields[3], out int endVerse) || endVerse < startVerse)
                {
                    throw new FormatException($"Invalid verse range on line {lineNumber}.");
                }

                reference = new Reference(fields[0], chapter, startVerse, endVerse);
            }

            passages.Add((reference, fields[4]));
        }

        return passages;
    }
}