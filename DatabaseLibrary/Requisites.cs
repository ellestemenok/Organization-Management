﻿using Npgsql;

namespace DatabaseLibrary
{
    public class Requisites
    {
        public static void Update(int organizationID, string type, string name, string fullName, string consigneeAddress, string postAddress, string legalAddress, string telephoneNumber, string email, string inn, string kpp, string okpo, string okvad, string ogrn, string director, string generalAccountant, bool payingVAT, string okpd)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"Organization\" " +
                            "SET \"Type\" = @Type, " +
                            "\"Name\" = @Name, " +
                            "\"FullName\" = @FullName, " +
                            "\"ConsigneeAddress\" = @ConsigneeAddress, " +
                            "\"PostAddress\" = @PostAddress, " +
                            "\"LegalAddress\" = @LegalAddress, " +
                            "\"TelephoneNumber\" = @TelephoneNumber, " +
                            "\"Email\" = @Email, " +
                            "\"INN\" = @INN, " +
                            "\"KPP\" = @KPP, " +
                            "\"OKPO\" = @OKPO, " +
                            "\"OKVAD\" = @OKVAD, " +
                            "\"OGRN\" = @OGRN, " +
                            "\"Director\" = @Director, " +
                            "\"GeneralAccountant\" = @GeneralAccountant, " +
                            "\"PayingVAT\" = @PayingVAT, " +
                            "\"OKPD\" = @OKPD " +
                            "WHERE \"OrganizationID\" = 1",
                            Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@ConsigneeAddress", consigneeAddress);
                cmd.Parameters.AddWithValue("@PostAddress", postAddress);
                cmd.Parameters.AddWithValue("@LegalAddress", legalAddress);
                cmd.Parameters.AddWithValue("@TelephoneNumber", telephoneNumber);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@INN", inn);
                cmd.Parameters.AddWithValue("@KPP", kpp);
                cmd.Parameters.AddWithValue("@OKPO", okpo);
                cmd.Parameters.AddWithValue("@OKVAD", okvad);
                cmd.Parameters.AddWithValue("@OGRN", ogrn);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@GeneralAccountant", generalAccountant);
                cmd.Parameters.AddWithValue("@PayingVAT", payingVAT);
                cmd.Parameters.AddWithValue("@OKPD", okpd);
                cmd.Parameters.AddWithValue("@OrganizationID", organizationID);

                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdatePaymentAccount(int accountID, string name, string accountNumber,
            string bankname, string corrAccount, string bik)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"PaymentAccount\" " +
                            "SET \"Name\" = @Name, " +
                            "\"AccountNumber\" = @AccountNumber, " +
                            "\"BankName\" = @BankName, " +
                            "\"СorrAccount\" = @CorrAccount, " +
                            "\"BIK\" = @BIK " +
                            "WHERE \"AccountID\" = @AccountID",
                            Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@BankName", bankname);
                cmd.Parameters.AddWithValue("@CorrAccount", corrAccount);
                cmd.Parameters.AddWithValue("@BIK", bik);

                cmd.ExecuteNonQuery();
            }
        }
        public static void InsertPaymentAccount(string name, string accountNumber,
            string bankName, string corrAccount, string bik)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"PaymentAccount\" " +
                "(\"Name\", \"AccountNumber\", \"BankName\", \"СorrAccount\", \"BIK\") " +
                "VALUES (@Name, @AccountNumber, @BankName, @CorrAccount, @BIK)",
                Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@BankName", bankName);
                cmd.Parameters.AddWithValue("@CorrAccount", corrAccount);
                cmd.Parameters.AddWithValue("@BIK", bik);

                cmd.ExecuteNonQuery();
            }
        }
        public static void DeletePaymentAccount(int accountID)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " +
                "public.\"PaymentAccount\" " +
                "WHERE \"AccountID\" = @AccountID", Autorization.npgSqlConnection))
            {
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
