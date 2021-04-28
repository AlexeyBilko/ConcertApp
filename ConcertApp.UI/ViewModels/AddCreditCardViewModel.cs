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
        UserService userService;

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



        public AddCreditCardViewModel(CreditCardService cardService, UserService us)
        {
            this.cardService = cardService;
            userService = us;
            Card = new CreditCardDTO();
            Card.ExpireDate = new DateTime(2022, 01, 01);
            AddCardCommand = new RelayCommand((param) =>
            {
                cardService.CreateOrUpdate(Card);
                CurrentUser.CardId = cardService.GetAll().Last().Id;
                userService.CreateOrUpdate(CurrentUser);
                GoBack(new object());
            });
            GoBackCommand = new RelayCommand(GoBack);

        }
        private void GoBack(object param)
        {
            ProfileView view = new ProfileView();
            (view.DataContext as ProfileViewModel).CurrentUser = CurrentUser;
            (view.DataContext as ProfileViewModel).CreditCard = cardService.Get((int)CurrentUser.CardId); ;
            Switcher.Switch(view);
        }

        public ICommand AddCardCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
    }
}
