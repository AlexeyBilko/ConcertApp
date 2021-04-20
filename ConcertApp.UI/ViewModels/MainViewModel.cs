
using ConcertApp.DAL.Context;
using ConcertApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.UI.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AdminsRepository repository = new AdminsRepository(new ConcertContext());
            repository.CreateOrUpdate(new DAL.Context.Admins());
        }
    }
}
