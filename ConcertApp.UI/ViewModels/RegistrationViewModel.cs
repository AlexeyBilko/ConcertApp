using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class RegistrationViewModel:BaseNotifyPropertyChanged
    {
        public UserDTO NewUser { get; set; }

        string info;
        public string Info
        {
            get => info;
            set
            {
                info = value;
                NotifyPropertyChanged();
            }
        }

        UserService userService;
        public RegistrationViewModel(UserService service)
        {
            userService = service;
            NewUser = new UserDTO();
            RegistrationCommand = new RelayCommand(Registration);
            Info = "*Required fields";
            GoBackCommand = new RelayCommand((param) => { Switcher.Switch(new LogInAppView()); });
        }
        private void Registration(object param)
        {
            var passwordBox = param as PasswordBox;
            if (NewUser.Name != null)
            {
                if (NewUser.Email != null)
                {
                    if (passwordBox.Password != null)
                    {
                        if (userService.GetSameEmail(NewUser.Email) == null)
                        {
                            Switcher.Switch(new LogInAppView());
                            NewUser.Password = passwordBox.Password;
                            userService.CreateOrUpdate(NewUser);   
                        }
                        else Info = "*User with this email exists";
                    }
                    else Info = "*Enter the password";
                }
                else Info = "*Enter the email";
            }
            else Info = "*Enter the your name";
        }

        public ICommand RegistrationCommand { get; private set; }
        public ICommand GoBackCommand { get; private set; }
    }
}
