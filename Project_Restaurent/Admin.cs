using Project_Restaurent.Controller;
using Project_Restaurent.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Project_Restaurent
{
    public partial class Admin : Form
    {

        public Admin()
        {
            InitializeComponent();


            //load list
            loadFormCategoryFood();
            LoadlistFood();
            LoadlistTable();
            LoadListCategory();
            LoadListAccount();
            loadListPermission();
            loadDateTimePicker();

            //select and enable textbox
            selectIndex();
            txt_Id_Category.Enabled = false;
            txt_Id_Table.Enabled = false;
            txt_Id_Account.Enabled = false;
        }

        //load list permission
        public void loadListPermission()
        {
            txt_Permission.Items.Add("staff");
            txt_Permission.Items.Add("Admin");
        }

        //select index compoBox
        public void selectIndex()
        {
            if (txt_Permission.Text != "" || txt_List_Category.Text != "" || txt_list_category_search.Text != "")
            {
                txt_Permission.SelectedIndex = 0;
                txt_List_Category.SelectedIndex = 0;
                txt_list_category_search.SelectedIndex = 0;
            }
           
        }

        //load list FOOD
        public void LoadlistFood()
        {
            string query = "select f.*, c.name as" +
                " category_name from food f, category_food c where f.category_id = c.id";
            DataTable data = AdminController.Intance.loadlist(query);
            dgv_Food.DataSource = data;
        }

        //load list TABLE
        public void LoadlistTable()
        {
            string query = "select * from seat_food";
            DataTable data = AdminController.Intance.loadlist(query);
            dgv_Seat_Food.DataSource = data;
            
        }

        //load list CATEGORY
        public void LoadListCategory()
        {
            string query = "select * from category_food";
            DataTable data = AdminController.Intance.loadlist(query);
            dgv_Category_Food.DataSource = data;
        }

        //load list ACCOUNT
        public void LoadListAccount()
        {
            string query = "select id, username, is_admin as Admin from account";
            DataTable data = AdminController.Intance.loadlist(query);
            dgv_Account.DataSource = data;
        }
       
        //load list form Category
        public void loadFormCategoryFood()
        {
            txt_List_Category.Items.Clear();
            txt_List_Category.ResetText();
            txt_list_category_search.Items.Clear();
            txt_list_category_search.ResetText();
            string query = "select * from category_food";
            List<TableModel> listCategorys = AdminController.Intance.loadListCategory(query);
            foreach (TableModel item in listCategorys)
            {
                txt_List_Category.Items.Add(item.Name);
                txt_list_category_search.Items.Add(item.Name);
            }
        }

        //kiễm tra username đã tồn tại bằng id
        public bool isExistsUser(string id, string table)
        {

            string query = "select username from " + table + " where id = N'" + id + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        //kiễm tra username đã tồn tại bằng username
        public bool isExistsUserUS(string name, string table)
        {

            string query = "select username from " + table + " where username = N'" + name + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //kiềm tra xem id đã tồn tại
        public bool isExists(string name, string table)
        {
            string query = "select id from " + table + " where name = N'" + name + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //lấy ID của item
        public int getId(string name, string table)
        {
            int id = 0;
            string query = "select id from " + table + " where name =  N'" + name + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                id = (int)row["id"];
            }
            return id;
        }

        //lấy Name của item
        public string getName(string id, string table)
        {
            string name = "";
            string query = "select name from " + table + " where id =  " + id + "";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                name = row["name"].ToString();
            }
            return name;
        }

        //tìm kiếm category_food
        public void searchCategory(object sender, EventArgs e)
        {
            try
            {
                int category_id = this.getId(txt_list_category_search.Text, "category_food");
                string query = "select * from food where category_id = " + category_id + "";
                DataTable dataSearch = AdminController.Intance.search(query);
                dgv_Food.DataSource = dataSearch;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //thêm food
        public void insertFood(object sender, EventArgs e)
        {
            try
            {
                if (txt_Name_Food.Text == "" || txt_Price_Food.Text == "" || txt_Unit_Food.Text == "" || txt_List_Category.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    if (this.isExists(txt_Name_Food.Text, "food") != true)
                    {
                        int category_id = this.getId(txt_List_Category.Text, "category_food");
                        string query = "insert into food(name, category_id, price, unit) " +
                        "values(N'" + txt_Name_Food.Text + "', " + category_id + ", " + txt_Price_Food.Text + ", N'" + txt_Unit_Food.Text + "' )";
                        AdminController.Intance.insert(query);
                        LoadlistFood();
                        MessageBox.Show("thêm thành công", "thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Tên món đã tồn tại");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //sửa food
        public void updateFood(object sender, EventArgs e)
        {
            try
            {
                if (this.isExists(txt_Name_Food.Text, "food"))
                {
                    int category_id = this.getId(txt_List_Category.Text, "category_food");
                    string query = "update food set price = " + txt_Price_Food.Text + ", category_id = " + category_id + ", unit = N'" + txt_Unit_Food.Text + "' where name = N'" + txt_Name_Food.Text + "'";
                    AdminController.Intance.update(query);
                    MessageBox.Show("Update thành công");
                    LoadlistFood();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //xóa food
        public void destroyfood(object sender, EventArgs e)
        {
            try
            {
                if (this.isExists(txt_Name_Food.Text, "food"))
                {
                    string query = "delete from food where name = N'" + txt_Name_Food.Text + "' ";
                    AdminController.Intance.delete(query);
                    MessageBox.Show("xóa thành công");
                    LoadlistFood();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Click bảng hiển thị ra form
        private void dgv_Food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_Food.CurrentRow.Index;
            txt_Name_Food.Text = dgv_Food.Rows[i].Cells[1].Value.ToString();
            txt_Price_Food.Text = dgv_Food.Rows[i].Cells[3].Value.ToString();
            txt_Unit_Food.Text = dgv_Food.Rows[i].Cells[4].Value.ToString();
            txt_List_Category.SelectedItem = dgv_Food.Rows[i].Cells[4].Value.ToString();
        }

        //--------------------------------------SEAT_FOOD------------------------------------------//

        //thêm bàn
        public void insertTable(object sender, EventArgs e)
        {
            try
            {
                if (txt_Name_Table.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    if (this.isExists(txt_Name_Table.Text, "seat_food") != true)
                    {
                        string query = "insert into seat_food(name) values(N'" + txt_Name_Table.Text + "')";
                        AdminController.Intance.insert(query);
                        LoadlistTable();
                        TableManager T = new TableManager();
                        T.Refresh();
                        MessageBox.Show("thêm thành công", "thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Tên Bàn đã tồn tại");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //sửa bàn
        public void updateTable(object sender, EventArgs e)
        {
            try
            {
                string nameTable = this.getName(txt_Id_Table.Text, "seat_food");
                if (this.isExists(nameTable, "seat_food"))
                {
                    int idTable = this.getId(nameTable, "seat_food");
                    string query = "update seat_food set name = N'" + txt_Name_Table.Text + "' where id = " + (int)idTable + " ";
                    AdminController.Intance.update(query);
                    MessageBox.Show("Update thành công");
                    LoadlistTable();
                }
                else
                {
                    MessageBox.Show("Bàn không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //xóa bàn
        public void destroyTable(object sender, EventArgs e)
        {
            try
            {
                if (this.isExists(txt_Name_Table.Text, "seat_food"))
                {
                    string query = "delete from seat_food where name = N'" + txt_Name_Table.Text + "' ";
                    AdminController.Intance.delete(query);
                    MessageBox.Show("xóa thành công");
                    LoadlistTable();
                }
                else
                {
                    MessageBox.Show("Bàn không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //click chuyển dữ liệu ra form
        private void dgv_Seat_Food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_Seat_Food.CurrentRow.Index;
            txt_Name_Table.Text = dgv_Seat_Food.Rows[i].Cells[1].Value.ToString();
            txt_Id_Table.Text = dgv_Seat_Food.Rows[i].Cells[0].Value.ToString();

        }

        //--------------------------------------CATEGORY_FOOD-------------------------------------------//
        //insert category
        public void insertCategory(object sender, EventArgs e)
        {
            try
            {
                if (txt_Category_Food.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    if (this.isExists(txt_Category_Food.Text, "category_food") != true)
                    {
                        string query = "insert into category_food (name) values (N'" + txt_Category_Food.Text + "')";
                        AdminController.Intance.insert(query);
                        loadFormCategoryFood();
                        LoadListCategory();
                        selectIndex();
                        MessageBox.Show("thêm thành công", "thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Tên Danh mục đã tồn tại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //update category
        public void updateCategory(object sender, EventArgs e)
        {
            try
            {
                string nameCategory = this.getName(txt_Id_Category.Text, "category_food");
                if (this.isExists(nameCategory, "category_food"))
                {
                    int idCategory = this.getId(nameCategory, "category_food");
                    string query = "update category_food set name = N'" + txt_Category_Food.Text + "' where id = " + (int)idCategory + " ";
                    AdminController.Intance.update(query);
                    MessageBox.Show("Update thành công");
                    loadFormCategoryFood();
                    LoadListCategory();
                    selectIndex();
                }
                else
                {
                    MessageBox.Show("Bàn không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //destroy category
        public void destroyCategory(object sender, EventArgs e)
        {
            try
            {
                if (this.isExists(txt_Category_Food.Text, "category_food"))
                {
                    string idCategory = txt_Id_Category.Text;
                    string query = "delete from category_food where id = "+idCategory+" ";
                    AdminController.Intance.delete(query);
                    MessageBox.Show("xóa thành công");
                    LoadListCategory();
                }
                else
                {
                    MessageBox.Show("Bàn không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //click chuyễn dữ liệu ra form
        private void dgv_Category_Food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_Category_Food.CurrentRow.Index;
            txt_Category_Food.Text = dgv_Category_Food.Rows[i].Cells[1].Value.ToString();
            txt_Id_Category.Text = dgv_Category_Food.Rows[i].Cells[0].Value.ToString();
        }

        //-------------------------------------Account-----------------------------------//
        public void insertAccount(object sender, EventArgs e)
        {
            try
            {
                if ( txt_Username.Text == "" || txt_Permission.Text == null || txt_Password.Text == "" || txt_Repassword.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    if (this.isExistsUser(txt_Username.Text, "account") != true && txt_Password.Text == txt_Repassword.Text)
                    {
                        int index = txt_Permission.SelectedIndex;
                        string query = "insert into account (username, password, is_admin) " +
                        "values (N'" + txt_Username.Text + "', N'" + txt_Password.Text + "', " + index + " )";
                        AdminController.Intance.insert(query);
                        LoadListAccount();
                        MessageBox.Show("thêm tài khoản thành công", "thông báo", MessageBoxButtons.OK);
                    }
                    else if(txt_Password.Text != txt_Repassword.Text)
                    {
                        MessageBox.Show("Mật khẩu không khớp");
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateAccount(object sender, EventArgs e)
        {
            try
            {
                
                if (this.isExistsUser(txt_Id_Account.Text, "account"))
                {
                    if(txt_Password.Text != "" && txt_Repassword.Text != "")
                    {
                        if (txt_Password.Text == txt_Repassword.Text)
                        {
                            if(this.isExistsUserUS(txt_Username.Text, "account") == false)
                            {
                                int indexSelect = txt_Permission.SelectedIndex;
                                string idAccount = txt_Id_Account.Text;
                                string query = "update account set username = N'" + txt_Username.Text + "', " +
                                    "password = '" + txt_Password.Text + "', is_admin = " + indexSelect + " where id = " + idAccount + "";
                                AdminController.Intance.update(query);
                                MessageBox.Show("Update thành công");
                                LoadListAccount();
                            }
                            else
                            {
                                MessageBox.Show("username đã tồn tại");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không khớp");
                        }
                    }
                    else
                    {
                        if (this.isExistsUserUS(txt_Username.Text, "account") == false)
                        {
                            int indexSelect = txt_Permission.SelectedIndex;
                            string idAccount = txt_Id_Account.Text;
                            string query = "update account set username = N'" + txt_Username.Text + "', is_admin = " + indexSelect + " where id = " + idAccount + "";
                            AdminController.Intance.update(query);
                            MessageBox.Show("Update thành công");
                            LoadListAccount();
                        }
                        else
                        {
                            MessageBox.Show("username đã tồn tại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void DestroyAccount(object sender, EventArgs e)
        {
            
        }

        private void dgv_Account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_Account.CurrentRow.Index;
            txt_Username.Text = dgv_Account.Rows[i].Cells[1].Value.ToString();
            txt_Id_Account.Text = dgv_Account.Rows[i].Cells[0].Value.ToString();
            txt_Permission.SelectedIndex = (int)dgv_Account.Rows[i].Cells[2].Value;
        }

        private void txt_thong_ke_Click(object sender, EventArgs e)
        {
                DateTime datefrom = dt_from.Value;
                DateTime dateTo = dt_to.Value;
                DataTable data = AdminController.Intance.loadListDanhThu(datefrom, dateTo);
                dgv_doanh_thu.DataSource = data;
        }
        public void loadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dt_from.Value = new DateTime(today.Year, today.Month, 1);
            dt_to.Value = dt_from.Value.AddMonths(1).AddDays(-1);
        }
    }
}
