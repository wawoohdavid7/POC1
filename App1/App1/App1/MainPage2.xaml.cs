using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class MainPage2 : ContentPage
    {
        public MainPage2()
        {
            InitializeComponent();
            var vm = new MainPageViewModel2();

            foreach (var card in vm.CardList)
            {
                CardPicker.Items.Add(card.DisplayText);
            }
            BindingContext = vm;
            //CardPicker.SelectedIndexChanged += CardPicker_SelectedIndexChanged;

            //var CardList = new List<CardListItem>
            //{
            //    new CardListItem
            //    {
            //        CCardNo="001",
            //        ExpirationDate = new DateTime(2018,1,1),
            //        IsDefault = false,
            //        CardType = "MC"
            //    },
            //    new CardListItem
            //    {
            //        CCardNo="002",
            //        CardType = "VC",
            //        IsDefault = true,
            //        ExpirationDate = new DateTime(2018,2,2)
            //    },
            //};
            //foreach (var card in CardList)
            //{
            //    CardPicker.Items.Add(card.DisplayText);
            //}
        }

        private void CardPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
