using System;
using System.ComponentModel.DataAnnotations;


namespace Template.Services.Shared
{
    public class UserPlant
    {
        [Required]
        public Guid UserId { get; set; }
      
        [Required]
        public Guid PlantId { get; set; }
     
    }
}
