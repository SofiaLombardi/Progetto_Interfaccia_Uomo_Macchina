using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Flower_App_copia_1.Data
{
    public class Consigli
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ConsiglioId { get; set; }

        [Required]
        [DisplayName("Titolo")]
        public string TitoloConsiglio { get; set; }

        [Required]
        [DisplayName("Descrizione")]
        public string Descrizione { get; set; }
    }
}
