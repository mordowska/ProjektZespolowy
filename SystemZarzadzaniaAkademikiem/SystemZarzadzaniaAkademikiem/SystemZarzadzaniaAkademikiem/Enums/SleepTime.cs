using System.ComponentModel.DataAnnotations;


namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum SleepTime
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Przed 22.30")]
        Early,
        [Display(Description = "22.30-24")]
        Normal,
        [Display(Description = "Po 24")]
        Late
    }
}
