using System;

namespace lab9
{
    public class DisciplineArray
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

            public Discipline(Discipline originalDiscipline)
            {
                // Копируем значения полей из оригинальной дисциплины
                Name = originalDiscipline.Name;
                Credits = originalDiscipline.Credits;
                IncrementObjectCounter();
            }

            public Discipline(string name, int contactHours, int selfHours)
            {
                Name = name;
                ContactHours = contactHours;
                SelfHours = selfHours;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Дисциплина: {Name}, Зачетные единицы: {Credits}");
            }

            private static void IncrementObjectCounter()
            {
                totalObjectsCreated++;
            }

            public int CalculateCredits()
            {
                // Реализация расчета зачетных единиц
                return Credits * 2; // Пример реализации
            }

            // Добавим метод Show
            public void Show()
            {
                Console.WriteLine($"Дисциплина: {Name}, Контактные часы: {ContactHours}, Самостоятельные часы: {SelfHours}");
            }

            public object show()
            {
                throw new NotImplementedException();
            }

            private static int totalObjectsCreated = 0;

            public static int TotalObjectsCreated
            {
                get { return totalObjectsCreated; }
            }

            public Discipline OriginalDiscipline { get; }
            public int ContactHours { get; set; }
            public int SelfHours { get; set; }

            public static bool operator ==(Discipline d1, Discipline d2)
            {
                return d1.Name == d2.Name && d1.Credits == d2.Credits;
            }

            public static bool operator !=(Discipline d1, Discipline d2)
            {
                return !(d1 == d2);
            }

            public static explicit operator double(Discipline v)
            {
                // Реализация явного преобразования в double
                return v.Credits;
            }
        }

        public Discipline[] arr;

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
                arr[i] = new Discipline(other.arr[i]); // Используем конструктор копирования
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
                    return null; // Возвращаем null в случае выхода за пределы массива
                }

                return arr[index];
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value;
                }
                // Или просто проигнорируйте установку, если индекс за пределами массива
            }
        }

        public void ProcessArrayElements()
        {
            for (int i = 0; i < arr.Length; i++)
            {
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
