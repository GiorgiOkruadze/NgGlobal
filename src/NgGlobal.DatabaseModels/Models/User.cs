using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace NgGlobal.DatabaseModels.Models
{
    public class User:IdentityUser<int>
    {
        public List<Car> Cars { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
