using Drysdale.String.Manipulation;
using System;

namespace quick_console_ui_tester
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            string code = "Drysdale Chivhanga";

            Console.WriteLine(StringManip.GetGetRandomLetter(CharactorCase.Lower));
        }
    }
}
