using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseLibrary
{
    public class User
    {

        public static void Insert(string fio, string login, string password, string role, bool isActive)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"User\" (\"Login\", \"FullName\", \"Password\", \"Role\", \"isActive\") " +
                "VALUES (@Login, @FullName, @Password, @Role, @isActive);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@FullName", fio);
                cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int userID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"User\" " +
                "WHERE \"UserID\" = @UserID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(int userID, string fio, string login, string password, string role, bool isActive)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"User\"\r\n\t" +
                "SET " +
                "\"FullName\"=@FullName, " +
                "\"Login\"=@Login, " +
                "\"Role\"=@Role, " +
                "\"isActive\"=@isActive, " +
                "\"Password\"=@Password " +
                "WHERE \"UserID\"=@UserID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@FullName", fio);
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@Password", BCrypt.Net.BCrypt.HashPassword(password));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
