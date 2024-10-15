using CultureIntelligence.API.Models.Domain;

namespace CultureIntelligence.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateBlogPost(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost?> GetByIdAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost?> UpdateAsync(BlogPost blogPost);
        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
