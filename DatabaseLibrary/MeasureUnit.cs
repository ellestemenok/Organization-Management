using Npgsql;
namespace DatabaseLibrary
{
    public class MeasureUnit
    {
        public static void Update(int unitID, int okeiID, string name, string fullname, bool fractional)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"MeasureUnit\" " +
                "SET \"okeiID\" = @okeiID, " +
                "\"Name\" = @Name, " +
                "\"FullName\"= @FullName, " +
                "\"Fractional\"= @Fractional " +
                "WHERE \"UnitID\" = @UnitID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                cmd.Parameters.AddWithValue("@okeiID", okeiID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Fractional", fractional);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Insert(int okeiID, string name, string fullname, bool fractional)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"MeasureUnit\" " +
                "(\"okeiID\", \"Name\", \"FullName\", \"Fractional\")" +
                "VALUES (@okeiID, @Name, @FullName, @Fractional);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@okeiID", okeiID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Fractional", fractional);
                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int unitID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"MeasureUnit\" " +
                "WHERE \"UnitID\" = @UnitID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@UnitID", unitID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
