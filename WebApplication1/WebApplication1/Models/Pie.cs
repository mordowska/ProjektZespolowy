using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Utility;

namespace WebApplication1.Models
{
    public class Pie
    {
        public int Id { get; set; }
        [ValidName(ErrorMessage = "Invalid name")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        //[ValidPrice(ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
        [ValidUrl(ErrorMessage = "Invalid url")]
        public string ImageUrl { get; set; }
        [ValidUrl(ErrorMessage = "Invalid url")]
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfWeek { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
