using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAccountApp.Data;
using TestAccountApp.Data.Entities;

namespace TestAccountApp.Controllers
{
    public class MyTasksController : Controller
    {
        private readonly TestAccountAppDbContext _context;

        public MyTasksController(TestAccountAppDbContext context)
        {
            _context = context;
        }

        // GET: MyTasks
        public async Task<IActionResult> Index()
        {
            var testAccountAppDbContext = _context.Tasks.Include(m => m.Board).Include(m => m.Owner);
            return View(await testAccountAppDbContext.ToListAsync());
        }

        // GET: MyTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks
                .Include(m => m.Board)
                .Include(m => m.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // GET: MyTasks/Create
        public IActionResult Create()
        {
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Name");
            ViewData["OwnerId"] = new SelectList(_context.MyUsers, "Id", "Id");
            return View();
        }

        // POST: MyTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedOn,BoardId,OwnerId")] MyTask myTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Name", myTask.BoardId);
            ViewData["OwnerId"] = new SelectList(_context.MyUsers, "Id", "Id", myTask.OwnerId);
            return View(myTask);
        }

        // GET: MyTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks.FindAsync(id);
            if (myTask == null)
            {
                return NotFound();
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Name", myTask.BoardId);
            ViewData["OwnerId"] = new SelectList(_context.MyUsers, "Id", "Id", myTask.OwnerId);
            return View(myTask);
        }

        // POST: MyTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedOn,BoardId,OwnerId")] MyTask myTask)
        {
            if (id != myTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTaskExists(myTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoardId"] = new SelectList(_context.Boards, "Id", "Name", myTask.BoardId);
            ViewData["OwnerId"] = new SelectList(_context.MyUsers, "Id", "Id", myTask.OwnerId);
            return View(myTask);
        }

        // GET: MyTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var myTask = await _context.Tasks
                .Include(m => m.Board)
                .Include(m => m.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myTask == null)
            {
                return NotFound();
            }

            return View(myTask);
        }

        // POST: MyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'TestAccountAppDbContext.Tasks'  is null.");
            }
            var myTask = await _context.Tasks.FindAsync(id);
            if (myTask != null)
            {
                _context.Tasks.Remove(myTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyTaskExists(int id)
        {
          return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
