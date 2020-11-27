using MoneyToWordConversion.Interfaces;
using System;

namespace MoneyToWordConversion.Models
{
    /*
    This is the class extracts the money and split it and get the 
    dollar string and cents string separately and combine and 
    send back to the caller. Validates the input money here and 
    converts to words only valid money
    */
    public class MoneyConversionFactory
    {
        private readonly IMoneyConversion _moneyConversion;
        public MoneyConversionFactory(IMoneyConversion moneyConversion)
        {
            _moneyConversion = moneyConversion;
        }

        public string ConvertMoneyToWords(double money)
        {
            int splitValue = (int)money;
            int decimalValue = (int)(Math.Round((money - splitValue) * 100, 2));
            decimalValue = decimalValue < 10 ? decimalValue * 10 : decimalValue;

            if (!isValidMoney(money)) return "Invalid money";

            string dollerAmount = _moneyConversion.ConvertMoneyIntoWords(splitValue);
            string centsAmount = _moneyConversion.ConvertMoneyIntoWords(decimalValue);

            return String.Format("{0} Dollar and {1} Cents", dollerAmount.Trim(), centsAmount.Trim());
        }

        private bool isValidMoney(double money)
        {
            return money > 0 && money < 1000000000.00;
        }
    }
}
