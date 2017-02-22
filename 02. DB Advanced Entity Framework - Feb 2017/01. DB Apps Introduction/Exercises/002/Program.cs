namespace _002
{
    using System;
    using System.Data.SqlClient;

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
                string query = @"SELECT v.Name, COUNT(vm.MinionId) AS 'Count'
FROM Villains AS v
LEFT JOIN VilliansMinions AS vm
ON vm.VillianId = v.VillainId
GROUP BY v.Name
HAVING COUNT(vm.MinionId) >= 3
ORDER BY 'Count'"; // s 3 nqma da stane

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Count"]}");
                    }
                }
            }
        }
    }
}