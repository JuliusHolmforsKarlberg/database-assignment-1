using database_assignment_1.Contexts;
using database_assignment_1.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace database_assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateModel model)
        {
            var orderEntity = new OrderEntity
            {
                OrderDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress
            };

            foreach (var product in model.Products)
                orderEntity.Products.Add(new ProductEntity { Id = product.Id });

            _context.Add(orderEntity);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
