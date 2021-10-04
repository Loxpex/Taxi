using System;

namespace Taxi
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество сотрудников");
            int NumberOfWorkers = Convert.ToInt32(Console.ReadLine());
            int[] Distance = new int[NumberOfWorkers];
            int[] TaxiCost = new int[NumberOfWorkers];
            Console.WriteLine("Введите дистанцию "+ NumberOfWorkers +" Работников до дома через Enter");
            for (int i = 0; i < NumberOfWorkers; i++)  
            {
                Distance[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Теперь введите цену за киллометр через Enter");
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                TaxiCost[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] DistanceTest = new int[NumberOfWorkers];
            int[] TaxiCostTest = new int[NumberOfWorkers];
            int[] ID = new int[NumberOfWorkers];
            int[] TaxiID = new int[NumberOfWorkers];

            for (int j = 0; j < NumberOfWorkers; j++)
            {
                DistanceTest[j] = Distance[j];
                TaxiCostTest[j] = TaxiCost[j];                      //гуд
                ID[j] = j + 1;
                TaxiID[j] = j + 1;
            }

            Console.WriteLine("");

            for (int i = 0; i < NumberOfWorkers; i++)
            {
                int minDistance = 100000000;
                int maxCost = -1;
                for (int j = 0; j < NumberOfWorkers; j++)
                {

                    if (DistanceTest[j] <=minDistance && DistanceTest[j] != -1)                            
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



            for (int i = 0; i < NumberOfWorkers; i++)
            {
                for (int j = 0; j < NumberOfWorkers; j++)
                {
                    if (ID[j] == i+1)
                    {
                        Console.WriteLine(TaxiID[j]);
                    }
                }
            }

        }
    }
}
