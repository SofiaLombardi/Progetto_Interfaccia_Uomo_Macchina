using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Flower_App_copia_1.Data
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ClienteId { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Cognome")]
        public string Cognome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data di Nascita")]
        public DateTime? DataNascita { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefono")]
        public string Telefono
        {
            get; set;
        }

        [NotMapped]
        [DisplayName("Nome completo cliente")]
        public string FullName => $"{Nome} {Cognome}";

        // Foreign Key for IdentityUser
        [Required]
        [DisplayName("User ID")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        // Relazione molti-a-molti con Pianta
        public ICollection<ClientePianta> ClientePiante { get; set; }
    }


}
