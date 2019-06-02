using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum BedLocation
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Przy oknie")]
        NearWindow,
        [Display(Description = "Przy drzwiach")]
        NearDoor
    }
}
