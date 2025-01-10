using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Flower_App_copia_1.Data
{
    public class Allerte
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string AllerteId { get; set; }

        [Required]
        [DisplayName("Titolo")]
        public string Titolo { get; set; }

        [Required]
        [DisplayName("Descrizione")]
        public string Descrizione { get; set; }

        [Required]
        [DisplayName("Grado allerta")]

        public Grado GradoAllerta { get; set; }
        public enum Grado { Rossa, Arancione, Verde }

    }
}
