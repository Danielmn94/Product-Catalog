namespace Product_Catalog.Data.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string StyleName { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public int ColorID { get; set; }
        public string SizeName { get; set; }
        public string SizeID { get; set; }
        public bool Sustainable { get; set; }
        public string ItemNo { get; set; }
    }
}
