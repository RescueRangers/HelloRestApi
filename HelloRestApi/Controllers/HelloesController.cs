using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloRestApi.Model;
using HelloRestApi.Models;

namespace HelloRestApi.Controllers
{
    public class HelloesController : Controller
    {
        private readonly HelloRestApiContext _context;

        public HelloesController(HelloRestApiContext context)
        {
            _context = context;
        }

        // GET: Helloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hello.ToListAsync());
        }

        // GET: Helloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hello = await _context.Hello
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hello == null)
            {
                return NotFound();
            }

            return View(hello);
        }

        // GET: Helloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Message,Author,TimeStamp")] Hello hello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hello);
        }

        // GET: Helloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hello = await _context.Hello.FindAsync(id);
            if (hello == null)
            {
                return NotFound();
            }
            return View(hello);
        }

        // POST: Helloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Message,Author,TimeStamp")] Hello hello)
        {
            if (id != hello.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelloExists(hello.ID))
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
            return View(hello);
        }

        // GET: Helloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hello = await _context.Hello
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hello == null)
            {
                return NotFound();
            }

            return View(hello);
        }

        // POST: Helloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hello = await _context.Hello.FindAsync(id);
            _context.Hello.Remove(hello);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelloExists(int id)
        {
            return _context.Hello.Any(e => e.ID == id);
        }
    }
}
