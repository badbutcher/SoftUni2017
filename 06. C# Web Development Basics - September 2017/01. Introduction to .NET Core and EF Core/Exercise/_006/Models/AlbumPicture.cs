namespace _006.Models
{
    public class AlbumPicture
    {
        public int PictureId { get; set; }

        public Picture Picture { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}