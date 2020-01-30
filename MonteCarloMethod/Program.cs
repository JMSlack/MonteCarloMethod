
using System;

namespace MonteCarloMethod
{   class NegativeNumberException : Exception
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            var maxIters = 0;
            var validInput = false;
            do
            {
                try
                {
                    Console.Write("Enter Number of Iterations: ");
                    maxIters = int.Parse(Console.ReadLine());
                    if (maxIters > 0)
                    {
                        validInput = true;
                    }
                    else
                    {
                        throw new NegativeNumberException(); 
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid Input");
                }
                catch (NegativeNumberException ex)
                {
                    Console.WriteLine("No Negative Numbers");
                }
            

            } while (!validInput);

 
            RunEngine(maxIters);

        }

        private static void RunEngine(int maxIters)
        {
            int counter = 0;
            int iteration = 0;
            bool done = false;

            var rng = new Random();
            double dartX = 0;
            double dartY = 0;

            var coordinates = (dartX, dartY);

            do
            {
                iteration = nextIterate(iteration);

                coordinates = UpdateCoordinates(coordinates, rng);
                var hypotenuse = Pythag(coordinates);

                if (hypotenuse <= 1)
                {
                    counter = nextIterate(counter);
                }
                done = iteration >= maxIters;

            } while (!done);

            double counterValue = Convert.ToDouble(counter);
            double iterationValue = Convert.ToDouble(iteration);

            double finalPi = (counterValue / iterationValue) * 4;

            Console.WriteLine(finalPi);
            Console.WriteLine(Math.Abs(Math.PI - finalPi));
        }
        static double Pythag((double dartX, double dartY) coordinates)
        {

            var hypotenuse = Math.Sqrt((Math.Pow(coordinates.dartX, 2)) + (Math.Pow(coordinates.dartY, 2)));

            return hypotenuse;
        }
        private static (double dartX, double dartY) UpdateCoordinates((double dartX, double dartY) coordinates, Random rng)
        {
            (double, double) newCoordinates;

            double dartX = rng.NextDouble();
            double dartY = rng.NextDouble();

            newCoordinates = (dartX, dartY);

            return (newCoordinates);
        }
        private static int nextIterate(int iteration)
        {
            return iteration + 1;
        }
    }
}
