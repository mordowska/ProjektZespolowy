using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Sex
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Mężczyzna")]
        Man,
        [Display(Description = "Kobieta")]
        Woman
    }
}
