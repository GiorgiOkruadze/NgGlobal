using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class User:IdentityUser<int>
    {
        public List<Car> Cars { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
