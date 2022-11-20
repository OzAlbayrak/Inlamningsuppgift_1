using WpfApp.Models.Entities;

namespace WpfApp.Models
{
    public class OrderRowCreateModel
    {
        public int ProductQuantitiy { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public int OrderId { get; set; }
        public int OrderEntityId { get; set; }
    }
}