using Inlamningsuppgift_1_WebApi.Models.Entities;

namespace Inlamningsuppgift_1_WebApi.Models
{
    public class OrderRowModel
    {
        public int Id { get; set; }
        public int ProductQuantitiy { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public int OrderId { get; set; }
        public int OrderEntityId { get; set; }
    }
}