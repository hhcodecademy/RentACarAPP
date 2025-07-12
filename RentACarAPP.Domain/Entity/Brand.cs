namespace RentACarAPP.Domain.Entity
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? LogoUrl { get; set; } // URL to the brand logo image
        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>(); // Navigation property for related car models
        // You can add more properties or methods specific to the Brand entity if needed
    }
}
