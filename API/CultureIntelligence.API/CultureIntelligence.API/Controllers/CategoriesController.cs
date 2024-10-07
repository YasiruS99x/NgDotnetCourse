using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Models.DTO;
using CultureIntelligence.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CultureIntelligence.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await categoryRepository.CreateAsync(category);

            var result = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryRepository.GetCategories();

            var response = new List<CategoryDto>();

            foreach (var category in categories)
            {
                response.Add(

                    new CategoryDto
                    {

                        Id = category.Id,
                        Name = category.Name,
                        UrlHandle = category.UrlHandle

                    }

                );
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var category = await categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            var response = new CategoryDto();

            response.Id = category.Id;
            response.Name = category.Name;
            response.UrlHandle = category.UrlHandle;

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryRequest request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            category = await categoryRepository.EditCategory(category);

            if(category == null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteCategory(id);

            if (category is null) return NotFound();
            
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response); 
        }
    }
}