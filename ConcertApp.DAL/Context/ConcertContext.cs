using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.DAL.Context
{
    class ConcertContext:DbContext
    {
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Concerts> Concerts { get; set; }
        public DbSet<CreditCards> Cards { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Users> Users { get; set; }

        public ConcertContext():base("name=ConcertContext")
        {

        }
    }
}
