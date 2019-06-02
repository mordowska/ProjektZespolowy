using System.ComponentModel.DataAnnotations;
namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum Music
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Słuchawki")]
        Headphones,
        [Display(Description = "Głośniki")]
        Speakers
    }
}
