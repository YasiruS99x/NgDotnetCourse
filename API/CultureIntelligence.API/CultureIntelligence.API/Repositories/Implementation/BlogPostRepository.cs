using CultureIntelligence.API.Data;
using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CultureIntelligence.API.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {

        private readonly ApplicationDbContext dbContext;
        public BlogPostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateBlogPost(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();

            return blogPost;
        }
        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await dbContext.BlogPosts.ToListAsync();
            return blogPosts;
        }


    }
}
