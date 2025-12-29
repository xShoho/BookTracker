namespace BookTracker.Helpers;

using System.ComponentModel;
using System.Reflection;
using BookTracker.Models;

class ConsoleHelper
{
    public static MenuOptions DisplayMainMenu(string message = "Welcome To BookTracker")
    {
        MenuOptions currentOption = MenuOptions.AddNewBook;

        bool selecting = true;

        while (selecting)
        {
            Console.Clear();
            PrintCentered(message);

            foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
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

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentOption < (MenuOptions)Enum.GetValues(typeof(MenuOptions)).Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < (MenuOptions)Enum.GetValues(typeof(MenuOptions)).Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

        return currentOption;
    }

    public static (string, string, int, Genre) AddNewBookMenu()
    {
        Console.Clear();
        Console.ResetColor();
        bool input = true;
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

        Genre genre = SelectGenreMenu();

        return (title, author, pageCount, genre);
    }

    public static Genre SelectGenreMenu()
    {
        bool selecting = true;
        Genre currentOption = Genre.Fiction;

        while (selecting)
        {
            Console.Clear();
            PrintCentered("Select Genre");

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

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentOption < (Genre)Enum.GetValues(typeof(Genre)).Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < (Genre)Enum.GetValues(typeof(Genre)).Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

        return currentOption;
    }

    public static int SelectReadMenu()
    {
        string[] options = { "Read", "Unread" };
        int currentOption = 0;
        bool selecting = true;

        while (selecting)
        {
            Console.Clear();
            PrintCentered("Choose Status");

            foreach (var (option, index) in options.Select((value, idx) => (value, idx)))
            {
                if (currentOption == index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">  {option}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"   {option}");
                }
            }

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.DownArrow:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

        return currentOption;
    }

    public static int BookMarkingOptionMenu(List<Book> books)
    {
        string[] options = { "Pick from a list", "Mark By ID" };
        int currentOption = 0;
        bool selecting = true;

        while (selecting)
        {
            Console.Clear();
            PrintCentered("Mark Book as Read");

            foreach (var (value, index) in options.Select((value, idx) => (value, idx)))
            {
                if (currentOption == index)
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

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.DownArrow:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

        // 0 - Pick from a list
        // 1 - provide id

        if (currentOption == 0)
        {
            selecting = true;
            int currentBook = 0;

            while (selecting)
            {
                Console.Clear();
                PrintCentered("Select Book");

                foreach (var (value, id) in books.Select((value, idx) => (value, idx)))
                {
                    if (currentBook == id)
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

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentBook > 0)
                            currentBook--;

                        break;
                    case ConsoleKey.DownArrow:
                        if (currentBook < books.Count - 1)
                            currentBook++;

                        break;
                    case ConsoleKey.J:
                        if (currentBook < books.Count - 1)
                            currentBook++;

                        break;
                    case ConsoleKey.K:
                        if (currentBook > 0)
                            currentBook--;

                        break;
                    case ConsoleKey.Enter:
                        selecting = false;

                        break;
                    case ConsoleKey.L:
                        selecting = false;

                        break;
                }
            }
            return currentBook + 1;
        }
        else
        {
            bool inputting = true;
            string msg = "Input ID";
            int id = 0;

            while (inputting)
            {
                Console.Clear();
                PrintCentered(msg);

                Console.Write("ID: ");
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int userInputInt))
                {
                    // Valid number
                    id = userInputInt;
                    inputting = false;
                }
                else
                {
                    msg = "Invalid input, not a number";
                }
            }

            return id;
        }
    }

    public static int BookRateDecisionMenu()
    {
        bool selecting = true;
        string[] options = { "Yes", "No" };
        int currentOption = 0;

        while (selecting)
        {
            Console.Clear();
            PrintCentered("Do you want to rate this book?");

            foreach (var (value, id) in options.Select((value, idx) => (value, idx)))
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

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.DownArrow:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

        // 0 - rate
        // 1 - don't rate

        return currentOption;
    }

    public static int RateSelection()
    {
        string[] options = { "1", "2", "3", "4", "5" };
        bool selecting = true;
        int currentOption = 0;

        while (selecting)
        {
            Console.Clear();
            PrintCentered("Choose Rating");

            foreach (var (value, id) in options.Select((value, idx) => (value, idx)))
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

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.DownArrow:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < options.Length - 1)
                        currentOption++;

                    break;
                case ConsoleKey.Enter:
                    selecting = false;

                    break;
                case ConsoleKey.L:
                    selecting = false;

                    break;
            }
        }

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
