using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
 
        Console.WriteLine("Welcome to the Journal Program!");
        
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load entries from a file");
            Console.WriteLine("4. Save entries to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? Enter your choice (1-5): ");
            var input = Console.ReadLine();
            if (input == null)
            {
                return;
            }

            if (!int.TryParse(input, out int number) || number < 1 || number > 5)
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                continue;
            }

            if (number == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                Entry entry = new Entry
                {
                    _date = DateTime.Today,
                    _promptText = prompt,
                    _entryText = response
                };

                journal.AddEntry(entry);
            }
            else if (number == 2)
            {
                journal.DisplayAll();
            }
            else if (number == 3 || number == 4)
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(filename))
                {
                    Console.WriteLine("Please enter a filename.");
                    continue;
                }

                try
                {
                    if (number == 3)
                    {
                        journal.LoadFromFile(filename);
                    }
                    else
                    {
                        journal.SaveToFile(filename);
                    }
                }
                catch (Exception ex) when (ex is System.IO.IOException
                    || ex is UnauthorizedAccessException
                    || ex is System.Text.Json.JsonException)
                {
                    Console.WriteLine($"Could not complete the file operation: {ex.Message}");
                }
            }
            else
            {
                return;
            }
             Console.WriteLine();
        }    
    }
}