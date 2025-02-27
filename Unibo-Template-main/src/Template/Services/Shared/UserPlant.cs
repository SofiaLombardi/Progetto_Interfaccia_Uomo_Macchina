using System;
using System.ComponentModel.DataAnnotations;


namespace Template.Services.Shared
{
    public class UserPlant
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Guid PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
