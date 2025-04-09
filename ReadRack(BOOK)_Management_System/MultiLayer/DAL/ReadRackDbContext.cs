using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadRackDbContext : DbContext
    {
        public ReadRackDbContext() : base("name=ReadRack") { }
   

         public DbSet<Book> Books { get; set; }
    }
}
