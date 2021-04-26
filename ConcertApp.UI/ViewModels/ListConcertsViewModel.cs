using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using ConcertApp.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class ListConcertsViewModel:BaseNotifyPropertyChanged
    {
        ObservableCollection<ConcertDTO> concerts;
        public ObservableCollection<ConcertDTO> Concerts 
        { 
            get=>concerts; 
            
            set
            {
                concerts = value;
                NotifyPropertyChanged();
            }
        }
        ConcertService concertService;

        public ConcertDTO SelectedConcert { get; set; }
        public ListConcertsViewModel(ConcertService service)
        {
            concertService = service;
            Concerts = new ObservableCollection<ConcertDTO>(concertService.GetAll());
            CreateCommands();
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

        private void CreateCommands()
        {
            GetConcertsCommand = new RelayCommand((param) => {

                Concerts = new ObservableCollection<ConcertDTO>(
                    
                    concertService.GetAll().Where((concert)=> 
                    { 
                        return concert.TypeOfEvent == "Concert"; 
                    })
                 
                 );
            });
            GetTheatreCommand = new RelayCommand((param) =>
            {
                Concerts = new ObservableCollection<ConcertDTO>(

                   concertService.GetAll().Where((concert) =>
                   {
                       return concert.TypeOfEvent == "Theatre";
                   })

                );
            });
            GetFestivalsCommand = new RelayCommand((param) => {

                Concerts = new ObservableCollection<ConcertDTO>(

                   concertService.GetAll().Where((concert) =>
                   {
                       return concert.TypeOfEvent == "Festival";
                   })

                );
            });

            GetHumorCommand = new RelayCommand((param) => {

                Concerts = new ObservableCollection<ConcertDTO>(

                   concertService.GetAll().Where((concert) =>
                   {
                       return concert.TypeOfEvent == "Humor";
                   })

                );
            });

        }

        public ICommand GetConcertsCommand { get;private set; }
        public ICommand GetTheatreCommand { get; private set; }
        public ICommand GetFestivalsCommand { get; private set; }
        public ICommand GetHumorCommand { get; private set; }

    }
}
