using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using ConcertApp.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class CreateTicketViewModel:BaseNotifyPropertyChanged
    {
       
        private ConcertDTO selected;
        public ConcertDTO SelectedConcert
        {
            get => selected;
            set
            {
                selected = value;
                NotifyPropertyChanged();
            }
        }
        TicketService service;

        private string type;
        public string TypeOfTicket
        {
            get => type;
            set
            {
                type = value;
                NotifyPropertyChanged();
            }
        }

        private int row;
        public int Row
        {
            get => row;
            set
            {
                row = value;
                NotifyPropertyChanged();
            }
        }

        private int place;
        public int Place
        {
            get => place;
            set
            {
                place = value;
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

        public CreateTicketViewModel(TicketService s)
        {
            service = s;

            ConfirmCommand = new RelayCommand(x =>
            {
                TicketDTO tmp = new TicketDTO();
                tmp.ConcertId = SelectedConcert.Id;
                tmp.UserId = SelectedBankUser.Id;
                tmp.Row = this.Row;
                tmp.Place = this.Place;
                tmp.Type = this.TypeOfTicket;
                if (tmp.Type == "VIP")
                {
                    tmp.Price = 1000;
                }
                else
                    tmp.Price = 600;
            
                service.CreateOrUpdate(tmp);
            });
        }

        public ICommand ConfirmCommand { get; private set; }
    }
}
