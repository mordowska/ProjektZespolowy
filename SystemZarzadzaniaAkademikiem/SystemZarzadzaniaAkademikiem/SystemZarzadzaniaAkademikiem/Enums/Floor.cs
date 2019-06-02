using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Floor
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Pierwsze")]
        First,
        [Display(Description = "Drugie")]
        Second,
        [Display(Description = "Trzecie")]
        Third,
        [Display(Description = "Czwarte")]
        Fourth
    }

}
