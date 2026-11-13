using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
 
    public List<Entry> _entries = new List<Entry>();

    private static readonly JsonSerializerOptions FileOptions = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public void AddEntry(Entry newEntry)
    {
         _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        string contents = JsonSerializer.Serialize(_entries, FileOptions);
        File.WriteAllText(file, contents);
    }
    public void LoadFromFile(string file)
    {
        string contents = File.ReadAllText(file);
        List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(
            contents, FileOptions
        ) ?? new List<Entry>();

        _entries = loadedEntries;
    }
    

}