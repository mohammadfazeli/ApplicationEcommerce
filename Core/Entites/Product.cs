namespace Core.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int? ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        
    }
}