using Microsoft.Extensions.DependencyInjection;
using MoneyToWordConversion.Interfaces;
using MoneyToWordConversion.Models;
using System;

namespace MoneyToWordConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            bool untilGetAValidNumber = true;
            var serviceCollection = new ServiceCollection()
                .AddSingleton<IMoneyConversion, MoneyConversion>()
                .BuildServiceProvider();

            var moneyConversion = serviceCollection.GetService<IMoneyConversion>();
            MoneyConversionFactory factory = new MoneyConversionFactory(moneyConversion);

            while (untilGetAValidNumber)
            {
                Console.WriteLine("Enter valid money ");

                try
                {
                    //var serviceCollection = new serviceCollection(); 
                    double money = double.Parse(Console.ReadLine());
                    string moneyInWords = factory.ConvertMoneyToWords(money);
    
                    Console.WriteLine("Money in words -------- {0} ", moneyInWords);

                    Console.WriteLine("Do you want to continue? Press Yes/No");

                    untilGetAValidNumber = Console.ReadLine().ToLower() == "Yes".ToLower();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} - Re-enter money ", ex.Message);
                }
            }
        }
    }
}
