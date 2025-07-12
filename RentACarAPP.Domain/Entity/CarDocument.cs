namespace RentACarAPP.Domain.Entity
{
    public class CarDocument : BaseEntity
    {
        public string DocumentName { get; set; } // Name of the document (e.g., "Insurance", "Registration")
        public string OriginalName { get; set; }
        public string DocumentUrl { get; set; } // URL or path to the document file
        public int CarId { get; set; } // Foreign key to the Car entity
        public Car Car { get; set; } // Navigation property for the related car
    }

}
