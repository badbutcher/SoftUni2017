namespace _007.Models
{
    public class AlbumTag
    {
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}