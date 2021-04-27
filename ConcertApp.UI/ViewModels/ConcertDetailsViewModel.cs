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
        
        public ConcertDetailsViewModel(ConcertService cs)
        {
            ConcertService = cs;
            InitCommands();
        }

        public void InitCommands()
        {
            BackCommand = new RelayCommand((param) =>
            {
                Switcher.Switch(new ListConcertsView());
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
                    ctvm.SelectedBankUser = SelectedUser;
                    Switcher.Switch(page);
                }
            });
        }

        public void InitConcert(int id)
        {
            SelectedEvent = ConcertService.Get(id);
        }

        public ICommand OrderCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
    }
}
