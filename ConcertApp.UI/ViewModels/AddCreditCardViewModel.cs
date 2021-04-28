using ConcertApp.BLL.DTO;
using ConcertApp.BLL.Services;
using ConcertApp.UI.Infrastructure;
using ConcertApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConcertApp.UI.ViewModels
{
    public class AddCreditCardViewModel:BaseNotifyPropertyChanged
    {
        UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                
                NotifyPropertyChanged();
            }
        }
        CreditCardService cardService;

        CreditCardDTO card;
        public CreditCardDTO Card
        {
            get => card;
            set
            {
                card = value;
                NotifyPropertyChanged();
            }

        }
        public AddCreditCardViewModel(CreditCardService cardService)
        {
            this.cardService = cardService;
            Card = new CreditCardDTO();
            Card.ExpireDate = DateTime.Now;
            AddCardCommand = new RelayCommand((param) =>
            {
                cardService.CreateOrUpdate(Card);
                
                GoBack(new object());
            });
            GoBackCommand = new RelayCommand(GoBack);

        }
        private void GoBack(object param)
        {
            ProfileView view = new ProfileView();
            (view.DataContext as ProfileViewModel).CurrentUser = CurrentUser;
            Switcher.Switch(view);
        }

        public ICommand AddCardCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
    }
}
