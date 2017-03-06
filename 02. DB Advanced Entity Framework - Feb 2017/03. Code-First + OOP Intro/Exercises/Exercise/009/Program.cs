namespace _009
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("What will you do?");
            Console.WriteLine("Create/Diagnose/Visitations/Prescribe/End");
            string input = Console.ReadLine();

            HospitalContext context = new HospitalContext();

            while (input != "End")
            {
                if (input == "Create")
                {
                    Patients p = new Patients();
                    Console.Write("Enter first name ");
                    p.FirstName = Console.ReadLine();

                    Console.Write("Enter last name ");
                    p.Lastname = Console.ReadLine();

                    Console.Write("Enter address ");
                    p.Address = Console.ReadLine();

                    Console.Write("Enter email ");
                    p.Email = Console.ReadLine();

                    Console.Write("Enter date of birth ");
                    p.DateOfBirth = DateTime.Parse(Console.ReadLine());

                    context.Patients.Add(p);
                    context.SaveChanges();
                }

                if (input == "Diagnose")
                {
                    Console.Write("Enter patient id ");
                    int id = int.Parse(Console.ReadLine());
                    Patients patient = context.Patients.Find(id);

                    Diagnoses d = new Diagnoses();

                    Console.Write("Enter diagnoses name ");
                    d.Name = Console.ReadLine();

                    Console.Write("Enter comment name ");
                    d.Comment = Console.ReadLine();

                    context.Diagnoses.Add(d);
                    context.SaveChanges();
                }

                if (input == "Visitations")
                {
                    Console.Write("Enter patient id ");
                    int id = int.Parse(Console.ReadLine());
                    Patients patient = context.Patients.Find(id);

                    Visitations v = new Visitations();

                    Console.Write("Enter date ");
                    v.Date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter comment name ");
                    v.Comment = Console.ReadLine();

                    context.Visitations.Add(v);
                    context.SaveChanges();
                }

                if (input == "Prescribe")
                {
                    Console.Write("Enter patient id ");
                    int id = int.Parse(Console.ReadLine());
                    Patients patient = context.Patients.Find(id);

                    PrescribedMedicaments pv = new PrescribedMedicaments();

                    Console.Write("Enter name ");
                    pv.Name = Console.ReadLine();

                    context.PrescribedMedicaments.Add(pv);
                    context.SaveChanges();
                }

                Console.WriteLine("Now?");
                input = Console.ReadLine();
            }
        }
    }
}