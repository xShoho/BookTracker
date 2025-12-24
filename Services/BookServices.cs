namespace BookTracker.Services;

using BookTracker.Models;

public class BookService
{
    private readonly List<Book> _books;
    private int _nextId;

    public BookService()
    {
        _books = new List<Book>();
        _nextId = 1;
    }

    public void AddBook(string title, string author, Genre genre, int pageCount)
    {
        var book = new Book(_nextId++, title, author, genre, pageCount);
        _books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public List<Book> GetBooksByStatus(bool isRead)
    {
        // LINQ query
        return _books.Where(book => book.IsRead == isRead).ToList();
    }

    public List<Book> GetBooksByGenre(Genre genre)
    {
        return _books.Where(book => book.Genre == genre).ToList();
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(book => book.Id == id);
    }

    public bool MarkAsRead(int id, int? rate = null)
    {
        var book = GetBookById(id);
        if (book == null)
            return false;

        book.IsRead = true;

        if (rate.HasValue && rate >= 1 && rate <= 5)
        {
            book.Rating = rate;
        }

        return true;
    }

    public bool RemoveBook(int id)
    {
        var book = GetBookById(id);
        if (book == null)
            return false;

        _books.Remove(book);
        return true;
    }

    public (int total, int read, double averageRating) GetStatistics()
    {
        int total = _books.Count;
        int read = _books.Count(book => book.IsRead);

        var RatedBooks = _books.Where(book => book.Rating.HasValue);
        double averageRating = RatedBooks.Any()
            ? RatedBooks.Average(book => book.Rating!.Value)
            : 0;

        return (total, read, averageRating);
    }
}
