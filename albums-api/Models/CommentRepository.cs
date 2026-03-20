namespace albums_api.Models
{
    public static class CommentRepository
    {
        private static readonly List<Comment> _comments = new();
        private static int _nextId = 1;

        public static IEnumerable<Comment> GetAll() => _comments;

        public static IEnumerable<Comment> GetByAlbum(int albumId) => _comments.Where(c => c.AlbumId == albumId);

        public static Comment Add(int albumId, string author, string text)
        {
            var newComment = new Comment(_nextId++, albumId, author, text, DateTime.UtcNow);
            _comments.Add(newComment);
            return newComment;
        }

        public static bool Delete(int commentId)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == commentId);
            if (comment == null) return false;
            _comments.Remove(comment);
            return true;
        }
    }
}
