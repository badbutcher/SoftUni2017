namespace _007
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
            SqlConnection connection = new SqlConnection
                (
                    @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                );

            connection.Open();
            List<string> names = new List<string>();
            using (connection)
            {
                string query = "SELECT Name FROM Minions";
                SqlCommand minionNames = new SqlCommand(query, connection);
                SqlDataReader reader = minionNames.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                    }
                }
            }

            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);

                if (names.Count - i - 1 != i)
                {
                    Console.WriteLine(names[names.Count - 1 - i]);
                }
            }
        }
    }
}
