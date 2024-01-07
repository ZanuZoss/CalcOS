using System;
using System.Linq;
using Sys = Cosmos.System;

namespace CalcOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();

            Console.WriteLine("CalcOS                    Version: 1.0.0");
            Console.WriteLine("Type (help) to get list of all commands.");
            Console.WriteLine(" ");
        }

        protected override void Run()
        {
            Console.Write(">> ");
            var input = Console.ReadLine();

            if (input == "about")
            {
                Console.WriteLine("CalcOS - Version 1.0.0");
                Console.WriteLine("Made by ZanuZoss");
            }
            else if (input == "clear")
            {
                Console.Clear();

                Console.WriteLine("CalcOS                    Version: 1.0.0");
                Console.WriteLine(" ");
            }
            else if (input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }
            else if (input == "reboot")
            {
                Cosmos.System.Power.Reboot();
            }
            else if (input == "help")
            {
                Console.WriteLine("Help:");
                Console.WriteLine("Examples: 2+2, 10-5, 5*9, 25/5");
                Console.WriteLine(" ");
                Console.WriteLine("about - About OS");
                Console.WriteLine("clear - clears screen");
                Console.WriteLine("shutdown - shutdowns the system");
                Console.WriteLine("reboot - reboots the system");
            }
            else
            {
                string[] elements = input.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != 2)
                {
                    Console.WriteLine("Error!");
                    return;
                }

                if (!double.TryParse(elements[0], out double First) || !double.TryParse(elements[1], out double Second))
                {
                    Console.WriteLine("Incorrect numbers in the expression!");
                    return;
                }

                char operation = input.FirstOrDefault(c => "+*-/".Contains(c));
                double result = 0;
                switch (operation)
                {
                    case '+':
                        result = First + Second;
                        break;
                    case '-':
                        result = First - Second;
                        break;
                    case '*':
                        result = First * Second;
                        break;
                    case '/':
                        if (Second != 0)
                        {
                            result = First / Second;
                        }
                        else
                        {
                            Console.WriteLine("You can't divide by zero!");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator!");
                        return;
                }
                Console.WriteLine(result);
            }
        }
    }
}
