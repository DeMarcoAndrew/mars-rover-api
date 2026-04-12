namespace MarsRoverAPI.Calculators
{
    public class DateCalculator
    {
        public static double GetMarsSolDate(DateTime utcDate)
        {
            double julianDate = utcDate.ToUniversalTime().ToOADate() + 2415018.5;

            return (julianDate - 2405522.00331) / 1.02749125;
        }
    }
}