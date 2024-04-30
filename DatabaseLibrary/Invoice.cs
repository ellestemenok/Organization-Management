using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Invoice
    {
        public static void Insert(DateTime date, int contractorID, int storageID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Invoice\"" +
                "(\r\n\t\"InvoiceDate\", " +
                "\"ContractorID\", " +
                "\"OrgID\") \r\n\t" +
                "VALUES (@InvoiceDate, @ContractorID, @StorageID);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@InvoiceDate", date);
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@StorageID", storageID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteDetail(int detailID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"InvoiceDetail\" " +
                "WHERE \"DetailID\" = @DetailID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@DetailID", detailID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
