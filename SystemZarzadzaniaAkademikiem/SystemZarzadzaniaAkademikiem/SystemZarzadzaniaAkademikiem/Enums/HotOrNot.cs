using System.ComponentModel.DataAnnotations;
namespace SystemZarzadzaniaAkademikiem.Enums
{
    public enum HotOrNot
    {
        [Display(Description = "")]
        Empty,
        [Display(Description = "Cieplej")]
        Hot,
        [Display(Description = "Chłodniej")]
        Cold
    }
}
