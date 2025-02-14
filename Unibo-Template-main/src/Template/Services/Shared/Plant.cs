using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Template.Services.Shared;

public class Plant
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [DisplayName("Scientific name")]
    public string ScientificName { get; set; }

    [Required]
    [DisplayName("Common name")]
    public string CommonName { get; set; }

    public string ImagePath { get; set; }

    public PlantArticle Article { get; set; }

    // Relazione 1:N - Una pianta può avere più trattamenti
    public List<Treatment> Treatments { get; set; } = new List<Treatment>();

    // Relazione 1:N - Una pianta può avere più allerte
    public List<Alert> Alerts { get; set; } = new List<Alert>();

    //Relazione 1:N con Suggestion (Una pianta può avere 0 o più consigli)
    public List<Suggestion> Suggestions { get; set; } = new List<Suggestion>();

    //Relazione 1:N con Homeinspiration (Una pianta può avere 0 o più idee per la csa)
    public List<HomeInspiration> HomeInspirations { get; set; } = new List<HomeInspiration>();

    // Relazione con UserPlant
    public List<UserPlant> UserPlants { get; set; } = new List<UserPlant>();
}
