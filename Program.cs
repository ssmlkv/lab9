using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab9.DisciplineArray;

namespace lab9
{
    internal class Program
    {
        private static int objectCount = 0;
        private static int collectionCount = 0;
        static void Main(string[] args)
        {
            Discipline mathDiscipline = new Discipline("Математика", 30, 30);
            Discipline englishDiscipline = new Discipline("");
            Discipline physicsDiscipline = new Discipline("физика", 50, 60);
            Console.WriteLine("Информация о дисциплинах:");
            mathDiscipline.show();
            englishDiscipline.show();
            physicsDiscipline.show();
            Console.WriteLine($"\nВсего создано объектов: {Discipline.GetObjectCount()}");
            int mathCredits = mathDiscipline.calculateCredits();
            Console.WriteLine($"Математические единицы: {mathCredits}");
            int physicsCredits = physicsDiscipline.calculateCredits();
            Console.WriteLine($"Физические единицы: {physicsCredits}");
            int englishCredits = englishDiscipline.calculateCredits();
            Console.WriteLine($"Английские единицы: {englishCredits}");
            //унарные операторы
            Console.WriteLine($"\nПроцент самостоятельного изучения физики: {!physicsDiscipline}%");

            //бинарные операторы
            Console.WriteLine("\nСравнение рабочих нагрузок:");
            Console.WriteLine($"Математическая нагрузка больше или равна физической? {mathDiscipline >= physicsDiscipline}");
            Console.WriteLine($"Нагрузка по английскому языку меньше или равна нагрузке по физике? {englishDiscipline <= physicsDiscipline}");

            //оператор явного приведения к double
            double mathWorkloadPercentage = (double)mathDiscipline;
            Console.WriteLine($"\nПроцент математической рабочей нагрузки: {mathWorkloadPercentage:P}");

            //оператор неявного приведения к int
            int physicsLectures = physicsDiscipline;
            Console.WriteLine($"Количество лекций по физике: {physicsLectures}");
            Console.WriteLine("\nУвеличение часов контакта для математической дисциплины:");
            mathDiscipline++;
            mathDiscipline.show();
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