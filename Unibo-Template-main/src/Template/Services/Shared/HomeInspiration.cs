﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Services.Shared
{

    public class HomeInspiration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }


        [Required]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        //FK obbligatoria → Ogni HomeInspiration DEVE avere una Pianta associata
        [Required]
        public Guid PlantId { get; set; }
    }
}