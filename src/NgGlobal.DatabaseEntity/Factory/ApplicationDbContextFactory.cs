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
                .UseSqlServer("Server=NgGlobal.mssql.somee.com;Database=NgGlobal;User Id=testStep_SQLLogin_1;password=hd5jarpp94;Trusted_Connection=false;MultipleActiveResultSets=true;");

            return new ApplicationDbContext(options.Options);
        }
    }
}
