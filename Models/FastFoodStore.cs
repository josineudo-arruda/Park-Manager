using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class FastFoodStore
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public int NumberOfFood { get; set; }

    [StringLength(3)]
    public string Veggie { get; set; }

    [StringLength(3)]
    public string Potato { get; set; }

    public FastFoodStore() {}

    public FastFoodStore(int id, string localization, int numberOfFood, string veggie, string potato)
    {
        Id = id;
        Localization = localization;
        NumberOfFood = numberOfFood;
        Veggie = veggie;
        Potato = potato;
    }
}