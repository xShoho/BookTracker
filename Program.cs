using BookTracker.Helpers;
using BookTracker.Models;
using BookTracker.Services;

var bookService = new BookService();
bool running = true;
string message = "Welcome To BookTracker";

while (running)
{
    // 0 - Add Book
    // 1 - View All Books
    // 2 - View Books By Status
    // 3 - View Books By Genre
    // 4 - Mark Books As Read
    // 5 - Remove Book
    // 6 - View Statistics
    // 7 - Exit
    int userMenuAction = ConsoleHelper.DisplayMainMenu(message);
    message = "Welcome To BookTracker";

    switch (userMenuAction)
    {
        case 0:
            var (title, author, pageCount, genre) = ConsoleHelper.AddNewBookMenu();
            bookService.AddBook(title, author, genre, pageCount);
            message = "Book Added";

            break;
        case 1:
            ConsoleHelper.DisplayBooks(bookService.GetAllBooks(), "All Books");

            break;
        case 2:
            // 0 - Read
            // 1 - Unread
            int userStatusSelection = ConsoleHelper.SelectReadMenu();
            bool read = userStatusSelection == 0 ? true : false;
            string readString = read ? "Read" : "Unread";

            ConsoleHelper.DisplayBooks(bookService.GetBooksByStatus(read), $"{readString} Books");

            break;
        case 3:
            Genre userGenreSelection = ConsoleHelper.SelectGenreMenu();
            ConsoleHelper.DisplayBooks(
                bookService.GetBooksByGenre(userGenreSelection),
                $"{ConsoleHelper.GetDescription(userGenreSelection)} Books"
            );

            break;
        case 4:
            int bookID = ConsoleHelper.BookMarkingOptionMenu(bookService.GetAllBooks());
            int userRateDecision = ConsoleHelper.BookRateDecisionMenu();
            int? rate = null;

            if (userRateDecision == 0)
                rate = ConsoleHelper.RateSelection();

            bookService.MarkAsRead(bookID, rate);

            break;
        case 7:
            running = false;

            break;
        default:
            message = "Not Valid Option";
            break;
    }
}
