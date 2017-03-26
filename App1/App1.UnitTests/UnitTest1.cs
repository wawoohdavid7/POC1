using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace App1.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MainPageViewModel_Initialize_SelectedCardIsNull()
        {
            var vm = new MainPageViewModel();

            Assert.AreEqual(-1, vm.SelectedCardIndex);
            Assert.AreEqual(null, vm.SelectedCard);
        }

        [TestMethod]
        public void MainPageViewModel_SelectedCardIsNull_CardIndexIsNegative1()
        {
            var vm = new MainPageViewModel();
            vm.SelectedCard = null;

            Assert.AreEqual(-1, vm.SelectedCardIndex);
        }

        [TestMethod]
        public void MainPageViewModel_IsStoredSelectedIsTrue_DefaultCardIsSelected()
        {
            var vm = new MainPageViewModel();
            vm.CardList = new List<CardListItem>
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

            vm.IsStoredSelected = true;

            Assert.AreEqual("002", vm.SelectedCard.CCardNo);
            Assert.AreEqual("VC", vm.SelectedCard.CardType);
            Assert.AreEqual(true, vm.SelectedCard.IsDefault);
            Assert.AreEqual(2018, vm.SelectedCard.ExpirationDate.Year);
            Assert.AreEqual(2, vm.SelectedCard.ExpirationDate.Month);
            Assert.AreEqual(2, vm.SelectedCard.ExpirationDate.Day);

        }

        [TestMethod]
        public void MainPageViewModel_IsStoredSelectedIsFalse_SelectedCardIsNull()
        {
            var vm = new MainPageViewModel();
            vm.CardList = new List<CardListItem>
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

            vm.IsStoredSelected = false;

            Assert.AreEqual(null, vm.SelectedCard);
            Assert.AreEqual(-1, vm.SelectedCardIndex);

        }

    }
}
