using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // this db will have all the implementation of
        // connection strings and tables that are needed to retrive the data 
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;     
        }

        public IActionResult Index()
        {
            // we can use var in c# it is an infered type
            /*
             IEnumerable is an interface in C# that represents a collection of elements that can be enumerated (i.e., iterated over) sequentially. It is part of the .NET Framework's
             collection classes and is defined in the System.Collections namespace. IEnumerable is a read-only interface, which means that you can only iterate over the elements in
             the collection and cannot modify them. If you need to modify the elements in a collection, you can use the ICollection or IList interfaces, which inherit from IEnumerable and
             provide additional methods for adding, removing, and modifying elements.
            */
            IEnumerable<Category> objCatagoryList = _db.Categories;
            return View(objCatagoryList);
        }
        
        //GET action method
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        //like htmlspecialchars in php to protect for xss
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder canot exactly match the Name.");
            }
            if(ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
           return View(obj);
        }

        //GET action method
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        //like htmlspecialchars in php to protect for xss
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder canot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        //like htmlspecialchars in php to protect for xss
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
            
            return View(obj);
        }
    }
}
