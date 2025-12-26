using BookTracker.Helpers;
using BookTracker.Models;
using BookTracker.Services;

var bookService = new BookService();
bool running = true;
string message = "Welcome To BookTracker";

while (running)
{
    MenuOptions userMenuAction = ConsoleHelper.DisplayMainMenu(message);
    message = "Welcome To BookTracker";

    switch (userMenuAction)
    {
        case MenuOptions.AddNewBook:
            var (title, author, pageCount, genre) = ConsoleHelper.AddNewBookMenu();
            bookService.AddBook(title, author, genre, pageCount);
            message = "Book Added";

            break;
        case MenuOptions.ViewAllBooks:
            ConsoleHelper.DisplayBooks(bookService.GetAllBooks(), "All Books");

            break;
        case MenuOptions.ViewBooksByStatus:
            // 0 - Read
            // 1 - Unread
            int userSelection = ConsoleHelper.SelectRead();
            bool read = userSelection == 0 ? true : false;
            string readString = read ? "Read" : "Unread";

            ConsoleHelper.DisplayBooks(bookService.GetBooksByStatus(read), $"{readString} Books");

            break;
        case MenuOptions.Exit:
            running = false;

            break;
        default:
            message = "Not Valid Option";
            break;
    }
}
