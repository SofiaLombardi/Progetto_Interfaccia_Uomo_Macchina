using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_App_copia_1.Data
{
    public class Trattamenti
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String IdTrattamento { get; set; } // Chiave primaria

        [Required]
        [StringLength(100)]
        public string Titolo { get; set; } // Nome o titolo del trattamento

        [Required]
        public string Descrizione { get; set; } // Descrizione del trattamento

        [Required]
        public Tipologia Tipo { get; set; } // Tipologia del trattamento

        public enum Tipologia
        {
            Curativo,
            Preventivo
        }


        [Required]
        public DateTime DataInizio { get; set; } // Data di inizio del trattamento

        public DateTime? DataFine { get; set; } // Data di fine del trattamento (può essere null)

        public int Ripetizioni { get; set; } // Ogni quanto si deve ripetere (in giorni, settimane, ecc.)


        [Required]
        [DisplayName("Id Pianta")]
        public string IdPianta { get; set; }
        public Piante Pianta { get; set; }


        [DisplayName("Id Pianta")]
        public string AllerteId { get; set; }
        public Allerte Allerta { get; set; }

    }
}