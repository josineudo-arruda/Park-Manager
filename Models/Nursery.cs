using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class Nursery
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Name { get; set; }

    [Required]
    public string Leitos { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public Nursery() {}

    public Nursery(int id, string name, string leitos, string localization)
    {
        Id = id;
        Name = name;
        Leitos = leitos;
        Localization = localization;
    }
}