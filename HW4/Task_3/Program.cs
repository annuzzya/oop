using System.Globalization;

namespace Task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Converter converter = new Converter(41.66m, 48.22m);

            Console.WriteLine("Currency Converter");
            Console.WriteLine($"Current rates: 1 USD = {converter.USDrate} UAH, 1 EUR = {converter.EURrate} UAH");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Convert UAH to USD");
                Console.WriteLine("2. Convert USD to UAH");
                Console.WriteLine("3. Convert UAH to EUR");
                Console.WriteLine("4. Convert EUR to UAH");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformConversion("UAH", "USD", converter.ConvertUahToUsd);
                        break;
                    case "2":
                        PerformConversion("USD", "UAH", converter.ConvertUsdToUah);
                        break;
                    case "3":
                        PerformConversion("UAH", "EUR", converter.ConvertUahToEur);
                        break;
                    case "4":
                        PerformConversion("EUR", "UAH", converter.ConvertEurToUah);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            }
        }

        static void PerformConversion(string fromCurrency, string toCurrency, Func<decimal, decimal> conversionLogic)
        {
            Console.Write($"Enter amount in {fromCurrency}: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal amount))
            {
                if (amount < 0)
                {
                    Console.WriteLine("Impossible to change a negative amount");
                }
                else
                {
                    decimal result = conversionLogic(amount);
                    Console.WriteLine($"Result: {amount:0.00} {fromCurrency} = {result:0.00} {toCurrency}");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a valid number");
            }
        }
    }
}
