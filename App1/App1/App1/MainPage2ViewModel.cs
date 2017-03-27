using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class MainPageViewModel2 : BaseViewModel
    {

        public MainPageViewModel2()
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
            SelectedCardIndex = -1;

            SquareRootCommand = new Command(async () =>
            {
                await Task.Delay(3000);
                SelectedCard = null;
            }, () => _isStoredSelected);

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
                base.Set(ref _selectedCard, value);
            }
        }

        private int _selectedCardIndex;
        public int SelectedCardIndex
        {
            get { return _selectedCardIndex; }
            set
            {
                base.Set(ref _selectedCardIndex, value);
                SetSelectedCardItem(value);
            }
        }

        private void SetSelectedCardItem(int index)
        {
            SelectedCard =  index == -1 ? null : _cardList[index];
        }


        private bool _isStoredSelected;

        public bool IsStoredSelected
        {
            get { return _isStoredSelected; }
            set
            {
                base.Set(ref _isStoredSelected, value);

                SelectedCardIndex = (value==false) ? -1: GetIndexOfDefaultCardItem();

                ((Command)SquareRootCommand).ChangeCanExecute();
            }
        }

        private int GetIndexOfDefaultCardItem()
        {
            int indx = 0;
            //foreach (var card in _cardList)
            //{
            //    indx++;
            //    if (_cardList[indx].IsDefault)
            //    {
            //        break;
            //    }
            //}

            //if (indx == _cardList.Count)
            //{
            //    indx = 0;
            //}


            for (int x = 0; x < _cardList.Count; x++)
            {
                if (_cardList[x].IsDefault)
                {
                    indx = x;
                    break;
                }
            }

            return indx;
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
