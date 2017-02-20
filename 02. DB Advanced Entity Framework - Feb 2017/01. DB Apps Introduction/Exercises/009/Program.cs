namespace _009
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
                    "Server=.; " +
                    "Database=MinionsDB; " +
                    "Integrated Security=true"
                );

            connection.Open();
            using (connection)
            {

            }
        }
    }
}
