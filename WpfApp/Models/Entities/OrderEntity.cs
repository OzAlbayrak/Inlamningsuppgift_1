using System;
using System.Collections.Generic;
using WpfApp.Models.Entities;

namespace WpfApp.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string? CustomerPhone { get; set; }
        public string CustomerStreetName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerPostalCode { get; set; }
        public int? CustomerStreetNumber { get; set; }
        public ICollection<OrderRowEntity> OrderRows { get; set; }
    }
}
