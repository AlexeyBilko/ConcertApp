using ConcertApp.BLL.DTO;
using ConcertApp.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
