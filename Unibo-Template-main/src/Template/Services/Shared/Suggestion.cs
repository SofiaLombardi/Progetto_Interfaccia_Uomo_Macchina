using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template.Services.Shared
{
    public class Suggestion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Description")]
        public string Description { get; set; }

        //FK obbligatoria → Ogni Suggestion DEVE avere una Pianta associata
        [Required]
        public Guid PlantId { get; set; }

    }

}
