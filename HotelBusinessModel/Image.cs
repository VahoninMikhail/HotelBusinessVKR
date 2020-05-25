namespace HotelBusinessModel
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] FileByteArr { get; set; }

        public int FormId { get; set; }

        public virtual Form Form { get; set; }
    }
}
