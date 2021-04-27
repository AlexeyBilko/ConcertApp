
using ConcertApp.BLL.DTO;
using ConcertApp.DAL.Context;
using ConcertApp.DAL.Repositories;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private UserControl currentTopPage;
        public UserControl CurrentTopPage
        {
            get => currentTopPage;
            set
            {
                currentTopPage = value;
                NotifyPropertyChanged();
            }
        }

        private UserDTO selectedBankUser;

        public UserDTO SelectedBankUser
        {
            get => selectedBankUser;
            set
            {
                selectedBankUser = value;
                NotifyPropertyChanged();
            }
        }



        public void InitCommands()
        {

        }

        public MainViewModel()
        {
            currentTopPage = new TopBarView();

            CurrentPage = new ListConcertsView();
            InitCommands();
            Switcher.ContentArea = this;
        }

        public MainViewModel(UserDTO bu_dto)
        {
            //CurrentPage = new TestView();

            try
            {
                Task task = new Task(() => InitCommands());
                task.Start();
            }
            catch
            {
                MessageBox.Show("Error!");
            }

            Switcher.ContentArea = this;
        }

        public void Navigate(UserControl page)
        {
            CurrentPage = page;
        }
    }
}

