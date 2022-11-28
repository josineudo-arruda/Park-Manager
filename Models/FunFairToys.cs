using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class FunFairToys
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public int NumberOfCarousels { get; set; }

    [StringLength(3)]
    public string NumberOfBumperCars { get; set; }

    [StringLength(3)]
    public string NumberOfRollerCoasters { get; set; }

    public Lavatory() {}

    public Lavatory(int id, string localization, int numberOfCarousels, string numberOfBumperCars, string numberOfRollerCoasters)
    {
        Id = id;
        Localization = localization;
        numberOfCarousels = numberOfCarousels;
        numberOfBumperCars = numberOfBumperCars;
        numberOfRollerCoasters = numberOfRollerCoasters;
    }
}