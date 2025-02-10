using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Template.Web.Features.Home
{
    public class IndexModel : PageModel
    {
        public IEnumerable<MostSelledPlantsModel> MostSelledPlants { get; set; } = [];

        public IEnumerable<HouseFurnishingIdeasModel> HouseFurnishingIdeas { get; set; } = [];

        public IEnumerable<TreatmentsModel> Treatments { get; set; } = [];

        public IEnumerable<FunFactsModel> FunFacts { get; set; } = [];

        public void OnGet()
        {
            //populate everything :)
        }
    }

    public class MostSelledPlantsModel
    {
        public required string Name { get; set; } = string.Empty;

        public required string ImagePath { get; set; } = string.Empty;

        public required int Position { get; set; } //for carousel index - rename to Index?

        //smth else?
    }

    public class HouseFurnishingIdeasModel
    {
        public required string Title { get; set; } = string.Empty;

        public required string Room { get; set; } = string.Empty;

        public required string ShortDescription { get; set; } = string.Empty;

        public required string ImagePath { get; set; } = string.Empty;

        //data creazione? smth else?
    }

    public class TreatmentsModel
    {
        public required string Title { get; set; } = string.Empty;

        public required string ShortDescription { get; set; } = string.Empty;

        public required string ImagePath { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = new DateTime();

        public DateTime EndDate { get; set; } = new DateTime();

        public TimeSpan Duration { get; set; } = new TimeSpan();

        //what else?
    }

    public class FunFactsModel
    {
        public required string Title { get; set; } = string.Empty;

        public required string ShortDescription { get; set; } = string.Empty;

        public required string ImagePath { get; set; } = string.Empty;

        //what else?
    }
}
