using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary
{
    public class Contractor
    {
        public static void Update(int contractorID, string type, 
            string name, string fullname, string telephone, 
            string email, string inn, string kpp, string okpo, 
            string oktmo, string ogrn, string paymentacc, string bank, 
            string bik, string corracc, string postaddr, string legaladdr, 
            string consaddr, string director, 
            string genacc, string reason, int categoryID, string manager, string description)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Contractor\" " +
                "SET " +
                "\"Type\"=@Type, " +
                "\"Name\"=@Name, " +
                "\"FullName\"=@FullName, " +
                "\"Telephone\"=@Telephone, " +
                "\"Email\"=@Email, " +
                "\"INN\"=@INN, \"KPP\"=@KPP, \"OKPO\"=@OKPO, " +
                "\"OKTMO\"=@OKTMO, \"OGRN\"=@OGRN, " +
                "\"PaymentAccount\"=@PaymentAccount, " +
                "\"Bank\"=@Bank, \"BIK\"=@BIK, " +
                "\"CorrAccount\"=@CorrAccount, " +
                "\"PostAddress\"=@PostAddress, " +
                "\"LegalAddress\"=@LegalAddress, " +
                "\"ConsigneeAddress\"=@ConsigneeAddress, " +
                "\"Director\"=@Director, " +
                "\"GeneralAccountant\"=@GeneralAccountant, " +
                "\"Reason\"=@Reason, " +
                "\"Manager\"=@Manager, " +
                "\"Description\"=@Description, " +
                "\"CategoryID\"=@CategoryID " +
                "WHERE \"ContractorID\" =@ContractorID;",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Telephone", telephone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@INN", inn);
                cmd.Parameters.AddWithValue("@KPP", kpp);
                cmd.Parameters.AddWithValue("@OKPO", okpo);
                cmd.Parameters.AddWithValue("@OKTMO", oktmo);
                cmd.Parameters.AddWithValue("@OGRN", ogrn);
                cmd.Parameters.AddWithValue("@PaymentAccount", paymentacc);
                cmd.Parameters.AddWithValue("@Bank", bank);
                cmd.Parameters.AddWithValue("@BIK", bik);
                cmd.Parameters.AddWithValue("@CorrAccount", corracc);
                cmd.Parameters.AddWithValue("@PostAddress", postaddr);
                cmd.Parameters.AddWithValue("@LegalAddress", legaladdr);
                cmd.Parameters.AddWithValue("@ConsigneeAddress", consaddr);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@GeneralAccountant", genacc);
                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@Manager", manager);
                cmd.Parameters.AddWithValue("@Description", description);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Insert(string type, string name, string fullname, string telephone, 
            string email, string inn, string kpp, string okpo, string oktmo, string ogrn, 
            string paymentacc, string bank, string bik, string corracc, string postaddr, string legaladdr, 
            string consaddr, string director, string genacc, string reason, int categoryID, string manager, string description)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Contractor\" " +
                "(\"Type\", \"Name\", \"FullName\", \"Telephone\", \"Email\", \"INN\", \"KPP\", \"OKPO\", \"OKTMO\", \"OGRN\", \"PaymentAccount\", " +
                "\"Bank\", \"BIK\", \"CorrAccount\", \"PostAddress\", \"LegalAddress\", \"ConsigneeAddress\", " +
                "\"Director\", \"GeneralAccountant\", \"Reason\", \"CategoryID\", \"Description\", \"Manager\") " +
                "VALUES (@Type, @Name, @FullName, @Telephone, @Email, @INN, @KPP, @OKPO, @OKTMO, @OGRN, @PaymentAccount, " +
                "@Bank, @BIK, @CorrAccount, @PostAddress, @LegalAddress, @ConsigneeAddress, " +
                "@Director, @GeneralAccountant, @Reason, @CategoryID, @Description, @Manager);",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@Telephone", telephone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@INN", inn);
                cmd.Parameters.AddWithValue("@KPP", kpp);
                cmd.Parameters.AddWithValue("@OKPO", okpo);
                cmd.Parameters.AddWithValue("@OKTMO", oktmo);
                cmd.Parameters.AddWithValue("@OGRN", ogrn);
                cmd.Parameters.AddWithValue("@PaymentAccount", paymentacc);
                cmd.Parameters.AddWithValue("@Bank", bank);
                cmd.Parameters.AddWithValue("@BIK", bik);
                cmd.Parameters.AddWithValue("@CorrAccount", corracc);
                cmd.Parameters.AddWithValue("@PostAddress", postaddr);
                cmd.Parameters.AddWithValue("@LegalAddress", legaladdr);
                cmd.Parameters.AddWithValue("@ConsigneeAddress", consaddr);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@GeneralAccountant", genacc);
                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Manager", manager);

                cmd.ExecuteNonQuery();
            }
        }
        public static void Delete(int contractorID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"Contractor\" " +
                "WHERE \"ContractorID\" = @ContractorID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@ContractorID", contractorID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
