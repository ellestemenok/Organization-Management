using Npgsql;
using System;
using System.Windows.Forms;
namespace DatabaseLibrary
{
    public class Good
    {
        public static void Update(int goodID, string name, string article, int measureunitID, int groupID, bool archivecheck, double netcost, double vat, double costwovat, double tradeprice, double trademargin, string description)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Good\"" +
                "SET " +
                "\"Name\"= @Name, " +
                "\"ArticleNumber\" = @ArticleNumber, " +
                "\"MeasureUnitID\" = @MeasureUnitID, " +
                "\"Description\" = @Description, " +
                "\"InArchive\" = @InArchive, " +
                "\"VAT\" = @VAT, " +
                "\"TradeMargin\" = @TradeMargin, " +
                "\"NetCost\" = @NetCost, " +
                "\"TradePrice\" = @TradePrice, " +
                "\"CategoryID\" = @CategoryID " +
                "WHERE \"GoodID\" = @GoodID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@GoodID", goodID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ArticleNumber", article);
                cmd.Parameters.AddWithValue("@MeasureUnitID", measureunitID);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@InArchive", archivecheck);
                cmd.Parameters.AddWithValue("@VAT", vat);
                cmd.Parameters.AddWithValue("@TradeMargin", trademargin);
                cmd.Parameters.AddWithValue("@NetCost", netcost);
                cmd.Parameters.AddWithValue("@TradePrice", tradeprice);
                cmd.Parameters.AddWithValue("@CategoryID", groupID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Insert(string name, string article,int measureunitID, int groupID, bool archivecheck, double netcost, double vat, double costwovat, double tradeprice, double trademargin, string description)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Good\" " +
                "(\"Name\", \"ArticleNumber\", \"MeasureUnitID\", " +
                "\"Description\", \"InArchive\", \"VAT\", \"TradeMargin\", " +
                "\"NetCost\", \"TradePrice\", \"CategoryID\") " +
                "VALUES (@Name, @ArticleNumber, @MeasureUnitID," +
                "@Description, @InArchive, @VAT, @TradeMargin, " +
                "@NetCost, @TradePrice, @CategoryID);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ArticleNumber", article);
                cmd.Parameters.AddWithValue("@MeasureUnitID", measureunitID);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@InArchive", archivecheck);
                cmd.Parameters.AddWithValue("@VAT", vat);
                cmd.Parameters.AddWithValue("@TradeMargin", trademargin);
                cmd.Parameters.AddWithValue("@NetCost", netcost);
                cmd.Parameters.AddWithValue("@TradePrice", tradeprice);
                cmd.Parameters.AddWithValue("@CategoryID", groupID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int goodID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Good\" " +
                "WHERE \"GoodID\" = @GoodID", Autorization.npgSqlConnection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@GoodID", goodID);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: элемент используется в другой таблице.", "Запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
