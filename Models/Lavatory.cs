using System.ComponentModel.DataAnnotations;

namespace AdministracaoShrekPark.Models;

public class Lavatory
{   
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Localization { get; set; }

    public int NumberOfBooths { get; set; }

    [StringLength(3)]
    public string Mirror { get; set; }

    [StringLength(3)]
    public string ToiletPaper { get; set; }

    public Lavatory() {}

    public Lavatory(int id, string localization, int numberOfBooths, string mirror, string toiletPaper)
    {
        Id = id;
        Localization = localization;
        NumberOfBooths = numberOfBooths;
        Mirror = mirror;
        ToiletPaper = toiletPaper;
    }
}