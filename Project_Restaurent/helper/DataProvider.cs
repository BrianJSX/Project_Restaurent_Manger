using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent
{
    
    class DataProvider
    {
        private SqlConnection __connecting;
        private SqlCommand __command;
        private SqlDataAdapter __adapter;
        private static DataProvider __intance;
        private string __connectSTR = @"Data Source=DESKTOP-DATCOAE\SQLEXPRESS;Initial Catalog=QuanLyQuanAn_V3;Integrated Security=True";

        public static DataProvider Intance {
            get { if (__intance == null) __intance = new DataProvider(); return __intance; }
            private set => __intance = value;
        }

        public DataProvider()
        {
        }

        public DataTable ExcuteQuery(string query)
        {
            DataTable __data = new DataTable();
            this.__connecting = new SqlConnection(__connectSTR);
            this.__connecting.Open();
            __data.Clear();
            this.__command = new SqlCommand(query, this.__connecting);
            this.__adapter = new SqlDataAdapter(this.__command);
            this.__adapter.Fill(__data);
            this.__command.ExecuteNonQuery();
            return __data;
        }
        public void ExcuteQueryIU(string query)
        {
            this.__connecting = new SqlConnection(__connectSTR);
            this.__connecting.Open();
            this.__command = new SqlCommand(query, this.__connecting);
            this.__command.ExecuteNonQuery();
        }
    }
}
