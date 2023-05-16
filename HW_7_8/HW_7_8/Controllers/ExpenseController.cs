using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW_7_8;
using HW_7_8.Models;

namespace HW_7_8.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AccountingContext _context;

        public ExpenseController(AccountingContext context)
        {
            _context = context;
        }

        // GET: Expense
        public async Task<IActionResult> Index()
        {
            var accountingContext = _context.Expenses.Include(e => e.Category);
            return View(await accountingContext.ToListAsync());
        }

        // GET: Expense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Cost,Comment,Date,CategoryId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expense.CategoryId);
            return View(expense);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expense.CategoryId);
            return View(expense);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Cost,Comment,Date,CategoryId")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expense.CategoryId);
            return View(expense);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Expenses == null)
            {
                return Problem("Entity set 'AccountingContext.Expenses'  is null.");
            }
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
          return (_context.Expenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
