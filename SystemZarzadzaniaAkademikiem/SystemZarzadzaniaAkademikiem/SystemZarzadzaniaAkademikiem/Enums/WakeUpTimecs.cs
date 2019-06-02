using System.ComponentModel.DataAnnotations;


namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum WakeUpTime
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Przed 6.00")]
        VeryEarly,
        [Display(Description = "6.00-8.00")]
        Early,
        [Display(Description = "8.00-10.00")]
        Normal,
        [Display(Description = "10.00-12.00")]
        Late,
        [Display(Description = "Po 12.00")]
        VeryLate
    }
}
