using Microsoft.AspNetCore.Mvc;
using TodoListWeb.Data;
using TodoListWeb.Models;

namespace TodoListWeb.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TodoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Todo> objCategoryList = _db.todos;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Todo obj)
        {
            if (ModelState.IsValid)
            {
                _db.todos.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Todo created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var todoFromDb = _db.todos.Find(id);

            if (todoFromDb == null)
                return NotFound();

            return View(todoFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Todo obj)
        {
            if (ModelState.IsValid)
            {
                _db.todos.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Todo edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var todoFromDb = _db.todos.Find(id);

            if (todoFromDb == null)
                return NotFound();

            return View(todoFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.todos.Find(id);

            if (obj == null)
                return NotFound();

            _db.todos.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Todo deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
