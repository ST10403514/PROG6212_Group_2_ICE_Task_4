using ICE4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;



namespace ICE4.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskModel> _tasks = new List<TaskModel>();
        private static int _nextId = 1;

        // GET: Task
        public IActionResult Index()
        {
            return View(_tasks);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _nextId++;
                _tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Task/Edit/{id}
        public IActionResult Edit(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Task/Edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
                if (existingTask == null)
                {
                    return NotFound();
                }
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Deadline
 = task.Deadline;
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Task/Delete/{id}
        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Task/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            _tasks.Remove(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
