using ConcertApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.DAL.Repositories
{
    public class TicketsRepository : GenericRepository<Tickets>
    {
        public TicketsRepository(DbContext db) : base(db)
        {
        }
    }
}
