using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class CategroryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategroryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategory =_db.Categories.ToList();
            return View(objCategory);
        }
		public IActionResult Create()
		{
			
			return View();
		}
		//phương thức này chỉ chấp nhận yêu cầu HTTP POST
		//yêu cầu sự xác nhận (token) để bảo vệ khỏi tấn công Cross-Site Request Forgery (CSRF)
		[HttpPost]
        [ValidateAntiForgeryToken] // Xác nhận người dùng
        public IActionResult Create(Category obj)
        {
            if(obj.Name !="" && obj.DisplayOrder != null)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("CustomError", "Tên thể loại và Display Order không được trùng nhau");
                }
            }
			// Kiểm tra xem ModelState có chứa lỗi hay không
			if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index"); //chuyển hướng đến action "index"
			}
            return View(obj); 
		}

		public IActionResult Edit(int ? id)
		{

			if(id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFirstDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
		}

		// Cập nhật
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name != "" && obj.DisplayOrder != null)
			{
				if (obj.Name == obj.DisplayOrder.ToString())
				{
					ModelState.AddModelError("CustomError", "Tên thể loại và Display Order không được trùng nhau");
				}
			}
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("index");
			}
			return View(obj);
		}
	}
}
