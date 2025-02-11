using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Template.Services.Shared
{
    public class PlantArticle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid PlantId { get; set; } //FK: see dbContext

        public Plant Plant { get; set; } //see dbContext -> is it really necessary?

        public PlantArticleSections Content { get; set; }

        public PlantCard Card { get; set; }
    }

    public class PlantArticleSections
    {
        public string Description { get; set; }

        public string Toxicity { get; set; }

        public string LightExposure { get; set; }

        public string Climate { get; set; }

        public string Irrigation { get; set; }

        public string Flowering { get; set; }

        public string FlowerColours { get; set; }

        public string PlantingAndTerrain { get; set; }

        public string Trimming { get; set; }

        public string Manuring { get; set; }
    }

    public class PlantCard
    {
        public ToxicityLevelDescription Toxicity { get; set; }

        public LightExposureLevels LightExposure { get; set; }

        public EnvironmentOptions Environment { get; set; }

        public IrrigationLevels Irrigation { get; set; }

        public MonthsPeriod FloweringTime { get; set; }

        public IEnumerable<string> FloweringColours { get; set; } //could become an enum or smth else maybe

        public TerrainOptions Terrain { get; set; }

        public MonthsPeriod TrimmingTime { get; set; }

        public MonthsPeriod ManuringTime { get; set; }
    }

    public class ToxicityLevelDescription
    {
        public bool IsPoisonous { get; set; }

        public bool IsPetSafe { get; set; }

        public bool IsBabySafe { get; set; }

        public bool IsEdible { get; set; }

        public string ShortDescription { get; set; }
    }

    public class MonthsPeriod
    {
        public Months Start { get; set; }

        public Months End { get; set; }
    }

    public enum LightExposureLevels
    {
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
