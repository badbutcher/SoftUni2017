using Exam;
using Exam.Models;
using Exam.Models.Dtos;
using Exam.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportJson
{
    class Startup
    {
        private const string ImportAgenciesPath = "../../Jsons/agencies.json";

        private const string ImportPeoplePath = "../../Jsons/people.json";

        private const string ImportWeddingsPath = "../../Jsons/weddings.json";

        static void Main()
        {
            ExamContext context = new ExamContext();

            //ImportAgencies(context);
            ImportPeople(context);
            //ImportWeddings(context);
        }

        private static void ImportWeddings(ExamContext context)
        {

        }
        

        private static void ImportPeople(ExamContext context)
        {
            var json = File.ReadAllText(ImportPeoplePath);
            var people = JsonConvert.DeserializeObject<IEnumerable<ImportPeopleDto>>(json);

            foreach (var item in people)
            {
                if (item.FirstName == null || item.MiddleInitial == null || item.LastName == null || item.MiddleInitial.Length != 1)
                {
                    Console.WriteLine("Error. Invalid data provided");
                }
                else
                {
                    Gender genre = Gender.NotSpecified;

                    if (item.Gender == Gender.Female)
                    {
                        genre = Gender.Female;
                    }
                    else if (item.Gender == Gender.Male)
                    {
                        genre = Gender.Male;
                    }

                    var personImport = new Person
                    {
                        FirstName = item.FirstName,
                        MiddleNameIntial = item.MiddleInitial,
                        LastName = item.LastName,
                        Gender = genre,
                        Birthdate = item.Birthday,
                        Phone = item.Phone,
                        Email = item.Email
                    };
                    try
                    {
                        context.Persons.Add(personImport);

                        context.SaveChanges();
                        Console.WriteLine($"Successfully imported {personImport.FirstName} {personImport.MiddleNameIntial} {personImport.LastName}");
                    }
                    catch (Exception)
                    {
                        context.Persons.Remove(personImport);
                        Console.WriteLine("Error. Invalid data provided");
                    }

                }
            }
        }

        private static void ImportAgencies(ExamContext context)
        {
            var json = File.ReadAllText(ImportAgenciesPath);
            var agencies = JsonConvert.DeserializeObject<IEnumerable<ImportAgenciesDto>>(json);

            foreach (var item in agencies)
            {
                var agemcy = new Agency
                {
                    Name = item.Name,
                    EmployeesCount = item.EmployeesCount,
                    Town = item.Town
                };

                context.Agencys.Add(agemcy);
                Console.WriteLine($"Successfully imported {agemcy.Name}");
            }

            context.SaveChanges();
        }
    }
}
