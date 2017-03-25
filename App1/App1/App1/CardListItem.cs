using System;

namespace App1
{
    public class CardListItem
    {
        public string CCardNo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardType { get; set; }
        public bool IsDefault { get; set; }
        public string CardIcon
        {
            get
            {
                return getCardIcon();
            }
        }
        public string DisplayText
        {
            get
            {
                return $"{CCardNo} - {ExpirationDate.ToString("MM/yy")}";
            }
        }

        private string getCardIcon()
        {
            string icon = string.Empty;
            switch (CardType)
            {
                case "MC":
                    icon = "ic_master_card.png";
                    break;
                case "VC":
                    icon = "ic_visa_card.png";
                    break;
            }

            return icon;
        }
    }
}