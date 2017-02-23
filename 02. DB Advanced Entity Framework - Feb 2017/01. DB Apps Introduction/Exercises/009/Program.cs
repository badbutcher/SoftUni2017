namespace _009
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
                Console.Write("Enter minion Id: ");
                int id = int.Parse(Console.ReadLine());

                SqlCommand updateAge = new SqlCommand("usp_GetOlder @minionId", connection);
                updateAge.Parameters.AddWithValue("@minionId", id);
                updateAge.ExecuteNonQuery();

                SqlCommand readMinions = new SqlCommand(@"SELECT MinionId, Name, Age FROM Minions", connection);
                SqlDataReader minionReader = readMinions.ExecuteReader();

                while (minionReader.Read())
                {
                    int minionId = (int)minionReader["MinionId"];
                    if (minionId == id)
                    {
                        string name = minionReader["Name"].ToString();
                        int age = (int)minionReader["Age"];
                        Console.WriteLine($"{name} {age}");
                    }                 
                }
            }
        }
    }
}
