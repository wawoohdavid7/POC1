using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class MainPageViewModel : BaseViewModel
    {

        public MainPageViewModel()
        {

            CardList = new List<CardListItem>
            {
                new CardListItem
                {
                    CCardNo="001",
                    ExpirationDate = new DateTime(2018,1,1),
                    IsDefault = false,
                    CardType = "MC"
                },
                new CardListItem
                {
                    CCardNo="002",
                    CardType = "VC",
                    IsDefault = true,
                    ExpirationDate = new DateTime(2018,2,2)
                },
            };
            SelectedCard = null;

            SquareRootCommand = new Command(() => 
            {
                //CardList = new List<CardListItem>
                //{
                //new CardListItem
                //{
                //    CCardNo="003",
                //    ExpirationDate = new DateTime(2018,3,3)
                //},
                //new CardListItem
                //{
                //    CCardNo="004",
                //    ExpirationDate = new DateTime(2018,4,4)
                //},
                //};


                //SelectedCard = CardList.FirstOrDefault();

                SelectedCard = null;
            });

        }

        public ICommand SquareRootCommand { get; private set; }

        private List<CardListItem> _cardList;

        public List<CardListItem> CardList
        {
            get { return _cardList; }
            set { base.Set(ref _cardList, value); }
        }

        private CardListItem _selectedCard;
        public CardListItem SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                if (value == null)
                {
                    SelectedCardIndex = -1;
                }
                base.Set(ref _selectedCard,  value);
            }
        }

        private int _selectedCardIndex;
        public int SelectedCardIndex
        {
            get { return _selectedCardIndex; }
            set
            {
                base.Set(ref _selectedCardIndex, value);
            }
        }



        private bool _isStoredSelected;

        public bool IsStoredSelected
        {
            get { return _isStoredSelected; }
            set
            {
                base.Set(ref _isStoredSelected, value);
                if (value == false)
                {
                    SelectedCard = null;
                }
                else
                {
                    SetDefaultCard();
                }
            }
        }

        private void SetDefaultCard()
        {
            SelectedCard = _cardList.Where(w => w.IsDefault == true).FirstOrDefault();
        }

        private string _cardIcon;

        public string CardIcon
        {
            get { return _cardIcon; }
            set { base.Set(ref _cardIcon, value); }
        }


    }
}
