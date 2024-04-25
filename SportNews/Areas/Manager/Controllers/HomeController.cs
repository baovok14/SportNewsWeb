using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using SportNews.Models;
using System;
using System.Linq;

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

            if (HttpContext.Session.GetString("Username") != null)
            {

                //model.sampleStatus = _context.SampleStatuses.FromSqlRaw(GetData.GetSQLString(filter: 1,datein: "09/15/2021")).ToList();
                //model.location = _context.TblLocations.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    
        public IActionResult Login(string user, string password)
        {

            //Microsoft.AspNetCore.Mvc.Razor.RazorPageBase.Layout("_LayoutLogin") = "_LayoutLogin";

            if (HttpContext.Session.GetString("Username") == null) //Nếu đã có session => đã đăng nhập
            {
                if (user is null)
                {
                    return View();
                }
                else
                {
                    var userList = _context.TblUsers.Where(x => x.Username == user).FirstOrDefault();
                    if (userList is null)
                    {
                        return View();
                    }
                    else
                    {
                        if (userList.Username == user && userList.Password == password)
                        {
                            
                             HttpContext.Session.SetString("Username", user);
                             return RedirectToAction("Index", "Home");
                            

                        }
                        else
                        {
                            return View();
                        }

                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

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

