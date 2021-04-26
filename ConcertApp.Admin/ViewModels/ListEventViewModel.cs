using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertApp.Admin.ViewModels
{
    public class ListEventViewModel
    {
        ConcertService concertService;
        public ObservableCollection<ConcertDTO> Concerts { get; set; }

        public ConcertDTO SelectedConcert { get; set; }

        public ListEventViewModel(ConcertService service)
        {
            concertService = service;
            Concerts = new ObservableCollection<ConcertDTO>(concertService.GetAll());
        }
    }
}
