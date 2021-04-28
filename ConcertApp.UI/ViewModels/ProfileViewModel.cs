using ConcertApp.BLL.DTO;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class ProfileViewModel : BaseNotifyPropertyChanged
    {
        UserDTO user;
        public UserDTO CurrentUser 
        { 
            get=>user; 
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }

        public ProfileViewModel()
        {
            ExitCommand = new RelayCommand((param) =>
            {
                (Switcher.ContentArea as MainViewModel).CurrentTopPage = new TopBarView();
                Switcher.Switch(new ListConcertsView());
            });
            WatchingTickets = new RelayCommand((param) =>
            {
                TicketsView view = new TicketsView();
                (view.DataContext as TicketsViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(view);
            });
            GoBackCommand = new RelayCommand((param) => 
            {
                TopBarAfterLogInView view = new TopBarAfterLogInView();
                (view.DataContext as TopBarAfterLogInViewModel).CurrentUser = CurrentUser;
                (Switcher.ContentArea as MainViewModel).CurrentTopPage = view;
                ListConcertsView page = new ListConcertsView();
                ListConcertsViewModel lvm = page.DataContext as ListConcertsViewModel;
                lvm.InitUser(CurrentUser.Id);
                Switcher.Switch(page);
            });
        }

        public ICommand ExitCommand { get; private set; }
        public ICommand WatchingTickets { get; private set; }

        public ICommand GoBackCommand { get; private set; }
    }
}
