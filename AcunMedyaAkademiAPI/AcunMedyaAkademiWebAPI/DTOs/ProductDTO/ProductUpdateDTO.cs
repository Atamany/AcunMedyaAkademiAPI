using AcunMedyaAkademiWebAPI.Entities;

namespace AcunMedyaAkademiWebAPI.DTOs.ProductDTO
{
    public class ProductUpdateDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
