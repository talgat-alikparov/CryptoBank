namespace CryptoBank.Features.News.Models;

public class NewsModel
{
    public ulong Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
}
