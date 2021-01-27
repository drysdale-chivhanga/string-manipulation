using Drysdale.String.Manipulation;
using System;

namespace Drysdale.QuickConsoleUiTester
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            //string code = "Drysdale Chivhanga";

           Console.WriteLine(StringManip.GetRandomAlphaNumeralString(26));
        }
    }
}
