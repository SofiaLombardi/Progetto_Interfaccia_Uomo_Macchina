using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Services.Shared
{
    public class Suggestion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        //FK obbligatoria → Ogni Suggestion DEVE avere una Pianta associata
        [Required]
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }
    }

}
