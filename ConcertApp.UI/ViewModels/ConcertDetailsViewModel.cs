using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class ConcertDetailsViewModel : BaseNotifyPropertyChanged
    {
        private UserDTO selectedUser;

        public UserDTO SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                NotifyPropertyChanged();
            }
        }

        private ConcertDTO selectedEvent;
        public ConcertDTO SelectedEvent
        {
            get => selectedEvent;
            set
            {
                selectedEvent = value;
                NotifyPropertyChanged();
            }
        }

        public ConcertService ConcertService;
        public UserService userService;
        
        public ConcertDetailsViewModel(ConcertService cs, UserService us)
        {
            ConcertService = cs;
            userService = us;
            InitCommands();
        }

        public void InitCommands()
        {
            BackCommand = new RelayCommand((param) =>
            {
                if(SelectedUser == null)
                    Switcher.Switch(new ListConcertsView());
                else
                {
                    ListConcertsView page = new ListConcertsView();
                    ListConcertsViewModel vm = page.DataContext as ListConcertsViewModel;
                    vm.InitUser(SelectedUser.Id);
                    Switcher.Switch(page);
                }
            });
            OrderCommand = new RelayCommand((x) =>
            {
                if (SelectedUser == null)
                {
                    Switcher.Switch(new LogInAppView());
                }
                else
                {
                    CreateTicketView page = new CreateTicketView();
                    CreateTicketViewModel ctvm = page.DataContext as CreateTicketViewModel;
                    ctvm.SelectedConcert = SelectedEvent;
                    ctvm.SelectedUser = SelectedUser;
                    Switcher.Switch(page);
                }
            });
        }

        public void InitConcert(int id)
        {
            SelectedEvent = ConcertService.Get(id);
        }
        public void InitUser(int userId)
        {
            SelectedUser = userService.Get(userId);
        }
        public ICommand OrderCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
    }
}
