using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Floor
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Pierwsza")]
        First,
        [Display(Description = "Druga")]
        Second,
        [Display(Description = "Trzecia")]
        Third,
        [Display(Description = "Czwarta")]
        Fourth
    }

}
