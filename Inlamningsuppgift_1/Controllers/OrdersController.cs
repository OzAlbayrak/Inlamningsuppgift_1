using Inlamningsuppgift_1_WebApi.Contexts;
using Inlamningsuppgift_1_WebApi.Controllers;
using Inlamningsuppgift_1_WebApi.Models.Entities;
using Inlamningsuppgift_1_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Inlamningsuppgift_1_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = new List<OrderModel>();
            foreach (var order in await _context.Orders.Include(x => x.OrderRows).ToListAsync())
            {
                orders.Add(new OrderModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OrderPrice = order.OrderPrice,
                    CustomerId = order.CustomerId,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    CustomerPhone = order.CustomerPhone,
                    CustomerStreetName = order.CustomerStreetName,
                    CustomerCity = order.CustomerCity,
                    CustomerPostalCode = order.CustomerPostalCode,
                    CustomerStreetNumber = order.CustomerStreetNumber,
                    OrderRows = order.OrderRows
                    //OrderRows = order.OrderRows.ToArray()
                });
            }

            return new OkObjectResult(orders);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderEntity = await _context.Orders.Include(x => x.OrderRows).FirstOrDefaultAsync(x => x.Id == id);
            if (orderEntity != null)
            {
                return new OkObjectResult(new OrderModel
                {
                    Id = orderEntity.Id,
                    OrderDate = orderEntity.OrderDate,
                    OrderPrice = orderEntity.OrderPrice,
                    CustomerId = orderEntity.CustomerId,
                    CustomerName = orderEntity.CustomerName,
                    CustomerEmail = orderEntity.CustomerEmail,
                    CustomerPhone = orderEntity.CustomerPhone,
                    CustomerStreetName = orderEntity.CustomerStreetName,
                    CustomerCity = orderEntity.CustomerCity,
                    CustomerPostalCode = orderEntity.CustomerPostalCode,
                    CustomerStreetNumber = orderEntity.CustomerStreetNumber,
                    OrderRows = orderEntity.OrderRows
                });
            }
            return new NotFoundResult();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var orderEntity = new OrderEntity
                {
                    OrderDate = DateTime.Now,
                    OrderPrice = model.OrderPrice,
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    CustomerStreetName = model.CustomerStreetName,
                    CustomerCity = model.CustomerCity,
                    CustomerPostalCode = model.CustomerPostalCode,
                    CustomerStreetNumber = model.CustomerStreetNumber,
                    //OrderRows = model.OrderRows
                };
                _context.Add(orderEntity);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return BadRequest();
        }
    }
}