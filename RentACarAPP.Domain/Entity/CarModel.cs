namespace RentACarAPP.Domain.Entity
{
    public class CarModel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int BrandId { get; set; } // Foreign key to the Brand entity
        public Brand Brand { get; set; } // Navigation property for the related brand
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }

}
