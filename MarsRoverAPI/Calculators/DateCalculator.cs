namespace MarsRoverAPI.Calculators
{
    public class DateCalculator
    {
        public static double GetMarsSolDate(DateTime utcDate)
        {
            double julianDate = utcDate.ToOADate() + 2415018.5;

            return (julianDate - 2451549.5) / 1.0274912517 + 44796.0;
        }
    }
}