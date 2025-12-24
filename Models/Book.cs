namespace BookTracker.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public int PageCount { get; set; }
    public bool IsRead { get; set; }
    public int? Rating { get; set; }
    public DateTime DateAdded { get; set; }

    public Book(int id, string title, string author, Genre genre, int pageCount)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        PageCount = pageCount;
        IsRead = false;
        Rating = null;
        DateAdded = DateTime.Now;
    }

    public override string ToString()
    {
        string status = IsRead ? "Read" : "Unread";
        string ratingDisplay = Rating.HasValue ? $"{Rating}/5" : "Not rated";
        return $"[{Id}] {Title} by {Author} | {Genre} | {PageCount} pages | {status} | {ratingDisplay}";
    }
}
