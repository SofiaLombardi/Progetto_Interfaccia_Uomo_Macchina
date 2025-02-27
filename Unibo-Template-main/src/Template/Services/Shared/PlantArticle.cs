using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Template.Services.Shared
{
    public class PlantArticle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid PlantId { get; set; }


        public PlantArticleSections Content { get; set; } = new PlantArticleSections();


        public PlantCard Card { get; set; } = new PlantCard();
    }

    [Owned]
    public class PlantArticleSections
    {
        [Required]
        [Display(Name = "Plant Description")]
        public string Description { get; set; }

        [Display(Name = "Toxicity Information")]
        public string Toxicity { get; set; }

        [Display(Name = "Light Exposure")]
        public string LightExposure { get; set; }

        [Display(Name = "Environment")]
        public string Environment { get; set; }

        [Display(Name = "Plant Category")]
        public string Category { get; set; }

        [Display(Name = "Irrigation Requirements")]
        public string Irrigation { get; set; }

        [Display(Name = "Flowering Time")]
        public string Flowering { get; set; }

        [Display(Name = "Flower Colours")]
        public string FlowerColours { get; set; }

        [Display(Name = "Planting and Terrain Information")]
        public string PlantingAndTerrain { get; set; }

        [Display(Name = "Trimming Instructions")]
        public string Trimming { get; set; }

        [Display(Name = "Manuring Instructions")]
        public string Manuring { get; set; }
    }


    [Owned]
    public class PlantCard
    {
        public PlantCard()
        {
            FloweringColours = new List<string>();
        }

        [Display(Name = "Toxicity Level")]
        public ToxicityLevelDescription Toxicity { get; set; } = new ToxicityLevelDescription();

        [Display(Name = "Light Exposure Level")]
        public LightExposureLevels LightExposure { get; set; }

        [Display(Name = "Environment Type")]
        public EnvironmentOptions Environment { get; set; }

        [Display(Name = "Plant Category")]
        public PlantCategory Category { get; set; }

        [Display(Name = "Irrigation Level")]
        public IrrigationLevels Irrigation { get; set; }

        [Display(Name = "Flowering Time Period")]
        public MonthsPeriod FloweringTime { get; set; }

        [Display(Name = "Flowering Colours")]
        public ICollection<string> FloweringColours { get; set; }

        [Display(Name = "Terrain Type")]
        public TerrainOptions Terrain { get; set; }

        [Display(Name = "Trimming Time Period")]
        public MonthsPeriod TrimmingTime { get; set; }

        [Display(Name = "Manuring Time Period")]
        public MonthsPeriod ManuringTime { get; set; }
    }

    [Owned] //check
    public class ToxicityLevelDescription
    {
        [Display(Name = "Is Poisonous")]
        public bool IsPoisonous { get; set; }

        [Display(Name = "Is Pet Safe")]
        public bool IsPetSafe { get; set; }

        [Display(Name = "Is Baby Safe")]
        public bool IsBabySafe { get; set; }

        [Display(Name = "Is Edible")]
        public bool IsEdible { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
    }

    [Owned]
    public class MonthsPeriod
    {
        [Display(Name = "Start Month")]
        public Months Start { get; set; }

        [Display(Name = "End Month")]
        public Months End { get; set; }
    }

    public enum LightExposureLevels
    {
        NotSpecified = -1,
        FullSun = 0,
        HalfShadow = 1,
        Shadow = 2,
    }


    public enum EnvironmentOptions
    {

        Outdoor = 0,
        Indoor = 1,
        Everywhere = 2,
    }

    public enum PlantCategory
    {
        Flowers = 0,
        Succulents = 1,
        Trees = 2,
        Shrubs = 3
    }

    public enum IrrigationLevels
    {
        Scarce = 0,
        Medium = 1,
        Plentiful = 2,
    }

    public enum TerrainOptions
    {
        Ground = 0,
        Acid = 1,
    }

    public enum Months
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }

}
