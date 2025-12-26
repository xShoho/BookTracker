namespace BookTracker.Models;

using System.ComponentModel;

enum MenuOptions
{
    [Description("Add New Book")]
    AddNewBook,

    [Description("View All Books")]
    ViewAllBooks,

    [Description("View Book By Status")]
    ViewBooksByStatus,

    [Description("View Books By Genre")]
    ViewBooksByGenre,

    [Description("Mark Book As Read")]
    MarkBookAsRead,

    [Description("Remove Book")]
    RemoveBook,

    [Description("View Statistics")]
    ViewStatistics,

    [Description("Exit")]
    Exit,
}
