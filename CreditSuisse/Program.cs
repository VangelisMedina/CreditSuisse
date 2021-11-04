using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditSuisse
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime? referenceDate = null;
            uint numberTrades = 0;
            List<Trade> trades = new List<Trade>();
            bool validation = false;
            
            while(validation == false)
            {
                Console.WriteLine("Reference date (mm/dd/yyyy):");
                var referenceDateInput = Console.ReadLine();
                DateTime aux;
                if (DateTime.TryParse(referenceDateInput, new CultureInfo("en-US"), DateTimeStyles.None, out aux))
                {
                    validation = true;
                    referenceDate = aux;
                }
                else
                    Console.WriteLine("Invalid date.");               
            }

            validation = false;
            while (validation == false)
            {
                Console.WriteLine("Number of trades:");
                var numberTradesInput = Console.ReadLine();               

                if (UInt32.TryParse(numberTradesInput, out numberTrades) && numberTrades > 0)
                    validation = true;
                else
                    Console.WriteLine("Invalid number, must be integer great than 0.");
            }

            for (int i = 1; i <= numberTrades; i++)
            {
                validation = false;
                while (validation == false)
                {
                    Console.WriteLine(i + " - Trade amount, Client’s sector, Next pending payment:");
                    var tradesInput = Console.ReadLine();

                    var tradesInputArray = tradesInput.Split(' ');
                    if(tradesInputArray.Length != 3)
                        Console.WriteLine(i + " Invalid trade format.");                   
                    else
                    {
                        Double value;
                        bool valueValid = Double.TryParse(tradesInputArray[0], out value);
                        if(valueValid == false)
                            Console.WriteLine(i + " Invalid value.");

                        String clientSector = tradesInputArray[1];
                        bool clientSectorValid = clientSector.ToLower().Equals("private") || clientSector.ToLower().Equals("public");
                        if (clientSectorValid == false)
                            Console.WriteLine(i + " Invalid client sector.");

                        DateTime paymentDate;
                        bool paymentDateValid = DateTime.TryParse(tradesInputArray[2], new CultureInfo("en-US"), DateTimeStyles.None, out paymentDate);
                        if (paymentDateValid == false)
                            Console.WriteLine(i + " Invalid payment date.");

                        if (valueValid && clientSectorValid && paymentDateValid)
                        {
                            validation = true;
                            trades.Add(new Trade(value, clientSector, paymentDate));
                        }
                    }
                }
            }

            foreach (var trade in trades)
            {
                Console.WriteLine(trade.GetCategory(referenceDate.Value));
            }

           
        }
    }
}
