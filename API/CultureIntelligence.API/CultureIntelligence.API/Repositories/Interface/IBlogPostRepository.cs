using CultureIntelligence.API.Models.Domain;

namespace CultureIntelligence.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateBlogPost(BlogPost blogPost);
        Task<List<BlogPost>> GetBlogPosts();
    }
}
