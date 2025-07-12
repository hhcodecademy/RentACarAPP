namespace RentACarAPP.Contract.Dtos
{
    public class CarModelDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int BrandId { get; set; } // Foreign key to the Brand entity
        public BrandDTO Brand { get; set; } // Navigation property for the related brand
        public ICollection<CarDTO> Cars { get; set; } = new List<CarDTO>();
    }
}
