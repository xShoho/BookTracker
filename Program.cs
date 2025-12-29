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
            int userStatusSelection = ConsoleHelper.SelectReadMenu();
            bool read = userStatusSelection == 0 ? true : false;
            string readString = read ? "Read" : "Unread";

            ConsoleHelper.DisplayBooks(bookService.GetBooksByStatus(read), $"{readString} Books");

            break;
        case MenuOptions.ViewBooksByGenre:
            Genre userGenreSelection = ConsoleHelper.SelectGenreMenu();
            ConsoleHelper.DisplayBooks(
                bookService.GetBooksByGenre(userGenreSelection),
                $"{ConsoleHelper.GetDescription(userGenreSelection)} Books"
            );

            break;
        case MenuOptions.MarkBookAsRead:
            int bookID = ConsoleHelper.BookMarkingOptionMenu(bookService.GetAllBooks());
            int userRateDecision = ConsoleHelper.BookRateDecisionMenu();
            int? rate = null;

            if (userRateDecision == 0)
                rate = ConsoleHelper.RateSelection();

            bookService.MarkAsRead(bookID, rate);

            break;
        case MenuOptions.Exit:
            running = false;

            break;
        default:
            message = "Not Valid Option";
            break;
    }
}
