using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Flower_App_copia_1.Data
{
    
        public enum TipoTossicità
        {
            NonTossico,
            TossicoPerAnimali,
            TossicoPerUmani,
            TossicoPerEntrambi
        }

        public class Tossicità
        {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string TossicitàId { get; set; }

        public TipoTossicità Tipo { get; set; }
            public bool ÈEdibile { get; set; }

            public Tossicità(TipoTossicità tipo, bool èEdibile)
            {
                Tipo = tipo;
                ÈEdibile = èEdibile;
            }

        }
    }

