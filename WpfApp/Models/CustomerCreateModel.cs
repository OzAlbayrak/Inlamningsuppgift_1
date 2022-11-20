using WpfApp.Models.Entities;

namespace WpfApp.Models
{
    public class CustomerCreateModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? StreetNumber { get; set; }
    }
}
