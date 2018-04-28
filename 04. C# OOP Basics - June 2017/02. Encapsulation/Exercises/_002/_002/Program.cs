namespace _002
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            try
            {
                Type boxType = typeof(Box);
                FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                //Console.WriteLine(fields.Count());

                decimal length = decimal.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                decimal height = decimal.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);
                Console.WriteLine("Surface Area - {0:F2}", box.GetSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:F2}", box.GetLateralSurfaceArea());
                Console.WriteLine("Volume - {0:F2}", box.GetVolume());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}