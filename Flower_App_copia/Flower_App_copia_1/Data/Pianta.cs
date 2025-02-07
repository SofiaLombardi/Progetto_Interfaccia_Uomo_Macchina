using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_App_copia_1.Data
{
    public class Pianta
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
        public string DescrizionePianta { get; set; }

        [Required]
        public byte[] FotoPianta { get; set; }

        [Required]
        [DisplayName("Colorazioni fiore")]
        public ColoreFiore Colore { get; set; }

        public enum ColoreFiore
        {
            Bianco,
            Rosso,
            Giallo,
            Arancione,
            Rosa,
            Blu,
            Viola,
            Lilla,
            Verde,
            Marrone,
            Nero,
            Misto,
            Crema,
            Lavanda,
            Indaco,
            Corallo,
            Fucsia
        }

        [Required]
        [DisplayName("Esposizione solare")]
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
        [DisplayName("Pesantezza del terreno")]
        public PesantezzaTerreno PesantezzaDelTerreno { get; set; }

        public enum PesantezzaTerreno { Soffice, Medio, Pesante }

        [Required]
        [DisplayName("acidità del Terreno")]
        public PhTerreno AciditàTerreno { get; set; }

        public enum PhTerreno { Acido, Alcalino, Neutro }

        [Required]
        [DisplayName("Descrizione Terreno")]
        public string DescrizioneTerreno { get; set; }

        [Required]
        [DisplayName("Fioritura Massima")]
        public DateTime FiorituraMassima { get; set; }
        
        [Required]
        [DisplayName("Fioritura Minima")]
        public DateTime FiorituraMinima { get; set; }

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
        [DisplayName("Periodo concimazione")]
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
        [DisplayName("Tipo Ambiente")]
        public TipoAmbiente Ambiente { get; set; }

        // Enum per Ambiente
        public enum TipoAmbiente { Interno, Esterno }


        [Required]
        [DisplayName("Descrizione ambiente")]
        public string DescrizioneAmbiente { get; set; }

        [Required]
        [DisplayName("Idee casa Id")]
        public string IdeeCasaId { get; set; }
        public IdeaCasa IdeeCasa { get; set; }

       
        [Required]
        [DisplayName("Consigli  Id")]
        public string ConsigliId { get; set; }
        public Consigli Consigli { get; set; }


        // Relazione molti-a-molti con Cliente
        public ICollection<ClientePianta> ClientePiante { get; set; }
    }

}
