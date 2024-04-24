using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportNews.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Controllers
{
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
        public IActionResult DetailsBaiBao(string id)
        {
            var lsPost = _context.TblPosts.Where(b => b.IdPost.ToString() == id).ToList();

            return View(lsPost);
        }
        public string LoadTitleCategory(string title)
        {
            string strSQL = "Select * from tbl_Posts";
            if(title  == null || title == "") 
            {
                return strSQL;
            }
            else
            {
                strSQL += " where 1 = 1";
                strSQL += " and cate_id = '" + title + "'";
                return strSQL;
            }    
        }
        public IActionResult BongRo()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("BR")).ToList();
            return View(lsView);
        }
        public IActionResult BongChuyen()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("BC")).ToList();
            return View(lsView);
        }
        public IActionResult CauLong()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("CL")).ToList();
            return View(lsView);
        }
        public IActionResult BongBan()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("BB")).ToList();
            return View(lsView);
        }
        public IActionResult BoiLoi()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("BL")).ToList();
            return View(lsView);
        }
        public IActionResult Billiards()
        {
            var lsView = _context.TblPosts.FromSqlRaw(LoadTitleCategory("BIL")).ToList();
            return View(lsView);
        }
    }
}
