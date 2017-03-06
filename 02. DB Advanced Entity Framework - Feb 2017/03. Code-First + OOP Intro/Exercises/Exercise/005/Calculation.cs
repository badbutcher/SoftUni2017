namespace _005
{
    public class Calculation
    {
        private static double constant = 6.62606896e-34d;
        private static double Pi = 3.14159d;

        public static double PlanckConstant()
        {
            return constant / (2 * Pi);
        }
    }
}