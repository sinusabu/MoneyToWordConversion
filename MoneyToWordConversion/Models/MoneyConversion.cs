using MoneyToWordConversion.Common;
using MoneyToWordConversion.Interfaces;
using System;

namespace MoneyToWordConversion.Models
{
    /*This is the class actually converts valid money to words*/
    public class MoneyConversion : IMoneyConversion
    {
        public string ConvertMoneyIntoWords(int number)
        {
            if (number == 0)
                return String.Format("{0}", ConvertNumbersLessThanTwenty(number));

            string result = "";

            for (int i = 0; i < MoneyUtilities.Denominators.Length; i++)
            {
                int no = (int)(number / MoneyUtilities.Denominators[i]);
                number = number % MoneyUtilities.Denominators[i];

                if (no > 0)
                {
                    string denominatorString = GetMoneyString(MoneyUtilities.Denominators[i]);
                    if (no < 1000) result = String.Format("{0} {1}", result, ConvertThreeDigitNumberToWords(no) + denominatorString);
                }
            }

            if (number > 0 && number < 1000) result = String.Format("{0} {1}", result, ConvertThreeDigitNumberToWords(number));
            return result;
        }
        
        private string GetMoneyString(int multiple)
        {
            return multiple == 1000000 ? MoneyUtilities.MillionString : MoneyUtilities.ThousandString;
        }

        private string ConvertNumbersLessThanTwenty(int no)
        {
            return MoneyUtilities.NumbersToWordsUpto20[no];
        }

        private string ConvertThreeDigitNumberToWords(int originalNumber)
        {
            if (originalNumber == 0)
                return String.Format("{0}", ConvertNumbersLessThanTwenty(originalNumber));

            string result = "";
            int integerPartOfNumber = originalNumber;

            for (int i = 0; i < MoneyUtilities.HundredDenominators.Length; i++)
            {
                integerPartOfNumber = (int)(originalNumber / MoneyUtilities.HundredDenominators[i]);
                if (i == 0)
                {
                    originalNumber = originalNumber % MoneyUtilities.HundredDenominators[i];
                    if (integerPartOfNumber > 0) result = ConvertNumbersLessThanTwenty(integerPartOfNumber) + MoneyUtilities.HundredString;
                }
            }

            if (integerPartOfNumber >= 2)
            {
                result = AttachResult(result, MoneyUtilities.MultipleOfTenInWords[integerPartOfNumber - 1]); 
                originalNumber = originalNumber % MoneyUtilities.HundredDenominators[1];
            }

            if (originalNumber > 0)
                result = AttachResult(result, ConvertNumbersLessThanTwenty(originalNumber));

            return result;
        }

        private string AttachResult(string existingResult, string newValue)
        {
            return String.IsNullOrWhiteSpace(existingResult.Trim())
                ? String.Format("{0}", newValue)
                : String.Format("{0} {1}", existingResult, newValue);

        }
    }
}
