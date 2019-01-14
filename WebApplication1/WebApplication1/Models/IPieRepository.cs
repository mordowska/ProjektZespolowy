using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int Id);

        void CreatePie(Pie pie);
        IEnumerable<Pie> Pies { get; }
        void UpdatePie(Pie pie);
        void DeletePie(Pie pie);
    }
}
