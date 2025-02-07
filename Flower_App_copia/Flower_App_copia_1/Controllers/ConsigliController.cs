using Flower_App_copia_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower_App_copia_1.Controllers
{
    public class ConsigliController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public ConsigliController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber, string titoloConsiglio, string descrizione)
        {
            ViewData["FilterTitoloConsiglio"] = titoloConsiglio;
            ViewData["FilterDescrizione"] = descrizione;
            var model = await GetConsigli(pageNumber,titoloConsiglio, descrizione);

            return base.View(model);
        }

        public async Task<IActionResult> Search(string term)
        {
            var consigli = from x in _context.Consigli select x;

            if (!string.IsNullOrEmpty(term))
                consigli = consigli.Where(x => x.TitoloConsiglio.Contains(term));

            var results = await consigli.OrderBy(x => x.TitoloConsiglio)
                .Take(PageSize)
                .Select(x => new { id = x.ConsiglioId, text = x.TitoloConsiglio })
                .ToListAsync();

            return Ok(new { results });
        }

        // GET: Consigli/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consigli/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceName,Description,Price")] Consigli consigli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consigli);
                await _context.SaveChangesAsync();
                Response.Cookies.Append("ConsiglioId", consigli.ConsiglioId);
                return RedirectToAction(nameof(Index));
            }
            return View(consigli);
        }

        // GET: Consigli/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consiglio = await _context.Consigli.FirstOrDefaultAsync(m => m.ConsiglioId == id);

            if (consiglio == null)
            {
                return NotFound();
            }

            return View(consiglio);
        }

        // GET: Consigli/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consiglio = await _context.Consigli.FindAsync(id);
            if (consiglio == null)
            {
                return NotFound();
            }
            return View(consiglio);
        }

        // POST: Consigli/Edit/5.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConsiglioId, TitoloConsiglio,Descrizione")] Consigli consigli)
        {
            if (id != consigli.ConsiglioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consigli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsiglioExists(consigli.ConsiglioId))
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
            return View(consigli);
        }

        private bool ConsiglioExists(string id)
        {
            return _context.Consigli.Any(e => e.ConsiglioId == id);
        }

        // GET: Consigli/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consiglio = await _context.Consigli.FirstOrDefaultAsync(m => m.ConsiglioId == id);

            if (consiglio == null)
            {
                return NotFound();
            }

            return View(consiglio);
        }

        // POST: Consigli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var service = await _context.Consigli.FindAsync(id);
            _context.Consigli.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<PaginatedList<Consigli>> GetConsigli(int? pageNumber, string titoloConsiglio, string descrizione)
        {
            var consigli = from x in _context.Consigli select x;

            if (!string.IsNullOrEmpty(titoloConsiglio))
                consigli = consigli.Where(x => x.TitoloConsiglio.Contains(titoloConsiglio));

            if (!string.IsNullOrEmpty(descrizione))
                consigli = consigli.Where(x => x.Descrizione.Contains(descrizione));

            consigli = consigli.OrderBy(x => x.TitoloConsiglio);

            return await PaginatedList<Consigli>.CreateAsync(consigli.AsNoTracking(), pageNumber ?? 1, PageSize);
        }
    }
}
