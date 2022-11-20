using Inlamningsuppgift_1_WebApi.Contexts;
using Inlamningsuppgift_1_WebApi.Models;
using Inlamningsuppgift_1_WebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inlamningsuppgift_1_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var customers = new List<CustomerModel>();
            foreach(var customer in await _context.Customers.Include(x => x.Address).ToListAsync()) 
            {
                customers.Add(new CustomerModel
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    AddressId = customer.AddressId,
                    StreetName = customer.Address.StreetName,
                    City = customer.Address.City,
                    PostalCode = customer.Address.PostalCode,
                    StreetNumber = customer.Address.StreetNumber
                });
            }
            return new OkObjectResult(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var customerEntity = await _context.Customers.Include(x => x.Address).FirstOrDefaultAsync(x=> x.Id == id);
            if (customerEntity != null) 
            { 
                return new OkObjectResult(new CustomerModel
                {
                    Id = customerEntity.Id,
                    Name = customerEntity.Name,
                    Email = customerEntity.Email,
                    Phone = customerEntity.Phone,
                    AddressId = customerEntity.AddressId,
                    StreetName = customerEntity.Address.StreetName,
                    City = customerEntity.Address.City,
                    PostalCode = customerEntity.Address.PostalCode,
                    StreetNumber = customerEntity.Address.StreetNumber
                }); 
            }
            return new NotFoundResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model) 
        {
            if (ModelState.IsValid) 
            {
                var addressEntity = new AddressEntity
                {
                    StreetName = model.StreetName,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    StreetNumber = model.StreetNumber
                };
                _context.Add(addressEntity);
                await _context.SaveChangesAsync();

                var customerEntity = new CustomerEntity
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    AddressId = addressEntity.Id
                };
                _context.Add(customerEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest();
        }
    }
}
