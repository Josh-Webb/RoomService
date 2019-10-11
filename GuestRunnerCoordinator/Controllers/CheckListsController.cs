using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestRunnerCoordinator.Models;

namespace GuestRunnerCoordinator.Controllers
{
    public class CheckListsController : Controller
    {
        private readonly GuestRunnerCoordinatorContext _context;

        public CheckListsController(GuestRunnerCoordinatorContext context)
        {
            _context = context;
        }

        // GET: CheckLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckList.ToListAsync());
        }

        // GET: CheckLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkList = await _context.CheckList
                .FirstOrDefaultAsync(m => m.ChecklistId == id);
            if (checkList == null)
            {
                return NotFound();
            }

            return View(checkList);
        }

        // GET: CheckLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChecklistId,Runner,Completed,TimeCreated")] CheckList checkList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkList);
        }

        // GET: CheckLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkList = await _context.CheckList.FindAsync(id);
            if (checkList == null)
            {
                return NotFound();
            }
            return View(checkList);
        }

        // POST: CheckLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChecklistId,Runner,Completed,TimeCreated")] CheckList checkList)
        {
            if (id != checkList.ChecklistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckListExists(checkList.ChecklistId))
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
            return View(checkList);
        }

        // GET: CheckLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkList = await _context.CheckList
                .FirstOrDefaultAsync(m => m.ChecklistId == id);
            if (checkList == null)
            {
                return NotFound();
            }

            return View(checkList);
        }

        // POST: CheckLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkList = await _context.CheckList.FindAsync(id);
            _context.CheckList.Remove(checkList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckListExists(int id)
        {
            return _context.CheckList.Any(e => e.ChecklistId == id);
        }
    }
}
