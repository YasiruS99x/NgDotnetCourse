using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Models.DTO;

namespace CultureIntelligence.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> GetCategories();
        Task<Category?> GetCategoryById(Guid id);
        Task<Category?> EditCategory(Category category);
        Task<Category?> DeleteCategory(Guid id);
    }
}
