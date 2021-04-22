using ConcertApp.BLL.Modules;
using ConcertApp.UI.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.UI.Infrastructure
{
    public class ViewModelLocator
    {
        IKernel kernel;
        public ViewModelLocator()
        {
            kernel = new StandardKernel(new ConcertDBModule());
        }

        public LogInAppViewModel LogInViewModel => kernel.Get<LogInAppViewModel>();
    }
}
