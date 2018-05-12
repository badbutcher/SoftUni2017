namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                try
                {
                    // string.Intern(input);

                    string result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var inputData = input.Split();

            var command = inputData.First();
            var data = inputData.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var setovete = this.setCоntroller.PerformSets();
                return setovete;
            }

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { data });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            return a;
        }
    }
}