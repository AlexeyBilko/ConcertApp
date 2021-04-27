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

        public LogInAppViewModel LogInAppViewModel => kernel.Get<LogInAppViewModel>();
        public RegistrationViewModel RegistrationViewModel => kernel.Get<RegistrationViewModel>();
        public TopBarViewModel TopBarViewModel => kernel.Get<TopBarViewModel>();
        public TopBarAfterLogInViewModel TopBarAfterLogInViewModel => kernel.Get<TopBarAfterLogInViewModel>();
        public ProfileViewModel ProfileViewModel => kernel.Get<ProfileViewModel>();

        public ListConcertsViewModel ListConcertsViewModel => kernel.Get<ListConcertsViewModel>();
        public ConcertDetailsViewModel ConcertDetailsViewModel => kernel.Get<ConcertDetailsViewModel>();

        






        public TicketsViewModel TicketsViewModel => kernel.Get<TicketsViewModel>();


        public CreateTicketViewModel CreateTicketViewModel => kernel.Get<CreateTicketViewModel>();

    }
}
