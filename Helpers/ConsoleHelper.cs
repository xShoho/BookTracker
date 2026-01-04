namespace BookTracker.Helpers;

using System.ComponentModel;
using System.Reflection;
using BookTracker.Models;

class ConsoleHelper
{
    public static int DisplayMainMenu(string message = "Welcome To BookTracker")
    {
        List<string> options = new List<string>()
        {
            "Add New Book",
            "View All Books",
            "View Books By Status",
            "View Books By Genre",
            "Mark Book as Read",
            "Remove Book",
            "View Statistics",
            "Exit",
        };
        int currentOption = 0;

        HandleSelection(ref currentOption, options, message);

        return currentOption;
    }

    public static (string, string, int, Genre) AddNewBookMenu()
    {
        bool input = true;
        Console.Clear();
        PrintCentered("Add New Book");
        string? title = string.Empty;
        string? author = string.Empty;
        int pageCount = 0;

        while (input)
        {
            Console.Write("Title: ");
            title = Console.ReadLine();

            Console.Write("Author: ");
            author = Console.ReadLine();

            Console.Write("Pages: ");
            string? pages = Console.ReadLine();

            if (int.TryParse(pages, out pageCount))
            {
                input = false;
            }
            else
            {
                Console.Clear();
                PrintCentered("Invalid input, page is not a number");
            }
        }

        Genre currentOption = Genre.Fiction;

        HandleSelection(ref currentOption, "Select Genre");

        return (title, author, pageCount, currentOption);
    }

    public static Genre SelectGenreMenu()
    {
        Genre currentOption = Genre.Fiction;

        HandleSelection(ref currentOption, "Select Genre");

        return currentOption;
    }

    public static int SelectReadMenu()
    {
        List<string> options = new List<string>();
        options.Add("Read");
        options.Add("Unread");
        int currentOption = 0;

        HandleSelection(ref currentOption, options, "Select Status");

        return currentOption;
    }

    public static int BookRateDecisionMenu()
    {
        List<string> options = new List<string>();
        options.Add("Yes");
        options.Add("No");
        int currentOption = 0;

        HandleSelection(ref currentOption, options, "Do you want to rate a book?");

        // 0 - rate
        // 1 - don't rate

        return currentOption;
    }

    public static int RateSelection()
    {
        List<string> options = new List<string>() { "1", "2", "3", "4", "5" };
        int currentOption = 0;

        HandleSelection(ref currentOption, options, "Pick a rate");

        return currentOption + 1;
    }

    public static void DisplayBooks(List<Book> books, string message)
    {
        Console.ResetColor();
        Console.Clear();
        PrintCentered(message);
        PrintCentered("Press Any Key to go back");

        foreach (Book book in books)
        {
            Console.WriteLine($"   {book}");
        }

        var key = Console.ReadKey();
        return;
    }

    public static int HandleBookPick(List<Book> books)
    {
        int currentBook = 0;
        int pickMethod = BookPickMethod();
        string msg = "Pick a book";

        if (pickMethod == 0)
        {
            HandleSelection(ref currentBook, books, msg);
            currentBook += 1;
        }
        else
        {
            bool inputting = true;

            while (inputting)
            {
                Console.Clear();
                PrintCentered(msg);
                Console.Write("> ");
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out currentBook))
                {
                    inputting = false;
                }
                else
                {
                    msg = "Invalid input, not a number";
                }
            }
        }

        return currentBook;
    }

    public static void DisplayStatistics(int total, int read, double avgRating)
    {
        Console.Clear();
        PrintCentered("Statistics");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Total books:     {total}");
        Console.WriteLine($"Read books:      {read}");
        Console.WriteLine($"Average Rating:  {avgRating}");
        Console.ResetColor();
        Console.WriteLine("\nPress Any Key to go back.");
        Console.ReadKey();
    }

    private static int BookPickMethod()
    {
        List<string> options = new List<string>() { "Pick From List", "Provide an id" };
        int currentOption = 0;

        HandleSelection(ref currentOption, options, "Pick a Method");

        return currentOption;
    }

    private static void HandleSelection<T>(ref int currentOption, List<T> collection, string msg)
    {
        bool selecting = true;

        while (selecting)
        {
            Console.Clear();
            PrintCentered(msg);

            foreach (var (value, id) in collection.Select((value, idx) => (value, idx)))
            {
                if (currentOption == id)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">  {value}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {value}");
                }
            }

            var key = Console.ReadKey();

            if ((key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.K) && currentOption > 0)
                currentOption--;
            if (
                (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.J)
                && currentOption < collection.Count - 1
            )
                currentOption++;
            if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.L)
                selecting = false;
        }
    }

    private static void HandleSelection(ref Genre currentOption, string msg)
    {
        bool selecting = true;

        while (selecting)
        {
            Console.Clear();
            PrintCentered(msg);

            foreach (Genre option in Enum.GetValues(typeof(Genre)))
            {
                if (currentOption == option)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">  {GetDescription(option)}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {GetDescription(option)}");
                }
            }

            var key = Console.ReadKey(true);

            if ((key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.K) && currentOption > 0)
                currentOption--;
            if (
                (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.J)
                && currentOption < (Genre)Enum.GetValues(typeof(Genre)).Length - 1
            )
                currentOption++;
            if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.L)
                selecting = false;
        }
    }

    private static void PrintCentered(string? text, int width = 50)
    {
        int textWithPadding = text.Length + 2;
        int remainingSpace = width - textWithPadding;

        if (remainingSpace <= 0)
        {
            Console.WriteLine($" {text} \n");
            return;
        }

        int equalsPerSide = remainingSpace / 2;
        string left = new string('=', equalsPerSide);
        string right = new string('=', remainingSpace - equalsPerSide);

        Console.WriteLine($"{left} {text} {right}\n");
    }

    public static string GetDescription(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}
