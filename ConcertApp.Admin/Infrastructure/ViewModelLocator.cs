using ConcertApp.Admin.ViewModels;
using ConcertApp.BLL.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.Admin.Infrastructure
{
    public class ViewModelLocator
    {
        IKernel kernel;
        public ViewModelLocator()
        {
            kernel = new StandardKernel(new ConcertDBModule());
        }
        public ListEventViewModel ListEventViewModel => kernel.Get<ListEventViewModel>();
        public CreateEventViewModel CreateEventViewModel => kernel.Get<CreateEventViewModel>();
        public RemoveEventViewModel RemoveEventViewModel => kernel.Get<RemoveEventViewModel>();
        public BanUserViewModel BanUserViewModel => kernel.Get<BanUserViewModel>();
    }
}
