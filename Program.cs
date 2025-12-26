using BookTracker.Helpers;
using BookTracker.Models;
using BookTracker.Services;

var bookService = new BookService();
bool running = true;
string message = "Welcome To BookTracker";

while (running)
{
    MenuOptions userMenuAction = ConsoleHelper.DisplayMainMenu(message);

    switch (userMenuAction)
    {
        case MenuOptions.AddNewBook:
            var (title, author, pageCount, genre) = ConsoleHelper.AddNewBookMenu();
            bookService.AddBook(title, author, genre, pageCount);

            running = false;

            break;
        case MenuOptions.ViewAllBooks:

            break;
        case MenuOptions.Exit:
            running = false;

            break;
        default:
            message = "Not Valid Option";
            break;
    }
}
