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
    public class TopBarViewModel : BaseNotifyPropertyChanged
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

        public TopBarViewModel()
        {
            InitCommands();
        }

        public void InitCommands()
        {
            LogInCommand = new RelayCommand((param) => {
                Switcher.Switch(new LogInAppView());
            });
        }

        public ICommand LogInCommand { get; private set; }
    }
}
