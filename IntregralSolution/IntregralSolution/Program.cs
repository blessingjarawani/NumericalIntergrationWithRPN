using IntregralSolution.Infrastructure.Shared;
using IntregralSolution.Logic;
using System;
using System.Linq;

namespace IntregralSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string input = "";
                Console.WriteLine("Enter Equation e.g  x ^ 2 + 7 * x - 1 / x  N.B Enter X as variable");
                float lower, upper = 0;

                input = Console.ReadLine();
                //input = "1 * x ^ 2 + 7 * x - 1 / x";
                // input = "1 * x ^ 3 + 2 * x  ^ 2 + 3 * x - 4";
                while (true)
                {
                    Console.WriteLine("Enter Lower Bound");
                    var valid = float.TryParse(Console.ReadLine(), out lower);
                    if (valid) break;
                }

                while (true)
                {
                    Console.WriteLine("Enter Upper Bound");
                    var valid = float.TryParse(Console.ReadLine(), out upper);
                    if (valid) break;
                }

                input = input.Replace(" ", "");
                var trapezodial = new Trapezodial();
                var result = trapezodial.TrapezoidalIntergral(lower, upper, input.ToUpper());
                Console.WriteLine($"Intergration by Trapezoidal Method {result}");

                var simpson = new Simpson();
                result = simpson.SimpsonIntergral(lower, upper, input.ToUpper());
                Console.WriteLine($"Intergration by Simpson's Method {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
            }
        }

    }
}
