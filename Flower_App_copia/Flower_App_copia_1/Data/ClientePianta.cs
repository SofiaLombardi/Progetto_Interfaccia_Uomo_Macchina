using System.ComponentModel.DataAnnotations;

namespace Flower_App_copia_1.Data
{
        public class ClientePianta
        {
            [Key]
            public string ClientePiantaId { get; set; }

            [Required]
            public string ClienteId { get; set; }
            public Cliente Cliente { get; set; }

            [Required]
            public string PiantaId { get; set; }
            public Pianta Pianta { get; set; }
        }

    }

