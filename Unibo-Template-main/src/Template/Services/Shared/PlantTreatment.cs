using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Template.Services.Shared
{
    // La classe Treatment che rappresenta il trattamento
    public class Treatment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // ID univoco del trattamento

        [Required]
        public Guid PlantId { get; set; } // Foreign Key riferita a Pianta

        public TreatmentDetails Details { get; set; } = new TreatmentDetails();

        public TreatmentSchedule Scheduling { get; set; } = new TreatmentSchedule();

        // Relazione 1:N con Alert (un trattamento può essere associato a più allerte)
        public List<Alert> Alerts { get; set; } = new List<Alert>();
    }

    // Dettagli del trattamento
    [Owned]
    public class TreatmentDetails
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Treatment type")]
        public TreatmentType Type { get; set; } // Enum per tipologia di trattamento
    }

    // Pianificazione del trattamento
    [Owned]
    public class TreatmentSchedule
    {
        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; } // Data di inizio trattamento

        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; } // Data di fine (opzionale)

        public int Repetitions { get; set; } // Numero di ripetizioni (giorni, settimane, ecc.)

        [Display(Name = "Repeat Interval")]
        public TimeSpan? RepeatInterval { get; set; } // Intervallo opzionale per la ripetizione (es. ogni X giorni)

        [Display(Name = "Treatment Duration")]
        public TimeSpan Duration { get; set; } // Durata dell'intero trattamento (es. 3 settimane, 1 mese)

        public RepeatBehavior RepeatBehavior { get; set; } // Definisce come il trattamento si ripete
    }

    // Enum per il comportamento di ripetizione
    public enum RepeatBehavior
    {
        Forever,
        Limited,
        None
    }

    // Enum per il tipo di trattamento
    public enum TreatmentType
    {
        Curative,
        Preventive
    }

    // Classe di utilità per i metodi relativi ai trattamenti
    public static class TreatmentHelper
    {
        // Metodo per ottenere la data del prossimo trattamento
        public static DateTime? GetNextTreatmentDate(DateTime lastTreatmentDate, TreatmentSchedule schedule)
        {
            if (schedule.RepeatInterval.HasValue)
            {
                // Se il comportamento di ripetizione è "Forever", aggiungi l'intervallo di ripetizione
                if (schedule.RepeatBehavior == RepeatBehavior.Forever)
                {
                    return lastTreatmentDate.Add(schedule.RepeatInterval.Value);
                }
                // Se il comportamento di ripetizione è "Limited" e ci sono ripetizioni rimanenti
                else if (schedule.RepeatBehavior == RepeatBehavior.Limited)
                {
                    if (schedule.Repetitions > 0)
                    {
                        // Decrementa il numero di ripetizioni (probabilmente sarebbe da fare in un contesto di aggiornamento)
                        schedule.Repetitions--;
                        return lastTreatmentDate.Add(schedule.RepeatInterval.Value);
                    }
                }
            }

            // Se non c'è un comportamento di ripetizione o intervallo, ritorna la data di inizio
            return schedule.StartDate;
        }
    }
}
