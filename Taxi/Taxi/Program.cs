using System;

namespace Taxi
{
    class Program
    {
        public static int InputCount()
        {
            Console.WriteLine("Введите количество сотрудников");
            int result = Convert.ToInt32(Console.ReadLine());
            return result;
        }

        public static int[] InputDataInMassive(int massiveSize)
        {
            int[] result = new int[massiveSize];
            for (int i = 0; i < massiveSize; i++)
            {
                result[i] = Convert.ToInt32(Console.ReadLine());
            }
            return result;
        }
        public static void CalculateIndexes(int massiveSize, int[] massive)
        {
            for (int j = 0; j < massiveSize; j++)
            {
                massive[j] = j + 1;
            }
        }

        public static void MassiveSorting(int NumberOfWorkers, int[] DistanceTest, int[] Distance, int[] ID, int[] TaxiCostTest, int[] TaxiCost, int[] TaxiID)
        {
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                int minDistance = 100000000;
                int maxCost = -1;
                for (int j = 0; j < NumberOfWorkers; j++)
                {

                    if (DistanceTest[j] <= minDistance && DistanceTest[j] != -1)
                    {
                        minDistance = DistanceTest[j];
                        Distance[i] = minDistance;
                        ID[i] = j + 1;

                    }

                    if (maxCost < TaxiCostTest[j] && TaxiCostTest[j] != -1)
                    {
                        maxCost = TaxiCostTest[j];
                        TaxiCost[i] = maxCost;
                        TaxiID[i] = j + 1;

                    }
                }
                DistanceTest[ID[i] - 1] = -1;
                TaxiCostTest[TaxiID[i] - 1] = -1;
            }
        }

        public static void TheEnd(int NumberOfWorkers, int[] ID, int[] TaxiID)
        {
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                for (int j = 0; j < NumberOfWorkers; j++)
                {
                    if (ID[j] == i + 1)
                    {
                        Console.WriteLine(TaxiID[j]);
                    }
                }
            }
        }


        static void Main()
        {
            var NumberOfWorkers = InputCount();

            int[] Distance = new int[NumberOfWorkers];
            int[] TaxiCost = new int[NumberOfWorkers];

            Console.WriteLine("Введите дистанцию " + NumberOfWorkers + " Работников до дома через Enter");
            Distance = InputDataInMassive(NumberOfWorkers);

            Console.WriteLine("Теперь введите цену за киллометр через Enter");
            TaxiCost = InputDataInMassive(NumberOfWorkers);

            int[] DistanceTest = (int[])Distance.Clone();
            int[] TaxiCostTest = (int[])TaxiCost.Clone();
            int[] ID = new int[NumberOfWorkers];
            int[] TaxiID = new int[NumberOfWorkers];

            CalculateIndexes(NumberOfWorkers, ID);
            CalculateIndexes(NumberOfWorkers, TaxiID);

            Console.WriteLine("");

            MassiveSorting(NumberOfWorkers, DistanceTest, Distance, ID, TaxiCostTest, TaxiCost, TaxiID);

            TheEnd(NumberOfWorkers, ID, TaxiID);
        }
    }
}