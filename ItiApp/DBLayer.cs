﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiApp
{
    class DBLayer
    {
        public static DataTable select(string query)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adpt.Fill(dt);

            return dt;
        }

        public static int dml(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int roweffect = cmd.ExecuteNonQuery();
                con.Close();

                return roweffect;
            }
            catch (Exception ex)
            {

                return 0;
                
            }
        }
    }
}
