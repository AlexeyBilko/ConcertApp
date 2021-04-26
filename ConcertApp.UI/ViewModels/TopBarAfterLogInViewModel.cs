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
        ConcertService concertService;

        public UserDTO CurrentUser { get; set; }

        public TopBarAfterLogInViewModel(ConcertService service)
        {
            concertService = service;
            InitCommands();
        }

        public void InitCommands()
        {
            ProfileCommand = new RelayCommand((param) => {

                ProfileView view = new ProfileView();
                (view.DataContext as ProfileViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(view);
            });


            SearchCommand = new RelayCommand((param) =>
            {
                if (Search != null)
                {
                    ListConcertsView concertsView = new ListConcertsView();
                    (concertsView.DataContext as ListConcertsViewModel).Concerts = new ObservableCollection<ConcertDTO>(

                        concertService.GetAll().Where((concert) =>
                        {
                            return concert.Title.ToLower().Contains(Search.ToLower());
                        })

                     );
                    Switcher.Switch(concertsView);
                }

            });
        }

        public ICommand ProfileCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
    }
}
