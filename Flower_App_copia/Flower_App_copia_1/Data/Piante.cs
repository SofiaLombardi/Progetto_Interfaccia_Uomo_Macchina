using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_App_copia_1.Data
{
    public class Piante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string IdPianta { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Nome Scientifico")]
        public string NomeScientifico { get; set; }

        [Required]
        [DisplayName("Descrizione")]
        public string Descrizione { get; set; }

        [Required]
        public byte[] FotoPianta { get; set; } // Sofi: Possiamo usare byte oppure anche Blob(non l'ho mai usato ma mi hanno detto che in genere si usa per le foto)

        [Required]
        public EsposizioneSolare Esposizione { get; set; }

        public enum EsposizioneSolare { Ombra, Sole, Penombra }

        [Required]
        [DisplayName("Descrizione Esposizione")]
        public string DescrizioneEsposizione { get; set; }

        [Required]
        [DisplayName("Tipologia Terreno")]
        public TipologiaTerreno Terreno { get; set; }

        public enum TipologiaTerreno { ArgillosoPesante, Sabbioso, Limoso }

        [Required]
        public PesantezzaTerreno PesantezzaDelTerreno { get; set; }

        public enum PesantezzaTerreno { Soffice, Medio, Pesante }

        [Required]
        public PhTerreno AciditàTerreno { get; set; }

        public enum PhTerreno { Acido, Alcalino, Neutro }

        [Required]
        [DisplayName("Descrizione Terreno")]
        public string DescrizioneTerreno { get; set; }

        [Required]
        [DisplayName("Fioritura")]
        public DateTime Fioritura { get; set; }

        [Required]
        [DisplayName("Descrizione Fioritura")]
        public string DescrizioneFioritura { get; set; }

        [Required]
        [DisplayName("Irrigazione")]
        public Annaffiatura Irrigazione { get; set; }

        public enum Annaffiatura { Leggera, Media, Abbondante }

        [Required]
        [DisplayName("Descrizione irrigazione")]
        public string DescrizioneIrrigazione { get; set; }

        [Required]
        public Concimazione Concime { get; set; }

        public enum Concimazione { Inverno, Autunno, Primavera, Estate }

        [Required]
        [DisplayName("Descrizione Concimazione")]
        public string DescrizioneConcimazione { get; set; }


        [Required]
        [DisplayName("Potatura")]
        public DateTime Potatura { get; set; }


        [Required]
        [DisplayName("Descrizione Potatura")]
        public string DescrizionePotatura { get; set; }


        [Required]
        [DisplayName("Ambiente")]
        public bool Ambiente { get; set; }


        [Required]
        [DisplayName("Descrizione ambiente")]
        public string DescrizioneAmbiente { get; set; }

        [Required]
        [DisplayName("Idee casa Id")]
        public string IdeeCasaId { get; set; }
        public IdeeCasa IdeeCasa { get; set; }

        [Required]
        [DisplayName("Consigli  Id")]
        public string ConsigliId { get; set; }
        public Consigli Consigli { get; set; }


        // Foreign Key for IdentityUser
        [Required]
        [DisplayName("User ID")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}