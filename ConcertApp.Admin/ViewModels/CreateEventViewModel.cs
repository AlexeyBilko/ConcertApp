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
                SetTimeAndDateSettings();
                NotifyPropertyChanged();
            }
        }
        DateTime date;
        public DateTime Date 
        { 
            get=>date; 
            set
            {
                date = value;
                NotifyPropertyChanged();
            }
        }

        string time;
        public string Time 
        { 
            get=>time; 
            
            set
            {
                time = value;
                NotifyPropertyChanged();
            }
        }

        public CreateEventViewModel(ConcertService serviceC)
        {
            service = serviceC;
            SelectedConcert = new ConcertDTO();
            Date = DateTime.Now;
            Time = DateTime.Now.ToLocalTime().ToString("HH:mm");
            AddConcertCommand = new RelayCommand(param =>
            {
                try
                {
                    string[] timeFormat = Time.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    int horse = Convert.ToInt32(timeFormat[0]);
                    int minutes = Convert.ToInt32(timeFormat[1]);
                    SelectedConcert.StartTime = new DateTime(Date.Year, Date.Month, Date.Day, horse, minutes, 0);
                    service.CreateOrUpdate(SelectedConcert);
                }
                catch { }
                Switcher.Switch(new ListEventView());
            });
        }
        private void SetTimeAndDateSettings()
        {
            if(SelectedConcert.StartTime!=null)
            {
                DateTime dateTime = (DateTime)SelectedConcert.StartTime;
                Time = dateTime.ToString("HH:mm");
                Date = dateTime;
            }
        }

        public ICommand AddConcertCommand { get; private set; }

        public void SetConcertToEdit(int id)
        {
            SelectedConcert = service.Get(id);
        }
    }
}
