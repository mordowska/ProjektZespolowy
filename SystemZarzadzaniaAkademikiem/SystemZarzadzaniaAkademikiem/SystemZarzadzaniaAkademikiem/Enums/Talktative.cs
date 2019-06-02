using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Talkative
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Ciche")]
        Quite,
        [Display(Description = "Rozmowne")]
        Talkative
    }
}
