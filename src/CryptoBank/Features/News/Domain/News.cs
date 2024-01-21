namespace CryptoBank.Features.News.Domain
{
    public class News
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}
