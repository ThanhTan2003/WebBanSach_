using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class CategroryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategroryController( ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategory =_db.Categories.ToList();
            return View(objCategory);
        }
    }
}
