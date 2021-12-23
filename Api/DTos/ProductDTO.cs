namespace Api.DTos
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
    }
}