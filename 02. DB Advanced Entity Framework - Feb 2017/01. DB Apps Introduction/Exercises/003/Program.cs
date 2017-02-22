namespace _003
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter id");
            int VillainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection
                 (
                     @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                 );

            connection.Open();
            using (connection)
            {
                string getVillainName = $@"SELECT v.Name
                                           FROM Villains AS v
                                           WHERE v.VillainId = @VillainId";

                SqlCommand command = new SqlCommand(getVillainName, connection);
                SqlParameter villainIdParam = new SqlParameter("@VillainId", VillainId);
                command.Parameters.Add(villainIdParam);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Villain: {0}", reader["Name"]);
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {VillainId} exists in the database.");
                    }
                }
            }

            SqlConnection connection2 = new SqlConnection
                 (
                     @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                 );

            connection2.Open();
            using (connection2)
            {
                string getMinionsNames = $@"SELECT m.Name, m.Age
                                            FROM Minions AS m
                                            INNER JOIN VilliansMinions AS vm
                                            ON vm.VillianId = m.MinionId
                                            INNER JOIN Villains AS v
                                            ON v.VillainId = vm.VillianId
                                            WHERE v.VillainId = @VillainId";

                SqlCommand command = new SqlCommand(getMinionsNames, connection2);
                command.Parameters.AddWithValue("@VillainId", VillainId);
                SqlDataReader reader = command.ExecuteReader();
                int counter = 1;
                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("<no minions>");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"{counter}. {reader["Name"]} {reader["Age"]}");
                        counter++;
                    }
                }
            }
        }
    }
}