using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostContext _context;

        public HomeController(PostContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.posts.ToListAsync());
        }

        public async Task<IActionResult> GetOne(String id)
        {
            if (id == null) {
                return NotFound();
            }

            var post = await _context.posts
                .FirstOrDefaultAsync(md => md.title == id);
            if (post == null) {
                return NotFound();
            }
            return View(post);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
