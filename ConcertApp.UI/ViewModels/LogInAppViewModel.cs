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
using System.Windows;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class LogInAppViewModel : BaseNotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get { return email; }

            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

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

        public UserService userService;
        public ObservableCollection<UserDTO> Users { get; set; }

        public LogInAppViewModel(UserService us)
        {
            userService = us;
            Users = new ObservableCollection<UserDTO>(userService.GetAll());
            InitCommands();
        }

        public void InitCommands()
        {
            LogInCommand = new RelayCommand(param =>
            {
                bool isRight = false;
                foreach (var item in Users)
                {
                    if (item.Password == Password && item.Email == Email)
                    {
                        isRight = true;
                        ListConcertsView page = new ListConcertsView();
                        ListConcertsViewModel pvm = page.DataContext as ListConcertsViewModel;
                        pvm.InitUser(item.Id);
                        (Switcher.ContentArea as MainViewModel).SelectedBankUser = item;


                        TopBarAfterLogInView view = new TopBarAfterLogInView();
                        (view.DataContext as TopBarAfterLogInViewModel).CurrentUser = item;
                        (Switcher.ContentArea as MainViewModel).CurrentTopPage = view;
                        Switcher.Switch(page);
						
                        break;
                    }
                }
                if (isRight == false)
                    MessageBox.Show("Incorrect email or password");
            });
            RegistrationCommand = new RelayCommand((param) => {
                
                Switcher.Switch(new RegistartionView()); 
            
            });
        }

        public ICommand LogInCommand { get; private set; }

        public void InitUser(int userId)
        {
            SelectedUser = userService.Get(userId);
        }

        public ICommand RegistrationCommand { get; private set; }
    }
}
