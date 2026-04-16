namespace MarsRoverAPI.Calculators
{
    public class DateCalculator
    {
        public static double GetMarsSolDate(DateTime utcDateTime)
        {
            double julianDate = (utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalDays + 2440587.5;
            
            double modifiedJulianDate = julianDate - 2400000.5;
            
            // NASA's Formula
            return ((modifiedJulianDate - 51549.5) / 1.02749125) + 44796.0 - 0.0009626;
        }

        public static double CalculateCuriositySol(DateTime utcDateTime)
        {
            double msd = GetMarsSolDate(utcDateTime);
            
            // Subtract Curiosity landing
            double curiosityLandingMSD = 49269.0;
            double solCount = msd - curiosityLandingMSD;
            
            return Math.Floor(solCount + 1);
        }

        public static double CalculatePerseveranceSol(DateTime utcDateTime)
        {
            double msd = GetMarsSolDate(utcDateTime);
            
            // Subtract Perseverance landing
            double perseveranceLandingMSD = 52303.9681418;
            double solCount = msd - perseveranceLandingMSD;
                   
            return Math.Floor(solCount + 1);
        }
    }
}