using database_assignment_1.Contexts;
using database_assignment_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace database_assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductCategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productCategories = new List<ProductCategoryModel>();

            foreach (var category in await _context.ProductCategories.ToListAsync())
                productCategories.Add(new ProductCategoryModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });

            return new OkObjectResult(productCategories);
        }
    }
}
