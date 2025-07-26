using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarAPP.Contract.Dtos.External
{

    public class Rootobject
    {
        public ProductInboundDto[] Products { get; set; }
    }
    public record ProductInboundDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string Category { get; init; }
        public decimal Price { get; init; }
        public decimal DiscountPercentage { get; init; }
        public string Brand { get; init; }





    }
}
