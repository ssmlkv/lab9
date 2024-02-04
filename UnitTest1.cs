using lab9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lab99.Tests
{
    [TestClass]
    public class DisciplineTests
    {
        [TestMethod]
        public void PercentageSelfStudy_ShouldCalculateCorrectly()
        {
            // Arrange
            Discipline discipline = new Discipline("Math", 20, 10);

            // Act
            double percentage = discipline.PercentageSelfStudy();

            // Assert
            Assert.AreEqual(33.33, percentage, 0.01); // Use delta to allow for floating-point precision
        }

        [TestMethod]
        public void CalculateCreditUnits_ShouldReturnCorrectValue()
        {
            // Arrange
            Discipline discipline = new Discipline("Physics", 40, 10);

            // Act
            int creditUnits = discipline.CalculateCreditUnits();

            // Assert
            Assert.AreEqual(1, creditUnits);
        }

        [TestMethod]
        public void IncrementContactHours_ShouldIncreaseContactHoursAndDecreaseSelfHours()
        {
            // Arrange
            Discipline discipline = new Discipline("Chemistry", 30, 15);

            // Act
            discipline++;

            // Assert
            Assert.AreEqual(32, discipline.ContactHours);
            Assert.AreEqual(13, discipline.SelfHours);
        }

        [TestMethod]
        public void ExplicitConversion_ShouldReturnCorrectValue()
        {
            // Arrange
            Discipline discipline = new Discipline("Biology", 25, 5);

            // Act
            double result = (double)discipline;

            // Assert
            Assert.AreEqual(0.833, result, 0.001);
        }

        [TestMethod]
        public void ImplicitConversion_ShouldReturnCorrectValue()
        {
            // Arrange
            Discipline discipline = new Discipline("History", 16, 8);

            // Act
            int result = discipline; // Implicit conversion

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void AdditionOperator_ShouldCombineDisciplinesCorrectly()
        {
            // Arrange
            Discipline discipline1 = new Discipline("English", 20, 10);
            Discipline discipline2 = new Discipline("Computer Science", 30, 15);

            // Act
            Discipline result = discipline1 + discipline2;

            // Assert
            Assert.AreEqual("English + Computer Science", result.Name);
            Assert.AreEqual(50, result.ContactHours);
            Assert.AreEqual(25, result.SelfHours);
        }

        [TestMethod]
        public void EqualityOperator_ShouldReturnTrueForEqualDisciplines()
        {
            // Arrange
            Discipline discipline1 = new Discipline("Psychology", 25, 10);
            Discipline discipline2 = new Discipline("Psychology", 25, 10);

            // Act & Assert
            Assert.IsTrue(discipline1 == discipline2);
        }

        [TestMethod]
        public void EqualityOperator_ShouldReturnFalseForDifferentDisciplines()
        {
            // Arrange
            Discipline discipline1 = new Discipline("Economics", 30, 12);
            Discipline discipline2 = new Discipline("History", 30, 12);

            // Act & Assert
            Assert.IsFalse(discipline1 == discipline2);
        }
        [TestClass]
        public class DisciplineArrayTests
        {
            [TestMethod]
            public void DisciplineArray_Creation_DefaultConstructor()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray();

                // Act & Assert
                Assert.IsNotNull(disciplineArray);
                Assert.IsNotNull(disciplineArray.arr);
                Assert.AreEqual(0, disciplineArray.arr.Length);
            }

            [TestMethod]
            public void DisciplineArray_Creation_WithSize_UserInput()
            {
                // Arrange
                int size = 3;
                bool userInput = true;

                // Act
                DisciplineArray disciplineArray = new DisciplineArray(size, userInput);

                // Assert
                Assert.IsNotNull(disciplineArray);
                Assert.IsNotNull(disciplineArray.arr);
                Assert.AreEqual(size, disciplineArray.arr.Length);
            }

            [TestMethod]
            public void DisciplineArray_Creation_WithSize_RandomInput()
            {
                // Arrange
                int size = 5;
                bool userInput = false;

                // Act
                DisciplineArray disciplineArray = new DisciplineArray(size, userInput);

                // Assert
                Assert.IsNotNull(disciplineArray);
                Assert.IsNotNull(disciplineArray.arr);
                Assert.AreEqual(size, disciplineArray.arr.Length);
            }

            [TestMethod]
            public void DisciplineArray_Creation_CopyConstructor()
            {
                // Arrange
                DisciplineArray originalArray = new DisciplineArray(3, true);

                // Act
                DisciplineArray copiedArray = new DisciplineArray(originalArray);

                // Assert
                Assert.IsNotNull(copiedArray);
                Assert.IsNotNull(copiedArray.arr);
                Assert.AreEqual(originalArray.arr.Length, copiedArray.arr.Length);
            }

            [TestMethod]
            public void DisciplineArray_DisplayElements()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(2, true);
                var consoleOutput = new StringWriter();
                Console.SetOut(consoleOutput);

                // Act
                disciplineArray.DisplayElements();

                // Assert
                var expectedOutput = "Дисциплина: Test1, Зачетные единицы: 3" + Environment.NewLine + "Дисциплина: Test2, Зачетные единицы: 5" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, consoleOutput.ToString());
            }

            [TestMethod]
            public void DisciplineArray_Indexer_GetValidIndex()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(3, true);

                // Act
                DisciplineArray.Discipline discipline = disciplineArray[1];

                // Assert
                Assert.IsNotNull(discipline);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void DisciplineArray_Indexer_GetInvalidIndex()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(3, true);

                // Act & Assert
                DisciplineArray.Discipline discipline = disciplineArray[5];
            }

            [TestMethod]
            public void DisciplineArray_Indexer_SetValidIndex()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(3, true);
                DisciplineArray.Discipline newDiscipline = new DisciplineArray.Discipline("NewTest", 2);

                // Act
                disciplineArray[1] = newDiscipline;

                // Assert
                Assert.AreEqual("NewTest", disciplineArray[1].Name);
                Assert.AreEqual(2, disciplineArray[1].Credits);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void DisciplineArray_Indexer_SetInvalidIndex()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(3, true);
                DisciplineArray.Discipline newDiscipline = new DisciplineArray.Discipline("NewTest", 2);

                // Act & Assert
                disciplineArray[5] = newDiscipline;
            }

            [TestMethod]
            public void DisciplineArray_ProcessArrayElements()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(2, true);

                // Act & Assert
                Assert.AreEqual("Элемент массива с индексом 0 совпадает с примером.", disciplineArray.ProcessArrayElements());
                Assert.AreEqual("Элемент массива с индексом 1 совпадает с примером.", disciplineArray.ProcessArrayElements());
            }

            [TestMethod]
            public void DisciplineArray_CalculateWeightedAverageCredits_EmptyArray()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray();

                // Act
                double averageCredits = disciplineArray.CalculateWeightedAverageCredits();

                // Assert
                Assert.AreEqual(0.0, averageCredits);
            }

            [TestMethod]
            public void DisciplineArray_CalculateWeightedAverageCredits_NonEmptyArray()
            {
                // Arrange
                DisciplineArray disciplineArray = new DisciplineArray(3, true);

                // Act
                double averageCredits = disciplineArray.CalculateWeightedAverageCredits();

                // Assert
                Assert.AreEqual(3.33, averageCredits, 0.01);
            }
        }
    }
}
