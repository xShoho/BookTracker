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
            Console.ResetColor();
            PrintCentered(message);

            foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
            {
                if (currentOption == option)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">  {GetDescription(option)}");
                }
                else
                {
                    Console.ResetColor();
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
                }
                else
                {
                    Console.ResetColor();
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

        return (title, author, pageCount, currentOption);
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

    private static string GetDescription(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}
