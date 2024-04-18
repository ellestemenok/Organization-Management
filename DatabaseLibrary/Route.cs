using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Route
    {
        public static void UpdateRouteName(int routeID, string newName)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Route\" " +
                "SET \"Name\" = @newName WHERE \"RouteID\" = @routeID", 
                Autorization.npgSqlConnection)) 
            {
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.Parameters.AddWithValue("@routeID", routeID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Insert(string newName)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Route\" (\"Name\") VALUES (@Name);", 
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", newName);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int routeID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM public.\"Route\" WHERE \"RouteID\" = @RouteID",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
