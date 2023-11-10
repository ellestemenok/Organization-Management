using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Good
    {
        public static void Update(int goodID, string name, string article, int measureunitID, int groupID, bool archivecheck, double netcost, double vat, double costwovat, double tradeprice, double retailprice, double trademargin, double retailmargin, string description)
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
                "\"RetailMargin\" = @RetailMargin, " +
                "\"NetCost\" = @NetCost, " +
                "\"TradePrice\" = @TradePrice, " +
                "\"RetailPrice\" = @RetailPrice, " +
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
                cmd.Parameters.AddWithValue("@RetailMargin", retailmargin);
                cmd.Parameters.AddWithValue("@NetCost", netcost);
                cmd.Parameters.AddWithValue("@TradePrice", tradeprice);
                cmd.Parameters.AddWithValue("@RetailPrice", retailprice);
                cmd.Parameters.AddWithValue("@CategoryID", groupID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Insert(string name, string article,int measureunitID, int groupID, bool archivecheck, double netcost, double vat, double costwovat, double tradeprice, double retailprice, double trademargin, double retailmargin, string description)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Good\" " +
                "(\"Name\", \"ArticleNumber\", \"MeasureUnitID\", " +
                "\"Description\", \"InArchive\", \"VAT\", \"TradeMargin\", \"RetailMargin\", " +
                "\"NetCost\", \"TradePrice\", \"RetailPrice\", \"CategoryID\") " +
                "VALUES (@Name, @ArticleNumber, @MeasureUnitID," +
                "@Description, @InArchive, @VAT, @TradeMargin, @RetailMargin," +
                "@NetCost, @TradePrice, @RetailPrice, @CategoryID);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ArticleNumber", article);
                cmd.Parameters.AddWithValue("@MeasureUnitID", measureunitID);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@InArchive", archivecheck);
                cmd.Parameters.AddWithValue("@VAT", vat);
                cmd.Parameters.AddWithValue("@TradeMargin", trademargin);
                cmd.Parameters.AddWithValue("@RetailMargin", retailmargin);
                cmd.Parameters.AddWithValue("@NetCost", netcost);
                cmd.Parameters.AddWithValue("@TradePrice", tradeprice);
                cmd.Parameters.AddWithValue("@RetailPrice", retailprice);
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
                cmd.Parameters.AddWithValue("@GoodID", goodID);
                cmd.ExecuteNonQuery();
            }
        }



    }
}
