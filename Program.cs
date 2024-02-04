using lab9;
using System;

namespace lab99
{
    internal class Program
    {
        private static int objectCount;
        private static int collectionCount;
        static void Main(string[] args)
        {
            Discipline discipline1 = new Discipline("Math", 20, 10);
            Discipline discipline2 = new Discipline("Physics", 15, 12);

            Console.WriteLine($"Percentage of self-study for {discipline1.Name}: {discipline1.PercentageSelfStudy()}%");

            Console.WriteLine("Before ++:");
            discipline1.DisplayInfo();
            discipline1++;
            Console.WriteLine("After ++:");
            discipline1.DisplayInfo();

            double percentage = (double)discipline2;
            Console.WriteLine($"Percentage of contact hours for {discipline2.Name}: {percentage}");

            int numberOfClasses = discipline1;
            Console.WriteLine($"Number of classes for {discipline1.Name}: {numberOfClasses}");

            if (discipline1 >= discipline2)
            {
                Console.WriteLine($"{discipline1.Name} has equal or greater workload than {discipline2.Name}");
            }

            if (discipline2 <= discipline1)
            {
                Console.WriteLine($"{discipline2.Name} has equal or smaller workload than {discipline1.Name}");
            }

            // Перегруженный оператор сложения
            Discipline combinedDiscipline = discipline2 + discipline1;
            Console.WriteLine("Combined Discipline:");
            combinedDiscipline.DisplayInfo();

            // Перегруженный оператор равенства
            if (discipline2 == discipline1)
            {
                Console.WriteLine("discipline2 is equal to discipline1");
            }

            // Перегруженный оператор неравенства
            if (discipline1 != discipline2)
            {
                Console.WriteLine("discipline1 is not equal to discipline2");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Создание массива разными способами:");
            DisciplineArray disciplineArrayManual = new DisciplineArray(3, true);
            Console.WriteLine("\nМассив, созданный с использованием ручного ввода:");
            disciplineArrayManual.DisplayElements();

            DisciplineArray disciplineArrayRandom = new DisciplineArray(3, false);
            Console.WriteLine("\nМассив, созданный с использованием случайной генерации:");
            disciplineArrayRandom.DisplayElements();

            Console.WriteLine("\nСоздание новой коллекции на основе существующей (глубокое копирование):");
            DisciplineArray newDisciplineArray = new DisciplineArray(disciplineArrayRandom);
            Console.WriteLine("\nНовая коллекция, созданная на основе существующей:");
            newDisciplineArray.DisplayElements();

            // Примеры работы с индексатором
            Console.WriteLine("\nПримеры работы с индексатором:");

            // Запись объекта и получение объекта с существующим индексом
            Console.WriteLine("\n1. Запись объекта и получение объекта с существующим индексом:");
            DisciplineArray.Discipline newDiscipline = new DisciplineArray.Discipline("Новая дисциплина", 5);
            newDisciplineArray[1] = newDiscipline;
            newDisciplineArray.DisplayElements();

            // Запись объекта и получение объекта с несуществующим индексом (приведет к исключению)
            Console.WriteLine("\n2. Запись объекта и получение объекта с несуществующим индексом (приведет к исключению):");
            try
            {
                DisciplineArray.Discipline invalidDiscipline = newDisciplineArray[10];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            // Получение объекта с существующим индексом
            Console.WriteLine("\n3. Получение объекта с существующим индексом:");
            DisciplineArray.Discipline retrievedDiscipline = newDisciplineArray[2];
            retrievedDiscipline.DisplayInfo();

            // Получение объекта с несуществующим индексом (приведет к исключению)
            Console.WriteLine("\n4. Получение объекта с несуществующим индексом (приведет к исключению):");
            try
            {
                DisciplineArray.Discipline invalidRetrievedDiscipline = newDisciplineArray[5];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            DisciplineArray disciplineArray = new DisciplineArray(3, true);
            Console.WriteLine("Исходный массив:");
            disciplineArray.DisplayElements();

            Console.WriteLine("\nФункция для выполнения операций с элементами массива:");
            disciplineArray.ProcessArrayElements();
            Console.WriteLine("Создание объектов и коллекций:");
            DisciplineArray disciplineArray1 = new DisciplineArray(3, true);
            DisciplineArray disciplineArray2 = new DisciplineArray(2, false);

            Console.WriteLine($"\nОбщее количество созданных объектов: {DisciplineArray.Discipline.TotalObjectsCreated}");
            Console.WriteLine($"Общее количество созданных коллекций: {DisciplineArray.TotalCollectionsCreated}");

            Console.WriteLine("\nИсходный массив:");
            disciplineArray1.DisplayElements();
            Console.WriteLine("\nФункция для выполнения операций с элементами массива:");
            disciplineArray1.ProcessArrayElements();
            Console.WriteLine($"\nОбщее количество созданных объектов: {DisciplineArray.Discipline.TotalObjectsCreated}");
            Console.WriteLine($"Общее количество созданных коллекций: {DisciplineArray.TotalCollectionsCreated}");

            Console.WriteLine("\nИсходный массив:");
            disciplineArray1.DisplayElements();

            Console.WriteLine("\nФункция для выполнения операций с элементами массива:");
            disciplineArray1.ProcessArrayElements();

            // Нахождение средневзвешенного значения зачётных единиц
            double weightedAverageCredits = disciplineArray1.CalculateWeightedAverageCredits();
            Console.WriteLine($"\nСредневзвешенное значение зачётных единиц по всем дисциплинам: {weightedAverageCredits:F2}");
        }
    }
}