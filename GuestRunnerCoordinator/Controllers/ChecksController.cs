﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestRunnerCoordinator.Models;

namespace GuestRunnerCoordinator.Controllers
{
    public class ChecksController : Controller
    {
        private readonly GuestRunnerCoordinatorContext _context;

        public ChecksController(GuestRunnerCoordinatorContext context)
        {
            _context = context;
        }

        // GET: Checks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Check.ToListAsync());
        }

        // GET: Checks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.Check
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // GET: Checks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckId,UserId,OpenTime,Closed,PaymentTypeId,Room")] Check check)
        {
            if (ModelState.IsValid)
            {
                _context.Add(check);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(check);
        }

        // GET: Checks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.Check.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckId,UserId,OpenTime,Closed,PaymentTypeId,Room")] Check check)
        {
            if (id != check.CheckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(check);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckExists(check.CheckId))
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
            return View(check);
        }

        // GET: Checks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.Check
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var check = await _context.Check.FindAsync(id);
            _context.Check.Remove(check);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckExists(int id)
        {
            return _context.Check.Any(e => e.CheckId == id);
        }
    }
}
