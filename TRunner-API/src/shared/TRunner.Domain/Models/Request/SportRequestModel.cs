using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRunner.Domain.Models.Request
{
    public class SportRequestModel
    {
        public string SportImage { get; set; }
        public string SportName { get; set; }
        public string SportType { get; set; }
        public bool? IsActive { get; set; }
    }
}
