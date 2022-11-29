using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class FunFairToy
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public int NumberOfCarousels { get; set; }

    public string NumberOfBumperCars { get; set; }

    public string NumberOfRollerCoasters { get; set; }

    public FunFairToy() {}

    public FunFairToy(int id, string localization, int numberOfCarousels, string numberOfBumperCars, string numberOfRollerCoasters)
    {
        Id = id;
        Localization = localization;
        numberOfCarousels = numberOfCarousels;
        numberOfBumperCars = numberOfBumperCars;
        numberOfRollerCoasters = numberOfRollerCoasters;
    }
}