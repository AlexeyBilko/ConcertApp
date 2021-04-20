using ConcertApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.DAL.Repositories
{
    public class UsersRepository : GenericRepository<Users>
    {
        public UsersRepository(DbContext db) : base(db)
        {
        }
    }
}
