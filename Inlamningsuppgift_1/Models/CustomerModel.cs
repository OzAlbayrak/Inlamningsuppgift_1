using Inlamningsuppgift_1_WebApi.Models.Entities;

namespace Inlamningsuppgift_1_WebApi.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? StreetNumber { get; set; }
    }
}
