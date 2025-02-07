using Flower_App_copia_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flower_App_copia_1.Controllers
{
    public class IdeeCasaController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public IdeeCasaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber, string titoloIdea, string descrizione)
        {
            ViewData["FilterTitoloIdea"] = titoloIdea;
            ViewData["FilterDescrizione"] = descrizione;
            var model = await GetConsigli(pageNumber, titoloIdea, descrizione);

            return base.View(model);
        }

        public async Task<IActionResult> Search(string term)
        {
            var ideeCasa = from x in _context.IdeeCasa select x;

            if (!string.IsNullOrEmpty(term))
                ideeCasa = ideeCasa.Where(x => x.TitoloIdea.Contains(term));

            var results = await ideeCasa.OrderBy(x => x.TitoloIdea)
                .Take(PageSize)
                .Select(x => new { id = x.IdeeCasaId, text = x.TitoloIdea })
                .ToListAsync();

            return Ok(new { results });
        }

        // GET: IdeeCasa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IdeeCasa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdeeCasaId,TitoloIdea,Descrizione")] IdeaCasa ideeCasa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ideeCasa);
                await _context.SaveChangesAsync();
                Response.Cookies.Append("ConsiglioId", ideeCasa.IdeeCasaId);
                return RedirectToAction(nameof(Index));
            }
            return View(ideeCasa);
        }

        // GET: IdeeCasa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaCasa = await _context.IdeeCasa.FirstOrDefaultAsync(m => m.IdeeCasaId == id);

            if (ideaCasa == null)
            {
                return NotFound();
            }

            return View(ideaCasa);
        }

        // GET: IdeeCasa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaCasa = await _context.IdeeCasa.FindAsync(id);
            if (ideaCasa == null)
            {
                return NotFound();
            }
            return View(ideaCasa);
        }

        // POST: IdeeCasa/Edit/5.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdeeCasaId,TitoloIdea,Descrizione")] IdeaCasa ideeCasa)
        {
            if (id != ideeCasa.IdeeCasaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideeCasa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeeCasaExists(ideeCasa.IdeeCasaId))
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
            return View(ideeCasa);
        }

        private bool IdeeCasaExists(string id)
        {
            return _context.IdeeCasa.Any(e => e.IdeeCasaId == id);
        }

        // GET: IdeeCasa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaCasa = await _context.IdeeCasa.FirstOrDefaultAsync(m => m.IdeeCasaId == id);

            if (ideaCasa == null)
            {
                return NotFound();
            }

            return View(ideaCasa);
        }

        // POST: IdeeCasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ideaCasa = await _context.IdeeCasa.FindAsync(id);
            _context.IdeeCasa.Remove(ideaCasa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<PaginatedList<IdeaCasa>> GetConsigli(int? pageNumber, string titoloIdea, string descrizione)
        {
            var ideeCasa = from x in _context.IdeeCasa select x;

            if (!string.IsNullOrEmpty(titoloIdea))
                ideeCasa = ideeCasa.Where(x => x.TitoloIdea.Contains(titoloIdea));

            if (!string.IsNullOrEmpty(descrizione))
                ideeCasa = ideeCasa.Where(x => x.Descrizione.Contains(descrizione));

            ideeCasa = ideeCasa.OrderBy(x => x.TitoloIdea);

            return await PaginatedList<IdeaCasa>.CreateAsync(ideeCasa.AsNoTracking(), pageNumber ?? 1, PageSize);
        }
    }
}
