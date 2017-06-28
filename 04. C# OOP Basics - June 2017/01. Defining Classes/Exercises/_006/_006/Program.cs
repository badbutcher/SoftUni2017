using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006
{
    public class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int age;        
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal salary = decimal.Parse(data[1]);
                string position = data[2];
                string department = data[3];

                if (data.Length == 5)
                {
                    bool check = int.TryParse(data[4], out age);
                    if (check)
                    {
                        Employee employee = new Employee(name, salary, position, department, age);
                        employees.Add(employee);
                    }
                    else if (!check)
                    {
                        string email = data[4];
                        Employee employee = new Employee(name, salary, position, department, email);
                        employees.Add(employee);
                    }
                }
                else if (data.Length == 6)
                {
                    string email = data[4];
                    Employee employee = new Employee(name, salary, position, department, email, int.Parse(data[5]));
                    employees.Add(employee);
                    
                }
                else if (data.Length == 4)
                {
                    Employee employee = new Employee(name, salary, position, department);
                    employees.Add(employee);
                }
                           
            }

            var avrSalary = employees.Select(a=>a.salary).Average();

            Console.WriteLine(avrSalary);

            foreach (var item in employees.Where(a=>a.salary).OrderByDescending(c=>c.salary))
            {
                Console.WriteLine("{0} {1} {2} {3}", item.name, item.salary, item.email, item.age);
            }
        }
    }
}