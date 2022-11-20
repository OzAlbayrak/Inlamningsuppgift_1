using Inlamningsuppgift_1_WebApi.Models.Entities;

namespace Inlamningsuppgift_1_WebApi.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
