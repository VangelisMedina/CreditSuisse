using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse
{
    public class ConsoleHelper
    {
        public static string GetInput(string msg)
        {
            Console.WriteLine(msg);
            var input = Console.ReadLine();
            return input;
        }
    }
}
