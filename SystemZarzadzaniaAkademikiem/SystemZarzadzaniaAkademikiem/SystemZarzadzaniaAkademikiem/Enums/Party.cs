using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Party
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Nie chodze/bardzo rzadko")]
        VeryRare,
        [Display(Description = "1 raz w tygodniu")]
        Rare,
        [Display(Description = "3-4 razy w tygodniu")]
        Often,
        [Display(Description = "ponad 5 razy w tygodniu")]
        VeryOften
    }
}
