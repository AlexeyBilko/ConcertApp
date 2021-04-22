
using ConcertApp.DAL.Context;
using ConcertApp.DAL.Repositories;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConcertApp.UI.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        private UserControl currentPage;
        public UserControl CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                NotifyPropertyChanged();
            }
        }

        public void InitCommands()
        {

        }

        public MainViewModel()
        {
            CurrentPage = new LogInAppView();
            InitCommands();
            Switcher.ContentArea = this;
        }

        public void Navigate(UserControl page)
        {
            CurrentPage = page;
        }
    }
}

