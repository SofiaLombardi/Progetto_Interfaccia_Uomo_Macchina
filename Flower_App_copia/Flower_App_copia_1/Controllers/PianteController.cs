using Flower_App_copia_1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Flower_App_copia_1.Data.Pianta;

namespace Flower_App_copia_1.Controllers
{
    public class PianteController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PianteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Piante/Index
        public async Task<IActionResult> Index(
            int? pageNumber,
            string nome,
            string nomeScientifico,
            string descrizionePianta,
            EsposizioneSolare? esposizione,
            string descrizioneEsposizione,
            TipologiaTerreno? terreno,
            PesantezzaTerreno? pesantezzaDelTerreno,
            PhTerreno? aciditaTerreno,
            string descrizioneTerreno,
            DateTime? fiorituraMassima,
            DateTime? fiorituraMinima,
            string descrizioneFioritura,
            Annaffiatura? irrigazione,
            string descrizioneIrrigazione,
            Concimazione? concime,
            string descrizioneConcimazione,
            DateTime? potatura,
            string descrizionePotatura,
            TipoAmbiente? ambiente,
            string descrizioneAmbiente, string ideeCasaId, string consigliId, ColoreFiore colore)
        {
            ViewData["FilterNome"] = nome;
            ViewData["FilterNomeScientifico"] = nomeScientifico;
            ViewData["FilterDescrizionePianta"] = descrizionePianta;
            ViewData["FilterEsposizione"] = esposizione;
            ViewData["FilterDescrizioneEsposizione"] = descrizioneEsposizione;
            ViewData["FilterTerreno"] = terreno;
            ViewData["FilterPesantezzaDelTerreno"] = pesantezzaDelTerreno;
            ViewData["FilterAciditaTerreno"] = aciditaTerreno;
            ViewData["FilterDescrizioneTerreno"] = descrizioneTerreno;
            ViewData["FilterFiorituraMassima"] = fiorituraMassima;
            ViewData["FilterFiorituraMinima"] = fiorituraMinima;
            ViewData["FilterDescrizioneFioritura"] = descrizioneFioritura;
            ViewData["FilterIrrigazione"] = irrigazione;
            ViewData["FilterDescrizioneIrrigazione"] = descrizioneIrrigazione;
            ViewData["FilterConcime"] = concime;
            ViewData["FilterDescrizioneConcimazione"] = descrizioneConcimazione;
            ViewData["FilterPotatura"] = potatura;
            ViewData["FilterDescrizionePotatura"] = descrizionePotatura;
            ViewData["FilterAmbiente"] = ambiente;
            ViewData["FilterDescrizioneAmbiente"] = descrizioneAmbiente;
            ViewData["FilterIdeeCasaId"] = ideeCasaId;
            ViewData["FilterConsigliId"] = consigliId;
            ViewData["FilterColore"] = colore;



            var model = await GetPiante(pageNumber, nome, nomeScientifico, descrizionePianta, esposizione, descrizioneEsposizione, terreno, pesantezzaDelTerreno, aciditaTerreno, descrizioneTerreno, fiorituraMassima, fiorituraMinima, descrizioneFioritura, irrigazione, descrizioneIrrigazione, concime, descrizioneConcimazione, potatura, descrizionePotatura, ambiente, descrizioneAmbiente, ideeCasaId, consigliId, colore);

            return View(model);
        }


        public async Task<IActionResult> Search(string term)
        {
            var piante = from x in _context.Piante select x;

            if (!string.IsNullOrEmpty(term))
                piante = piante.Where(x => x.Nome.Contains(term));

            var results = await piante.OrderBy(x => x.Nome)
                .Take(PageSize)
                .Select(x => new { id = x.IdPianta, text = x.Nome })
                .ToListAsync();

            return Ok(new { results });
        }

        // GET: Piante/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,NomeScientifico,DescrizionePianta,Esposizione,DescrizioneEsposizione,Terreno,PesantezzaDelTerreno,AciditàTerreno,DescrizioneTerreno,FiorituraMax,FiorituraMin,DescrizioneFioritura,Irrigazione,DescrizioneIrrigazione,Concime,DescrizioneConcimazione,Potatura,DescrizionePotatura,Ambiente,DescrizioneAmbiente,IdeeCasaId,ConsigliId,Colore")] Pianta pianta, IFormFile fotoPianta, string[] selectedClienti)
        {
            if (ModelState.IsValid)
            {
                // Controllo se la foto è stata caricata
                if (fotoPianta != null && fotoPianta.Length > 0)
                {
                    // Verifica il tipo di file (immagine)
                    if (fotoPianta.ContentType.StartsWith("image/"))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await fotoPianta.CopyToAsync(memoryStream);
                            pianta.FotoPianta = memoryStream.ToArray(); // Converte l'immagine in byte[] e la salva
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("FotoPianta", "Il file caricato non è un'immagine valida.");
                        return View(pianta); 
                    }
                }
                else
                {
                    ModelState.AddModelError("FotoPianta", "La foto della pianta è obbligatoria.");
                    return View(pianta); 
                }

               
                _context.Add(pianta);
                await _context.SaveChangesAsync();

                if (selectedClienti != null)
                {
                    foreach (var clienteId in selectedClienti)
                    {
                        var clientePianta = new ClientePianta
                        {
                            PiantaId = pianta.IdPianta,
                            ClienteId = clienteId
                        };
                        _context.Add(clientePianta);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(pianta); 
        }


        // GET: Piante/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pianta = await _context.Piante.FindAsync(id);
            if (pianta == null)
            {
                return NotFound();
            }

            return View(pianta);
        }

        // POST: Piante/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPianta,Nome,NomeScientifico,DescrizionePianta,Esposizione,DescrizioneEsposizione,Terreno,PesantezzaDelTerreno,AciditàTerreno,DescrizioneTerreno,FiorituraMassima,FiorituraMinima,DescrizioneFioritura,Irrigazione,DescrizioneIrrigazione,Concime,DescrizioneConcimazione,Potatura,DescrizionePotatura,Ambiente,DescrizioneAmbiente,IdeeCasaId,ConsigliId,FotoPianta,Colore")] Pianta pianta)
        {
            if (id != pianta.IdPianta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pianta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiantaExists(pianta.IdPianta))
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

            return View(pianta);
        }

        // GET: Piante/Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pianta = await _context.Piante
                .FirstOrDefaultAsync(m => m.IdPianta == id);

            if (pianta == null)
            {
                return NotFound();
            }

            return View(pianta);
        }

        // GET: Piante/Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pianta = await _context.Piante
                .FirstOrDefaultAsync(m => m.IdPianta == id);

            if (pianta == null)
            {
                return NotFound();
            }

            return View(pianta);
        }

        // POST: Piante/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pianta = await _context.Piante.FindAsync(id);
            _context.Piante.Remove(pianta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiantaExists(string id)
        {
            return _context.Piante.Any(e => e.IdPianta == id);
        }

        private async Task<PaginatedList<Pianta>> GetPiante(
         int? pageNumber,
         string nome,
         string nomeScientifico,
         string descrizionePianta,
         EsposizioneSolare? esposizione,
         string descrizioneEsposizione,
         TipologiaTerreno? terreno,
         PesantezzaTerreno? pesantezzaDelTerreno,
         PhTerreno? aciditaTerreno,
         string descrizioneTerreno,
         DateTime? fiorituraMassima,
         DateTime? fiorituraMinima,
         string descrizioneFioritura,
         Annaffiatura? irrigazione,
         string descrizioneIrrigazione,
         Concimazione? concime,
         string descrizioneConcimazione,
         DateTime? potatura,
         string descrizionePotatura,
         TipoAmbiente? ambiente,
         string descrizioneAmbiente,
         string ideeCasaId,
         string consigliId,
         ColoreFiore colore)

        {
            var piante = _context.Piante
                .Include(x => x.ClientePiante)
                .Include(x => x.Consigli)
                .Include(x => x.IdeeCasa)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                piante = piante.Where(x => x.Nome.Contains(nome));

            if (!string.IsNullOrEmpty(nomeScientifico))
                piante = piante.Where(x => x.NomeScientifico.Contains(nomeScientifico));

            if (!string.IsNullOrEmpty(descrizionePianta))
                piante = piante.Where(x => x.DescrizionePianta.Contains(descrizionePianta));

            if (esposizione.HasValue)
                piante = piante.Where(x => x.Esposizione == esposizione);

            if (!string.IsNullOrEmpty(descrizioneEsposizione))
                piante = piante.Where(x => x.DescrizioneEsposizione.Contains(descrizioneEsposizione));

            if (terreno.HasValue)
                piante = piante.Where(x => x.Terreno == terreno);

            if (pesantezzaDelTerreno.HasValue)
                piante = piante.Where(x => x.PesantezzaDelTerreno == pesantezzaDelTerreno);

            if (aciditaTerreno.HasValue)
                piante = piante.Where(x => x.AciditàTerreno == aciditaTerreno);

            if (!string.IsNullOrEmpty(descrizioneTerreno))
                piante = piante.Where(x => x.DescrizioneTerreno.Contains(descrizioneTerreno));

            if (fiorituraMassima.HasValue)
                piante = piante.Where(x => x.FiorituraMinima <= fiorituraMassima);

            if (fiorituraMinima.HasValue)
                piante = piante.Where(x => x.FiorituraMassima >= fiorituraMinima);

            if (!string.IsNullOrEmpty(descrizioneFioritura))
                piante = piante.Where(x => x.DescrizioneFioritura.Contains(descrizioneFioritura));

            if (irrigazione.HasValue)
                piante = piante.Where(x => x.Irrigazione == irrigazione);

            if (!string.IsNullOrEmpty(descrizioneIrrigazione))
                piante = piante.Where(x => x.DescrizioneIrrigazione.Contains(descrizioneIrrigazione));

            if (concime.HasValue)
                piante = piante.Where(x => x.Concime == concime);

            if (!string.IsNullOrEmpty(descrizioneConcimazione))
                piante = piante.Where(x => x.DescrizioneConcimazione.Contains(descrizioneConcimazione));

            if (potatura.HasValue)
                piante = piante.Where(x => x.Potatura == potatura);

            if (!string.IsNullOrEmpty(descrizionePotatura))
                piante = piante.Where(x => x.DescrizionePotatura.Contains(descrizionePotatura));

            if (ambiente.HasValue)
                piante = piante.Where(x => x.Ambiente == ambiente);

            if (!string.IsNullOrEmpty(descrizioneAmbiente))
                piante = piante.Where(x => x.DescrizioneAmbiente.Contains(descrizioneAmbiente));

            if (!string.IsNullOrEmpty(ideeCasaId))
                piante = piante.Where(x => x.IdeeCasaId == ideeCasaId);

            if (!string.IsNullOrEmpty(consigliId))
                piante = piante.Where(x => x.ConsigliId == consigliId);

            if (colore != default(ColoreFiore))
                piante = piante.Where(x => x.Colore == colore);

            piante = piante.OrderBy(x => x.Nome);

            return await PaginatedList<Pianta>.CreateAsync(piante.AsNoTracking(), pageNumber ?? 1, PageSize);
        }
    }
}