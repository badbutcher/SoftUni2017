namespace _005
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
            Console.Write("Enter country name:");
            string countryName = Console.ReadLine();

            SqlConnection connection = new SqlConnection
                (
                    @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
                );

            connection.Open();
            using (connection)
            {
                string query = @"UPDATE Towns
SET TownName = UPPER(TownName)
WHERE CountryName = @CountryName AND TownName != UPPER(TownName) COLLATE SQL_Latin1_General_CP1_CS_AS";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryName", countryName);
                int changes = (int)command.ExecuteNonQuery();
                if (changes >= 1)
                {
                    Console.WriteLine("{0} town names were affected.", changes);
                    connection.Close();

                    SqlConnection connection2 = new SqlConnection
               (
                   @"Server=.;
                    Database=MinionsDB;
                    Integrated Security=true"
               );

                    connection2.Open();

                    using (connection2)
                    {
                        string querySelect = @"SELECT TownName
                                               FROM Towns
                                               WHERE CountryName = @CountryName";

                        SqlCommand command2 = new SqlCommand(querySelect, connection2);
                        command2.Parameters.AddWithValue("@CountryName", countryName);
                        SqlDataReader reader = command2.ExecuteReader();
                        List<string> towns = new List<string>();
                        using (reader)
                        {
                            while (reader.Read())
                            {
                                towns.Add(reader["TownName"].ToString());
                            }
                        }

                        string result = string.Join(", ", towns);
                        Console.WriteLine("[{0}]", result);
                    }
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }


            }
        }
    }
}