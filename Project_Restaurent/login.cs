using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent
{
    public partial class login : Form
    {
        public static string userName = "";
        public static string password = "";

        public login()
        {
            InitializeComponent();
        }
        
        //kiểm tra đăng nhập
        public bool isCorrect(string query)
        {
            DataTable data = new DataTable();
            data = DataProvider.Intance.ExcuteQuery(query);
            
            if(data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //đăng nhập
        public void loginUser()
        {
            string userName = txt_UserName.Text;
            string passWord = txt_Password.Text;

            string query = "select * from account where username = '"+userName+"' and password = '"+passWord+"' ";
            
            if (txt_Password.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (this.isCorrect(query))
                {
                    TableManager T = new TableManager();
                    this.Hide();
                    T.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.loginUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
