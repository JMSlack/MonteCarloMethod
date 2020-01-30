
using System;

namespace MonteCarloMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxIters = 100000;
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
            Console.WriteLine(Math.PI - finalPi);
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
