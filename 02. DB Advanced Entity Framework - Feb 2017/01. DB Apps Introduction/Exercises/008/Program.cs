namespace _008
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection
                (
                    @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                );

            connection.Open();
            using (connection)
            {
                Console.Write("Enter minions id's ");
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int i = 0; i < input.Length; i++)
                {
                    int currentId = input[i];
                    SqlParameter minionId = new SqlParameter("@minionsId", currentId);
                    string updateMinionsAgeQuery = File.ReadAllText(@"D:\Github\SoftUni2017\02. DB Advanced Entity Framework - Feb 2017\01. DB Apps Introduction\Exercises\008\008.sql");
                    SqlCommand ageCommand = new SqlCommand(updateMinionsAgeQuery, connection);
                    ageCommand.Parameters.Add(minionId);
                    ageCommand.ExecuteNonQuery();

                }

                SqlCommand getMinions = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);
                SqlDataReader minionsReader = getMinions.ExecuteReader();

                while (minionsReader.Read())
                {
                    string name = minionsReader["Name"].ToString();
                    int age = (int)minionsReader["Age"];
                    Console.WriteLine($"{name} {age}");
                }
            }
        }
    }
}
