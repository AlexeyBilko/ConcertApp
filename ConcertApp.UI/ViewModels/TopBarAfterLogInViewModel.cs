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
    public class TopBarAfterLogInViewModel: BaseNotifyPropertyChanged
    {
        private string search;
        public string Search
        {
            get => search;
            set
            {
                search = value;
                NotifyPropertyChanged();
            }
        }

        public TopBarAfterLogInViewModel()
        {
            InitCommands();
        }

        public void InitCommands()
        {
            ProfileCommand = new RelayCommand((param) => {
                //Switcher.Switch(new ProfileView());
                (Switcher.ContentArea as MainViewModel).CurrentPage = new ProfileView();
            });
        }

        public ICommand ProfileCommand { get; private set; }
    }
}
