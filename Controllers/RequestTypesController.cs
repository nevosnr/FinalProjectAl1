using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectAl1.Data;

namespace FinalProjectAl1.Controllers
{
    public class RequestTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestTypes.ToListAsync());
        }

        // GET: RequestTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.Request_TaskId == id);
            if (requestType == null)
            {
                return NotFound();
            }

            return View(requestType);
        }

        // GET: RequestTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Request_TaskId,Request_DateTime,Request_FirstName,Request_LastName,Request_EmailAdd,Request_TeamSelect,Request_TaskDescription")] RequestType requestType)
        {
            if (ModelState.IsValid)
            {
                requestType.Request_TaskId = Guid.NewGuid();
                _context.Add(requestType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestType);
        }

        // GET: RequestTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes.FindAsync(id);
            if (requestType == null)
            {
                return NotFound();
            }
            return View(requestType);
        }

        // POST: RequestTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Request_TaskId,Request_DateTime,Request_FirstName,Request_LastName,Request_EmailAdd,Request_TeamSelect,Request_TaskDescription")] RequestType requestType)
        {
            if (id != requestType.Request_TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestTypeExists(requestType.Request_TaskId))
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
            return View(requestType);
        }

        // GET: RequestTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestType = await _context.RequestTypes
                .FirstOrDefaultAsync(m => m.Request_TaskId == id);
            if (requestType == null)
            {
                return NotFound();
            }

            return View(requestType);
        }

        // POST: RequestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var requestType = await _context.RequestTypes.FindAsync(id);
            if (requestType != null)
            {
                _context.RequestTypes.Remove(requestType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestTypeExists(Guid id)
        {
            return _context.RequestTypes.Any(e => e.Request_TaskId == id);
        }
    }
}
