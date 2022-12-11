using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebViewCrud
{
    public class CustomerDAL
    {
        private static SqlConnection conn = new SqlConnection(DALC.sqlConnectionString);
        public static DataView GetData()
        {
            if (conn.State != ConnectionState.Open) conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP(10) * FROM Customers;", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            return ds.Tables[0].DefaultView;
        }

        public static void UpdateRow(string CustomerID, string ContactName, string City, string Country)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateCustomerRow", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteRow(string CustomerID)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", int.Parse(CustomerID));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void CreateRow(string ContactName,
            string City, string Country)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlCommand cmd = new SqlCommand("CreateCustomerRow", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}