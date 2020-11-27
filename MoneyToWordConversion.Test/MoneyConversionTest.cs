using MoneyToWordConversion.Interfaces;
using MoneyToWordConversion.Models;
using Xunit;

namespace MoneyToWordConversion.Test
{
    public class MoneyConversionTest
    {
        private MoneyConversionFactory _moneyConversionFactory;
        private IMoneyConversion _moneyConversion = new MoneyConversion();
        public MoneyConversionTest()
        {
            _moneyConversionFactory = new MoneyConversionFactory(_moneyConversion);
        }

        [Theory]
        [InlineData(-100.00, "Invalid money")]
        [InlineData(0, "Invalid money")]
        [InlineData(1000000000.00, "Invalid money")]
        [InlineData(3.2, "Three Dollar and Twenty Cents")]
        [InlineData(23.23, "Twenty Three Dollar and Twenty Three Cents")]
        [InlineData(1.15, "One Dollar and Fifteen Cents")]
        [InlineData(123.78, "One Hundred Twenty Three Dollar and Seventy Eight Cents")]
        [InlineData(999.99, "Nine Hundred Ninety Nine Dollar and Ninety Nine Cents")]
        [InlineData(100.00, "One Hundred Dollar and Zero Cents")]
        [InlineData(100, "One Hundred Dollar and Zero Cents")]
        [InlineData(10, "Ten Dollar and Zero Cents")]
        [InlineData(15.22, "Fifteen Dollar and Twenty Two Cents")]
        [InlineData(1000.22, "One Thousand Dollar and Twenty Two Cents")]
        [InlineData(1203.22, "One Thousand Two Hundred Three Dollar and Twenty Two Cents")]
        [InlineData(9999.32, "Nine Thousand Nine Hundred Ninety Nine Dollar and Thirty Two Cents")]
        [InlineData(10000.32, "Ten Thousand Dollar and Thirty Two Cents")]
        [InlineData(10011.32, "Ten Thousand Eleven Dollar and Thirty Two Cents")]
        [InlineData(99999.32, "Ninety Nine Thousand Nine Hundred Ninety Nine Dollar and Thirty Two Cents")]
        [InlineData(100000.32, "One Hundred Thousand Dollar and Thirty Two Cents")]
        [InlineData(230005.00, "Two Hundred Thirty Thousand Five Dollar and Zero Cents")]
        [InlineData(999999.99, "Nine Hundred Ninety Nine Thousand Nine Hundred Ninety Nine Dollar and Ninety Nine Cents")]
        [InlineData(1000000.99, "One Million Dollar and Ninety Nine Cents")]
        [InlineData(22000000.99, "Twenty Two Million Dollar and Ninety Nine Cents")]
        [InlineData(122000000.99, "One Hundred Twenty Two Million Dollar and Ninety Nine Cents")]
        [InlineData(122000001.99, "One Hundred Twenty Two Million One Dollar and Ninety Nine Cents")]
        public void MoneyConversionTest_PerformCorrectly(double number, string moneyInWords)
        {
            string result = _moneyConversionFactory.ConvertMoneyToWords(number);
            Assert.Equal(moneyInWords, result);
        }
    }
}
