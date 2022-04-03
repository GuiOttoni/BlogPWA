using BlogPWA.Models;

namespace BlogPWA.Infrastructure.Interface
{
    public interface IBlogService
    {
        List<BlogPost> GetLatestPosts();
        List<BlogPost> GetOlderPosts(int olderBlogPostId);
        string GetPostText(string link);
    }
}
