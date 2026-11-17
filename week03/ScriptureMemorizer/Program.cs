using System;
// Additional requirements: I added more than one scripture and the hability to select it
class Program
{
    //static void Main(string[] args)
    //{
        // Reference singleVerse = new Reference("John", 3, 16);
        // Reference verseRange = new Reference("Proverbs", 3, 5, 6);

        // Console.WriteLine(singleVerse.GetDisplayText());
        // Console.WriteLine(verseRange.GetDisplayText());

        // Word word = new Word("Trust");

        // Console.WriteLine(word.GetDisplayText());
        // word.Hide();
        // Console.WriteLine(word.GetDisplayText());
        // Console.WriteLine(word.IsHidden());

        // Reference reference = new Reference("John", 11, 35);
        // Scripture scripture = new Scripture(reference, "Jesus wept");

        // Console.WriteLine(scripture.GetDisplayText());

        // scripture.HideRandomWords(1);
        // Console.WriteLine(scripture.GetDisplayText());
        // Console.WriteLine(scripture.IsCompletelyHidden());

        // scripture.HideRandomWords(1);
        // Console.WriteLine(scripture.GetDisplayText());
        // Console.WriteLine(scripture.IsCompletelyHidden());

        //Reference reference = new Reference("Proverbs", 3, 5, 6);
        //string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        //Scripture scripture = new Scripture(reference, text);

        // while (true)
        // {
        //     Console.Clear();
        //     Console.WriteLine(scripture.GetDisplayText());

        //     if (scripture.IsCompletelyHidden())
        //     {
        //         break;
        //     }

        //     Console.WriteLine();
        //     Console.Write("Press Enter to hide more words or type 'quit': ");
        //     string? input = Console.ReadLine();

        //     if (input == null || input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
        //     {
        //         break;
        //     }

        //     if (input.Length == 0)
        //     {
        //         scripture.HideRandomWords(3);
        //     }
        // }
    //}
    static void Main(string[] args)
    {
        // Build the full path to scriptures.txt 
        string path = Path.Combine(AppContext.BaseDirectory, "scriptures.txt");

        // Declare a list variable that will hold the scripture list
        List<(Reference Reference, string Text)> passages;

        // Read the scripture file and store the scriptures for the menu
        try
        {
            passages = ScriptureLibrary.Load(path);
        }
        // Handle file errors, permission problems, or incorrectly formatted passages.
        catch (Exception error) when (error is IOException
            || error is UnauthorizedAccessException || error is FormatException)
        {
            Console.WriteLine($"Could not load scriptures.txt: {error.Message}");
            return;
        }

        // If the file contains no passages, ask to add and exit before showing the menu
        if (passages.Count == 0)
        {
            Console.WriteLine("Add at least one passage to scriptures.txt.");
            return;
        }

        // Show a numbered menu of scripture references
        Console.WriteLine("Choose a scripture to practice:");
        for (int i = 0; i < passages.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {passages[i].Reference.GetDisplayText()}");
        }

        // Selection of a scripture
        while (true)
        {
            Console.Write("Enter a number or type 'quit': ");
            
            // Read the choice
            string input = Console.ReadLine();
            
            // Exit if the input stream ends or the user types "quit"
            if (input == "quit")
            {
                return;
            }
            // Try to convert to a int
            bool isNumber = int.TryParse(input, out int choice);

            if (isNumber && choice >= 1 && choice <= passages.Count)
            {
                var passage = passages[choice - 1];
                Practice(new Scripture(passage.Reference, passage.Text));
                return;
            }

            Console.WriteLine($"Enter a number from 1 to {passages.Count}.");
        }
    }

    private static void Practice(Scripture scripture)
    {
        while (true)
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsCompletelyHidden())
            {
                return;
            }

            Console.WriteLine();
            Console.Write("Press Enter to hide more words or type 'quit': ");
            string input = Console.ReadLine();

            if (input == null || input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (input.Length == 0)
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}