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

        public static double CalculateSolForRover(DateTime utcDateTime, double roverLandingSol)
        {
            double msd = GetMarsSolDate(utcDateTime);
            
            // Subtract landing sol
            double solCount = msd - roverLandingSol;
            
            return Math.Floor(solCount + 1);
        }

        /// <summary>
        /// For the Methods below, the roverLanding sols were gotten 
        /// by using the calculations in the GetMarsSolDate method with 
        /// the rover landing date in UTC time and then rounding it to the nearest whole number.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns>SOL for that rover. Ex: Curiosity landed at August 6, 2012, at 05:17 UTC, which would be SOL 0 </returns>

        public static double CalculateCuriositySol(DateTime utcDateTime)
        {
            return CalculateSolForRover(utcDateTime, 49269);
        }

        public static double CalculatePerseveranceSol(DateTime utcDateTime)
        {
            return CalculateSolForRover(utcDateTime, 52304);
        }

        public static double CalculateInSightSol(DateTime utcDateTime)
        {
            return CalculateSolForRover(utcDateTime, 51511);
        }

        public static double CalculateIngenuitySol(DateTime utcDateTime)
        {
            return CalculateSolForRover(utcDateTime, 52304);
        }
    }
}