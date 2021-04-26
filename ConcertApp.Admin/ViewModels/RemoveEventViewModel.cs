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
    public class RemoveEventViewModel
    {
        public string ErrorText { get; set; }
        TicketService tService;
        ConcertService cService;

        public ObservableCollection<ConcertDTO> Concerts { get; set; }

        public ConcertDTO SelectedConcert { get; set; }

        public RemoveEventViewModel(TicketService serviceT, ConcertService serviceC)
        {
            tService = serviceT;
            cService = serviceC;
            Concerts = new ObservableCollection<ConcertDTO>(cService.GetAll());

            DeleteConcertCommand = new RelayCommand(x =>
            {
                int b = 0;
                foreach(var i in tService.GetAll())
                {
                    if (i.ConcertId==SelectedConcert.Id)
                    {
                        b++;
                    }
                }
                if (b==0)
                {
                    ErrorText = "";
                    cService.Delete(SelectedConcert);
                }
                else
                {
                    ErrorText = "Нельзя удалить. Имеются билеты с указанным концертом";
                }
                Switcher.Switch(new ListEventView());
            });
        }

        public ICommand DeleteConcertCommand { get; private set; } 
    }
}
