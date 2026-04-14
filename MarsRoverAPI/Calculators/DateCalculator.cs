namespace MarsRoverAPI.Calculators
{
    public class DateCalculator
    {
        public static double GetMarsSolDate(DateTime utcDate)
        {
            double julianDate = utcDate.ToOADate() + 2415018.5;

            return (julianDate - 2451549.5) / 1.0274912517 + 44796.0 - 0.0009626;
        }

        public static double CalculateCuriositySol(DateTime utcDateTime)
        {
            double julianDate = (utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalDays + 2440587.5;
            
            double modifiedJulianDate = julianDate - 2400000.5;
            
            // NASA's Formula
            double msd = (modifiedJulianDate - 51549.5) / 1.02749125 + 44796.0 - 0.0009626;
            
            // Subtract Curiosity landing
            double curiosityLandingMSD = 49269.0;
            double solCount = msd - curiosityLandingMSD;
            
            return Math.Floor(solCount + 1);
        }
    }
}