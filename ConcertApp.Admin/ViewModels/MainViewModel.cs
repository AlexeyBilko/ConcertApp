using ConcertApp.Admin.Infrastructure;
using ConcertApp.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConcertApp.Admin.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        public string ErrorText { get; set; }
        
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

        public MainViewModel()
        {
            CurrentPage = new ListEventView();
            Switcher.ContentArea = this;
            InitCommands();
        }

        public void Navigate(UserControl page)
        {
            CurrentPage = page;
            ErrorText = "";
        }

        private void InitCommands()
        {
            CreateConcertCommand = new RelayCommand((x) =>
            {
                Switcher.Switch(new CreateEventView());
            });
            UpdateConcertCommand = new RelayCommand((x) =>
            {
                if (CurrentPage.DataContext is ListEventViewModel vm)
                {
                    try
                    {
                        CreateEventView page = new CreateEventView();
                        CreateEventViewModel cevm = page.DataContext as CreateEventViewModel;
                        cevm.SetConcertToEdit(vm.SelectedConcert.Id);
                        Switcher.Switch(page);
                    }
                    catch{ }
                }
            });
            RemoveConcertCommand = new RelayCommand((x) =>
            {
                Switcher.Switch(new RemoveEventView());
            });
            ListEventCommand = new RelayCommand((x) =>
            {
                Switcher.Switch(new ListEventView());
            });
            BanUserCommand = new RelayCommand((x) =>
            {
                Switcher.Switch(new BanUserView());
            });
        }
        public ICommand ListEventCommand { get; private set; }

        public ICommand CreateConcertCommand { get; private set; }

        public ICommand UpdateConcertCommand { get; private set; }

        public ICommand RemoveConcertCommand { get; private set; }

        public ICommand BanUserCommand { get; private set; }
    }
}
