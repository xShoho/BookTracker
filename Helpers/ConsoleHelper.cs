namespace BookTracker.Helpers;

class ConsoleHelper
{
    public static int DisplayMainMenu(string? message = "Welcome To BookTracker")
    {
        var options = new List<string>();
        options.Add("Add New Book");
        options.Add("View All Books");
        options.Add("View Books By Status");
        options.Add("View Books By Genre");
        options.Add("Mark Book As Read");
        options.Add("Remove Book");
        options.Add("View Statistics");
        options.Add("Exit");

        int currentOption = 0;

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.ResetColor();
            if (message != string.Empty)
                PrintCentered(message);

            foreach (var (option, index) in options.Select((value, idx) => (value, idx)))
            {
                if (currentOption == index)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  {option}");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine($"   {option}");
                }
            }

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentOption < options.Count - 1)
                        currentOption++;

                    break;
                case ConsoleKey.UpArrow:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.J:
                    if (currentOption < options.Count - 1)
                        currentOption++;

                    break;
                case ConsoleKey.K:
                    if (currentOption > 0)
                        currentOption--;

                    break;
                case ConsoleKey.Enter:
                    running = false;

                    break;
                case ConsoleKey.L:
                    running = false;

                    break;
            }
        }

        return currentOption;
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
}
