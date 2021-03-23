using System;
using System.Linq;

namespace MyLuckyTicket
{
    class Program
    {
        static int incorecctEnterTry = 0;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Press any symbols -  check ticket number or press \"Esc\" to exit...");
          
            while (!(Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Console.Write("You ticket number:");
                string ticketNumber = Console.ReadLine();

                if (CheckTicketNumber(ticketNumber))
                {
                    if (CheckLuckyTicketNumber(ticketNumber))
                        Console.WriteLine("Congratulations, you have a lucky ticket!!!");
                    else
                        Console.WriteLine("Your ticket is not lucky, try again!");
                }
            }

            System.Environment.Exit(0);
        }

        public static bool CheckTicketNumber(string ticketNumber)
        {
            if (ticketNumber.Length > 3 && ticketNumber.Length < 9 && !ticketNumber.Any(c => char.IsLetter(c)))
            {
                incorecctEnterTry = 0;
                return true;
            }
            else if(incorecctEnterTry>2)
            {
                Console.WriteLine("Incorrect ticket number!");
                Console.WriteLine("The ticket number is a number that can be 4 to 8 digits long");
                incorecctEnterTry = 0;
                return false;
            }
            else
            {
                ++incorecctEnterTry;
                Console.WriteLine("Incorrect ticket number!");
                return false;
            }
        }

        public static bool CheckLuckyTicketNumber(string parseTicketNumber)
        {
            string firstHalfLine, secondHalfLine;

            if ((parseTicketNumber.Length & 1) != 0)
                parseTicketNumber = parseTicketNumber.Insert(0, "0");       

            firstHalfLine = parseTicketNumber.Substring(0, parseTicketNumber.Length / 2);
            secondHalfLine = parseTicketNumber.Substring(parseTicketNumber.Length / 2);

            var sumNumberFirstHalfLine = firstHalfLine.Sum(smt => char.GetNumericValue(smt));
            var sumNumberSecondHalfLine = secondHalfLine.Sum(smt => char.GetNumericValue(smt));

            if (sumNumberFirstHalfLine == sumNumberSecondHalfLine)
                return true;
            else
                return false;
        }
    }
}
