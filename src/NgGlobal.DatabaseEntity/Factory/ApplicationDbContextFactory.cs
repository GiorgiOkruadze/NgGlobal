using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NgGlobal.DatabaseEntity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseEntity.Factory
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=tcp:ngglobaldb.database.windows.net,1433;Initial Catalog=ngglobal;Persist Security Info=False;User ID=ngglobal;Password=Labolggn!@12;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;Connection Timeout=330;");

            return new ApplicationDbContext(options.Options);
        }
    }
}
