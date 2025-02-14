using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
