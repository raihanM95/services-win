using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EzeilsData.DAL
{
    public class DataManage
    {
        public string ZeilsConnnectionString = ConfigurationManager.ConnectionStrings["ZeilsConnection"].ConnectionString;
        public string EZeilsConnnectionString = ConfigurationManager.ConnectionStrings["EZeilsConnection"].ConnectionString;
        public int count;

        public DataTable ZeilsGetDataTable(string query)
        {
            SqlConnection con = new SqlConnection(ZeilsConnnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }
        }

        public DataTable EZeilsGetDataTable(string query)
        {
            SqlConnection con = new SqlConnection(EZeilsConnnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                con.Close();

                return dt;
            }
            catch (Exception ex)
            {
                con.Close();
                return dt;
            }
        }

        public bool EZeilsExecute(string query)
        {
            SqlConnection con = new SqlConnection(EZeilsConnnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                con.Close();
                return false;
            }
        }
    }
}
