using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Driver
    {
        public static void Update(int driverID, string name, object routeID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Driver\"\r\n\t" +
                "SET " +
                "\"Name\"=@Name, " +
                "\"RouteID\"=@RouteID " +
                "WHERE \"DriverID\"=@DriverID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.Parameters.AddWithValue("@Name", name);

                if (routeID != null && routeID != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("@RouteID", (int)routeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RouteID", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int driverID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Driver\" " +
                "WHERE \"DriverID\" = @DriverID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@DriverID", driverID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Insert(string name)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Driver\"" +
                "(\r\n\t\"Name\") " +
                "VALUES (@Name);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
