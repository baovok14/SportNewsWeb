using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SportNews.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
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
}
