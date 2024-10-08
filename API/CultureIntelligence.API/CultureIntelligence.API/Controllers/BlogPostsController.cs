using Azure.Core;
using CultureIntelligence.API.Models.Domain;
using CultureIntelligence.API.Models.DTO;
using CultureIntelligence.API.Repositories.Implementation;
using CultureIntelligence.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CultureIntelligence.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto request)
        {
            var blogPost = new BlogPost
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                IsVisible = request.IsVisible,
            };

            await blogPostRepository.CreateBlogPost(blogPost);

            var result = new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible,
            };

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            var blogPosts = await blogPostRepository.GetBlogPosts();

            var response = new List<BlogPostDto>();

            foreach (var blogPost in blogPosts)
            {
                response.Add(

                    new BlogPostDto
                    {

                        Id = blogPost.Id,
                        Title = blogPost.Title,
                        ShortDescription = blogPost.ShortDescription,
                        Content = blogPost.Content,
                        FeaturedImageUrl = blogPost.FeaturedImageUrl,
                        UrlHandle = blogPost.UrlHandle,
                        PublishedDate = blogPost.PublishedDate,
                        Author = blogPost.Author,
                        IsVisible = blogPost.IsVisible,

                    }

                );
            }

            return Ok(response);

        }
    }
}
