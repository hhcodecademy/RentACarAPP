using RentACarAPP.Domain.Enum;

namespace RentACarAPP.Domain.Entity
{
    public class Car : BaseEntity
    {
        public int Year { get; set; } // Year of manufacture
        public string Description { get; set; }
        public decimal Price { get; set; }
        public FuelType FuelType { get; set; } // Enum for fuel type (e.g., Petrol, Diesel, Electric)      
        public string ImageUrl { get; set; } // URL or path to the car image
        public int CarModelId { get; set; } // Foreign key to the CarModel entity
        public CarModel CarModel { get; set; } // Navigation property for the related car model
        public ICollection<CarDocument> CarDocuments { get; set; } = new List<CarDocument>(); // Collection of car documents

    }


}
