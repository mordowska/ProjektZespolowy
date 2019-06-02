using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum YesNo
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Tak")]
        Yes,
        [Display(Description = "Nie")]
        No
    }
}
