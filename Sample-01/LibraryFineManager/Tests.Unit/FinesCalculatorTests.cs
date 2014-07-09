using System;
using LibraryFineManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Unit
{
    [TestClass]
    public class FinesCalculatorTests
    {
        FinesCalculator finesCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            finesCalculator = new FinesCalculator();
        }

        [TestMethod]
        public void CalculateFine_OverdueBy4Days_Returns1Dollar()
        {
            //Arrange
            var dueDate = DateTime.Parse("5/1/2014");
            var dateToCalculateFine = dueDate.AddDays(4);

            //Act
            var fine = finesCalculator.CalculateFine(dueDate, dateToCalculateFine);

            //Assert
            Assert.AreEqual(1, fine);
        }

        [TestMethod]
        public void CalculateFine_WithinGracePeriod_NoFineAssessed()
        {
            //Arrange
            var dueDate = DateTime.Parse("5/1/2014");
            const int daysLate = 1;
            var dateToCalculateFine = dueDate.AddDays(daysLate);

            //Act
            var fine = finesCalculator.CalculateFine(dueDate, dateToCalculateFine);

            //Assert
            Assert.IsTrue(daysLate < finesCalculator.GracePeriodInDays);
            Assert.AreEqual(0, fine);
        }
    }
}
