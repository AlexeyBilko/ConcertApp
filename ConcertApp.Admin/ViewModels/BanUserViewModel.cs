using ConcertApp.Admin.Infrastructure;
using ConcertApp.Admin.Views;
using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.Admin.ViewModels
{
    public class BanUserViewModel
    {
        public string ErrorText { get; set; }
        TicketService tService;
        UserService uService;

        public ObservableCollection<UserDTO> Users { get; set; }

        public UserDTO SelectedUser { get; set; }

        public BanUserViewModel(TicketService serviceT, UserService serviceU)
        {
            tService = serviceT;
            uService = serviceU;
            Users = new ObservableCollection<UserDTO>(uService.GetAll());

            DeleteUserCommand = new RelayCommand(x =>
            {
                int b = 0;
                foreach (var i in tService.GetAll())
                {
                    if (i.UserId == SelectedUser.Id)
                    {
                        b++;
                    }
                }
                if (b == 0)
                {
                    ErrorText = "";
                    uService.Delete(SelectedUser);
                }
                else
                {
                    ErrorText = "Нельзя забанить. Имеются билеты с указанным пользователем";
                }
                Switcher.Switch(new ListEventView());
            });
        }

        public ICommand DeleteUserCommand { get; private set; }
    }
}
