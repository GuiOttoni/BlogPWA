using BlogPWA.Infrastructure.Interface;
using BlogPWA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogPWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger,
            IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LatestBlogPost()
        {
            var posts = _blogService.GetLatestPosts();

            return Json(posts);
        }

        public JsonResult MoreBlogPosts(int oldestBlogPostId)
        {
            var posts = _blogService.GetOlderPosts(oldestBlogPostId);
            return Json(posts);
        }
    }
}