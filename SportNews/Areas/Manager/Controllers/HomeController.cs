using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using SportNews.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewsContext _context;
        NewsContext db = new NewsContext();
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, NewsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {

            if (HttpContext.Session.GetInt32("Userid") != null)
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

            if (HttpContext.Session.GetInt32("Userid") == null) //Nếu đã có session => đã đăng nhập
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
                            
                             HttpContext.Session.SetInt32("Userid", userList.UserId);
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
        [HttpPost]
        public IActionResult Index(TblPosts blog, IFormFile image)
        {
            if (HttpContext.Session.GetInt32("Userid") == null) return RedirectToAction("Login");
            blog.UserId = HttpContext.Session.GetInt32("Userid")!;
            
            if (image != null)
            {
                blog.img = image.FileName;
                if (!UploadFile(image, blog.UserId.ToString()).Result)
                {
                    // if the file is not uploaded successfully pop up a message 
                    ModelState.AddModelError("Image", "The image is not uploaded successfully");
                    return View();
                }
            }
            _context.Add(blog);
            _context.SaveChanges();
            if (ModelState.IsValid)
                return RedirectToAction("Index");
            return View();
        }
        public async Task<bool> UploadFile(IFormFile file, string userId)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

            var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "UserFolders", userId);
            var filePath = Path.Combine(folderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }
            return true;
        }
    }
}
//[Area("Manager")]


