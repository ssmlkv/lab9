using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class DisciplineArray
    {
        public class Discipline
        {
            private string name;
            private int credits;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Credits
            {
                get { return credits; }
                set { credits = value; }
            }

            public Discipline()
            {
                IncrementObjectCounter();
            }

            public Discipline(string name, int credits)
            {
                Name = name;
                Credits = credits;
                IncrementObjectCounter();
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Дисциплина: {Name}, Зачетные единицы: {Credits}");
            }

            private static void IncrementObjectCounter()
            {
                totalObjectsCreated++;
            }

            private static int totalObjectsCreated = 0;

            public static int TotalObjectsCreated
            {
                get { return totalObjectsCreated; }
            }

            // Пример перегрузки оператора ==
            public static bool operator ==(Discipline d1, Discipline d2)
            {
                return d1.Name == d2.Name && d1.Credits == d2.Credits;
            }

            // Пример перегрузки оператора !=
            public static bool operator !=(Discipline d1, Discipline d2)
            {
                return !(d1 == d2);
            }
        }

        private Discipline[] arr;

        public DisciplineArray()
        {
            arr = new Discipline[0];
            IncrementCollectionCounter();
        }

        public DisciplineArray(int size, bool userInput)
        {
            arr = new Discipline[size];
            IncrementCollectionCounter();

            if (userInput)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Введите параметры для дисциплины {i + 1}:");
                    Console.Write("Название: ");
                    string name = Console.ReadLine();

                    Console.Write("Зачетные единицы: ");
                    int credits = int.Parse(Console.ReadLine());

                    arr[i] = new Discipline { Name = name, Credits = credits };
                }
            }
            else
            {
                Random random = new Random();

                for (int i = 0; i < size; i++)
                {
                    arr[i] = new Discipline { Name = $"Дисциплина-{i + 1}", Credits = random.Next(1, 10) };
                }
            }
        }

        public DisciplineArray(DisciplineArray other)
        {
            arr = new Discipline[other.arr.Length];

            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Discipline { Name = other.arr[i].Name, Credits = other.arr[i].Credits };
            }

            IncrementCollectionCounter();
        }

        private static void IncrementCollectionCounter()
        {
            totalCollectionsCreated++;
        }

        private static int totalCollectionsCreated = 0;

        public static int TotalCollectionsCreated
        {
            get { return totalCollectionsCreated; }
        }

        public void DisplayElements()
        {
            foreach (var discipline in arr)
            {
                discipline.DisplayInfo();
            }
        }

        public Discipline this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Индекс выходит за пределы массива");
                }

                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Индекс выходит за пределы массива");
                }

                arr[index] = value;
            }
        }

        // Функция для выполнения операций с элементами массива
        public void ProcessArrayElements()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // Пример использования перегруженных операций
                Discipline exampleDiscipline = new Discipline { Name = "Пример", Credits = 3 };

                if (arr[i] == exampleDiscipline)
                {
                    Console.WriteLine($"Элемент массива с индексом {i} совпадает с примером.");
                }
                else
                {
                    Console.WriteLine($"Элемент массива с индексом {i} НЕ совпадает с примером.");
                }
            }
        }

        // Метод для нахождения средневзвешенного значения зачётных единиц
        public double CalculateWeightedAverageCredits()
        {
            if (arr.Length == 0)
            {
                return 0.0;
            }

            double totalWeightedCredits = 0.0;
            int totalCredits = 0;

            foreach (var discipline in arr)
            {
                totalWeightedCredits += discipline.Credits;
                totalCredits += discipline.Credits;
            }

            return totalWeightedCredits / totalCredits;
        }
    }
}   