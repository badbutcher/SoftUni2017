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
                string query = $@"SELECT v.Name
FROM Villains AS v
WHERE v.VillainId = @VillainId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VillainId", VillainId);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Villain: {0}", reader["Name"]);
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
                string query = $@"SELECT m.MinionId, m.Name, m.Age
FROM Minions AS m
INNER JOIN VilliansMinions AS vm
ON vm.VillianId = m.MinionId
INNER JOIN Villains AS v
ON v.VillainId = vm.VillianId
WHERE v.VillainId = @VillainId";

                SqlCommand command = new SqlCommand(query, connection2);
                command.Parameters.AddWithValue("@VillainId", VillainId);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["MinionId"]} {reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
