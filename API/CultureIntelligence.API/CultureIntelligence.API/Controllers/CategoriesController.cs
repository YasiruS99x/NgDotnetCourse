using CultureIntelligence.API.Data;
using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CultureIntelligence.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
        }
    }
}