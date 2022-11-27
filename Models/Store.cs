using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class Store
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Brand { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public Store() {}

    public Store(int id, string brand, string type, string localization)
    {
        Id = id;
        Brand = brand;
        Type = type;
        Localization = localization;
    }
}