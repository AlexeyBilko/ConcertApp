using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcertApp.BLL.Services;
using ConcertApp.DAL;
using ConcertApp.DAL.Context;
using ConcertApp.DAL.Repositories;
using Ninject.Modules;

namespace ConcertApp.BLL.Modules
{
    public class ConcertDBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ConcertContext>();

            Bind<IRepository<Users>>().To<UsersRepository>();
            Bind<UserService>().To<UserService>();

            Bind<IRepository<Admins>>().To<AdminsRepository>();
            Bind<AdminService>().To<AdminService>();

            Bind<IRepository<Concerts>>().To<ConcertsRepository>();
            Bind<ConcertService>().To<ConcertService>();

            Bind<IRepository<CreditCards>>().To<CreditCardsRepository>();
            Bind<CreditCardService>().To<CreditCardService>();

            Bind<IRepository<Tickets>>().To<TicketsRepository>();
            Bind<TicketService>().To<TicketService>();
        }
    }
}
