using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_App_copia_1.Data
{
    public class IdeeCasa
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdeeCasaId { get; set; }

        [Required]
        [DisplayName("Titolo")]
        public string TitoloIdea { get; set; }
        
        [Required]
        [DisplayName("Descrizione")]
        public string Descrizione { get; set; }
    }
}
