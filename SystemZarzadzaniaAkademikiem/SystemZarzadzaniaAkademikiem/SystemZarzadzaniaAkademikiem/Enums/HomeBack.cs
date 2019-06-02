using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum HomeBack
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Co weekend")]
        VeryOften,
        [Display(Description = "2 razy w miesiącu")]
        Often,
        [Display(Description = "Tylko na święta")]
        Rare,
        [Display(Description = "Nigdy nie wracam/bardzo rzadko")]
        VeryRare

    }
}
