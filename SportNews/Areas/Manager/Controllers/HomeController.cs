using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportNews.Models;
using System;

namespace SportNews.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsContext _context;
        NewsContext db = new NewsContext();

        public HomeController(ILogger<HomeController> logger, NewsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            //if(HttpContext.Session())
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult admin()
        {
            return View();
        }
    }
}
    //[Area("Manager")]
    //[HttpPost]
    //public IActionResult Index(UserBlog blog, IFormFile image)
    //{
    //    if (HttpContext.Session.GetInt32("UserId") == null) return RedirectToAction("Login");
    //    blog.UserId = (int)HttpContext.Session.GetInt32("UserId")!;
    //    blog.DateTime = DateTime.Now;
    //    if (image != null)
    //    {
    //        blog.Image = image.FileName;
    //        if (!UploadFile(image, blog.UserId.ToString()).Result)
    //        {
    //            // if the file is not uploaded successfully pop up a message 
    //            ModelState.AddModelError("Image", "The image is not uploaded successfully");
    //            return View();
    //        }
    //    }
    //    _context.Add(blog);
    //    _context.SaveChanges();
    //    if (ModelState.IsValid)
    //        return RedirectToAction("Index");
    //    return View();
    //}

