namespace SmartPhone.Services.Database
{
    public class Asset
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Base64Image { get; set; }
        public string FileName { get; set; } // Optional: original file name
        public string ContentType { get; set; } // Optional: image MIME type
    }
} 