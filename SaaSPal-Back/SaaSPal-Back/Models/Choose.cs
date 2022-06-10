using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaaSPal_Back.Models
{
    public class Choose
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
