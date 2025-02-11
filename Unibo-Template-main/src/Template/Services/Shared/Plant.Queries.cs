using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Template.Services.Shared.PlantsIndexDTO;

namespace Template.Services.Shared
{
    public class PlantsIndexDTO
    {
        public IEnumerable<PlantDTO> Plants { get; set; }

        public int Count { get; set; }

        public class PlantDTO 
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string ImagePath { get; set; }
        }
    }

    public partial class SharedService
    {
        public PlantsIndexDTO Query()
        {
            var index = _dbContext.Plants.Select(x => new PlantDTO
            {
                Id = x.Id,
                Name = x.CommonName,
                ImagePath = x.ImagePath,
            })
            .ToImmutableList();

            return new PlantsIndexDTO
            {
                Plants = index,
                Count = _dbContext.Plants.Count(),
            };
        }
    }
}
