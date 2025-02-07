using Flower_App_copia_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Flower_App_copia_1.Views.IdeeCasa
{

    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<IdeaCasa> IdeeCasa { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            IdeeCasa = _db.IdeeCasa;
        }
    }
}

