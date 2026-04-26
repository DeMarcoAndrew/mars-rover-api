using Xunit;
using MarsRoverAPI;
using MarsRoverAPI.Calculators;

namespace MarsRoverAPI.Tests
{
    public class DateCalculatorTests
    {
        [Theory]
        [InlineData("1999-03-27", 44518)]
        [InlineData("2001-09-11", 45393)]
        [InlineData("2012-03-19", 49132)]
        [InlineData("2019-08-28", 51777)]
        [InlineData("2025-02-01", 53708)]
        public void GetMarsSolDate_ReturnsCorrectCalculation(DateTime utcDate, double mathFloorExpected)
        {
            Double result = DateCalculator.GetMarsSolDate(utcDate);

            Assert.Equal(mathFloorExpected, Math.Floor(result));
        }

        [Theory]
        [InlineData("1999-03-27", -4750)]
        [InlineData("2001-09-11", -3875)]
        [InlineData("2012-03-19", -136)]
        [InlineData("2019-08-28", 2509)]
        [InlineData("2025-02-01", 4440)]
        public void CalculateCuriositySol_ReturnsCorrectCalculation(DateTime utcDate, double mathFloorExpected)
        {
            Double result = DateCalculator.CalculateCuriositySol(utcDate);

            Assert.Equal(mathFloorExpected, Math.Floor(result));
        }

        [Theory]
        [InlineData("1999-03-27", -7785)]
        [InlineData("2001-09-11", -6910)]
        [InlineData("2012-03-19", -3171)]
        [InlineData("2019-08-28", -526)]
        [InlineData("2025-02-01", 1405)]
        public void CalculatePerseveranceSol_ReturnsCorrectCalculation(DateTime utcDate, double mathFloorExpected)
        {
            Double result = DateCalculator.CalculatePerseveranceSol(utcDate);

            Assert.Equal(mathFloorExpected, Math.Floor(result));
        }

        [Theory]
        [InlineData("1999-03-27", -6992)]
        [InlineData("2001-09-11", -6117)]
        [InlineData("2012-03-19", -2378)]
        [InlineData("2019-08-28", 267)]
        [InlineData("2025-02-01", 2198)]
        public void CalculateInSightSol_ReturnsCorrectCalculation(DateTime utcDate, double mathFloorExpected)
        {
            Double result = DateCalculator.CalculateInSightSol(utcDate);

            Assert.Equal(mathFloorExpected, Math.Floor(result));
        }
        
                [Theory]
        [InlineData("1999-03-27", -7785)]
        [InlineData("2001-09-11", -6910)]
        [InlineData("2012-03-19", -3171)]
        [InlineData("2019-08-28", -526)]
        [InlineData("2025-02-01", 1405)]
        public void CalculateIngenuitySol_ReturnsCorrectCalculation(DateTime utcDate, double mathFloorExpected)
        {
            Double result = DateCalculator.CalculateIngenuitySol(utcDate);

            Assert.Equal(mathFloorExpected, Math.Floor(result));
        }
    }
}