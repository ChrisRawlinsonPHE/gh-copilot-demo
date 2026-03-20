namespace albums_api.Models
{
    public record Comment(int Id, int AlbumId, string Author, string Text, DateTime CreatedAt);
}
