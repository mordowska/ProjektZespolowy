using System.ComponentModel.DataAnnotations;

namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum StudyField
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Ścisły")]
        Science,
        [Display(Description = "Humanistyczny")]
        Humanities
    }
}
