using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Template.Services.Shared
{
    public class Treatment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // ID univoco del trattamento

        [Required]
        public Guid PlantId { get; set; } // Foreign Key riferita a Pianta
        public Plant Plant { get; set; } // Relazione con Pianta

        public TreatmentDetails Details { get; set; } = new TreatmentDetails();

        public TreatmentSchedule Scheduling { get; set; } = new TreatmentSchedule();

        //Relazione 1:N con Alert (un trattamento può essere associato a più allerte)
        public List<Alert> Alerts { get; set; } = new List<Alert>();
    }

    [Owned]
    public class TreatmentDetails
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TreatmentType Type { get; set; } // Enum per tipologia di trattamento
    }

    [Owned]
    public class TreatmentSchedule
    {
        [Required]
        public DateTime StartDate { get; set; } // Data di inizio trattamento

        public DateTime? EndDate { get; set; } // Data di fine (opzionale)

        public int Repetitions { get; set; } // Numero di ripetizioni (giorni, settimane, ecc.)
    }

    public enum TreatmentType
    {
        Curative,
        Preventive
    }
}
