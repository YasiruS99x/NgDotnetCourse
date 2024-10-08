using CultureIntelligence.API.Data;
using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Models.DTO;
using CultureIntelligence.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CultureIntelligence.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            var category = await dbContext.Categories.ToListAsync();
            return category;
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category?> EditCategory(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if(existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;    
        }

        public async Task<Category?> DeleteCategory(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCategory != null)
            {
                dbContext.Remove(existingCategory);
                await dbContext.SaveChangesAsync();
                return existingCategory;
            }
            return null;
        }
    }
}
