using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template.Services.Shared
{
    public class Alert
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // ID univoco dell'allerta

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } // Descrizione dell'allerta

        [Required]
        [Display(Name ="Alert type")]
        public AlertType Type { get; set; } // Tipo di allerta (es. insetti, malattie)

        [Required]
        [Display(Name ="Alert level")]
        public AlertLevel Level { get; set; }//Grado di allerta(verde, giallo, rosso come il semaforo)
        [Display(Name = "Date issued")]
        public DateTime DateIssued { get; set; } = DateTime.UtcNow; // Data di emissione

        // Collegamento con la pianta (ogni allerta è legata a una pianta)
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }

        // Collegamento con Treatment (un'Allerta può essere legata a un trattamento)
        public Guid? TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }

    // Enum per il tipo di allerta
    public enum AlertType
    {
        Insects,
        Disease,
        Environmental
    }
    public enum AlertLevel
    {
        Green = 0,
        Yellow = 1,
        Red = 2,

    }
}
