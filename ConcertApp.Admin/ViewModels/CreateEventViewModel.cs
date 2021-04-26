using ConcertApp.Admin.Infrastructure;
using ConcertApp.Admin.Views;
using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.Admin.ViewModels
{
    public class CreateEventViewModel : BaseNotifyPropertyChanged
    {
        ConcertService service;

        private ConcertDTO selectedConcert;
        public ConcertDTO SelectedConcert
        {
            get => selectedConcert;
            set
            {
                selectedConcert = value;
                NotifyPropertyChanged();
            }
        }

        public CreateEventViewModel(ConcertService serviceC)
        {
            service = serviceC;
            SelectedConcert = new ConcertDTO();

            AddConcertCommand = new RelayCommand(param =>
            {
                service.CreateOrUpdate(SelectedConcert);
                Switcher.Switch(new ListEventView());
            });
        }

        public ICommand AddConcertCommand { get; private set; }

        public void SetConcertToEdit(int id)
        {
            SelectedConcert = service.Get(id);
        }
    }
}
