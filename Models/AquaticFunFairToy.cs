using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class AquaticFunFairToy
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public int NumberOfPedalBoats { get; set; }

    [StringLength(3)]
    public string NumberOfFountains { get; set; }

    [StringLength(3)]
    public string NumberOfSlides { get; set; }

    public Lavatory() {}

    public Lavatory(int id, string localization, int numberOfPedalBoats, string numberOfFountains, string numberOfSlides)
    {
        Id = id;
        Localization = localization;
        NumberOfPedalBoats = numberOfPedalBoats;
        NumberOfFountains = numberOfFountains;
        NumberOfSlides = numberOfSlides;
    }
}