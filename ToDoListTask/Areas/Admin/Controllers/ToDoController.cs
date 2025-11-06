using Microsoft.AspNetCore.Mvc;
using ToDoListTask.Models;
using ToDoListTask.Models.EntityConfigration;

namespace ToDoListTask.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]

    public class ToDoController : Controller
    {
        ApplicationDbContext _context = new ();

        public IActionResult ToDoList()
        {
            var ToDoLists = _context.toDoLists.AsQueryable().OrderByDescending(t => t.Deadline);

            return View(ToDoLists.ToList());
        }

        [HttpGet]
        public IActionResult AddToDo()
        {

           return View(new ToDoList());
        }
     
        [HttpPost]
        public IActionResult AddToDo(ToDoList toDoList , IFormFile uploadFile)
         
        {
            if (!ModelState.IsValid)
            {
                return View(toDoList);
            }

            if (uploadFile is not null && uploadFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\ToDos_Files", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    uploadFile.CopyTo(stream);
                }
                toDoList.File = fileName;
            }
          
            _context.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("ToDoList", "ToDo");
        }
        public IActionResult DownloadFile(int id)
        {
            var toDoItem = _context.toDoLists.FirstOrDefault(t => t.Id == id);

            if (toDoItem == null || string.IsNullOrEmpty(toDoItem.File))
                return NotFound("File not found");

          
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "ToDos_Files", toDoItem.File);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found on server");

         
            var mimeType = "application/octet-stream"; 

            
            return PhysicalFile(filePath, mimeType, toDoItem.File);
        }

        public IActionResult Index()
        {



            return View();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {

            var toDoLists = _context.toDoLists.FirstOrDefault(e => e.Id == id );

              return View(toDoLists);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDoList toDoList)
        {
            _context.toDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("ToDoList", "ToDo");
        }

 
        public IActionResult Delete(int id)
        {
                var toDoList = _context.toDoLists.FirstOrDefault(e => e.Id == id);
            if (toDoList is null)
            {
                return RedirectToAction("ToDoList", "ToDo");
            }
            _context.toDoLists.Remove(toDoList);
            _context.SaveChanges();
            return RedirectToAction("ToDoList", "ToDo");
        }
    }
}
