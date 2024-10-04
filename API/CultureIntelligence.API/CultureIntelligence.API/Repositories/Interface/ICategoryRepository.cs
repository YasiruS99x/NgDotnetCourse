using CultureIntelligence.API.Models.Domain;

namespace CultureIntelligence.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
