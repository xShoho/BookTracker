using BookTracker.Helpers;
using BookTracker.Services;

var bookService = new BookService();
bool running = true;
string message = "Welcome To BookTracker";

// 0 - Add New Book
// 1 - View All Books
// 2 - View Books By Status
// 3 - View Books By Genre
// 4 - Mark Book As Read
// 5 - Remove Book
// 6 - View Statistics
// 7 - Exit

while (running)
{
    int userMenuAction = ConsoleHelper.DisplayMainMenu(message);

    switch (userMenuAction)
    {
        case 7:
            running = false;

            break;
        default:
            message = "Not Valid Option";
            break;
    }
}
