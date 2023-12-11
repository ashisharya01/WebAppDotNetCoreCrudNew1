using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options):base(options)
        {
                
        }

        public DbSet<Client> tbl_Student1 { get; set; }
        public DbSet<Departments> tbl_Departments { get; set; }
    
    }
}
