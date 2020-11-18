using Project_Restaurent.Controller;
using Project_Restaurent.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent
{
    public partial class TableManager : Form
    {
        private List<TableModel> __tablelist;

        public TableManager()
        {
            InitializeComponent();
            loadTable();
        }

        public void loadTable()
        {
            list_TableSeat.Controls.Clear();
            txt_Category_Food_index.Items.Clear();
            loadListTable();
            loadListCategory();
            txt_Category_Food_index.SelectedIndex = 0;
            txt_Name_Food_index.SelectedIndex = 0;
        }

        public void getListFoodInCategory(int id)
        {
            txt_Name_Food_index.Items.Clear();
            txt_Name_Food_index.ResetText();
            string query = "select a.name from food as a, category_food as b " +
                "where a.category_id = b.id and a.category_id = " + id + "";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                txt_Name_Food_index.Items.Add(item["name"]);
            }

        }

        public int getIdCategory(string name)
        {
            int id = 0;
            string query = "select id from category_food where name = N'" + name + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                id = (int)item["id"];
            }
            return id;
        }

        public bool getTableEmpty(int id)
        {
            string query = "select * from bill where seat_id = " + id + " and status = 0";
            DataTable data =  DataProvider.Intance.ExcuteQuery(query);
            if(data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void loadListCategory()
        {
            string query = "select * from category_food";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                txt_Category_Food_index.Items.Add(item["name"]);
            }
        }

        public void loadListTable()
        {
            this.__tablelist= TableController.Intance.getTableList();

            foreach(TableModel item in __tablelist)
            {
                Button btn = new Button();
                btn.Width = 64;
                btn.Height = 64;
                btn.Name = "btn_name" + item.Id;
                btn.Click += new System.EventHandler(this.btnButton_Click);
                btn.Tag = item;

                switch (getTableEmpty(item.Id))
                {
                    case true:
                        btn.BackColor = Color.Purple;
                        btn.Text = item.Name;
                        btn.Text = item.Name + Environment.NewLine + "Có người";
                        btn.BackgroundImage = Properties.Resources.dinner;
                        break;
                    case false:
                        btn.BackColor = Color.Aqua;
                        btn.Text = item.Name + Environment.NewLine + "Trống";
                        btn.BackgroundImage = Properties.Resources.dinner;
                        break;
                    default:
                        break;
                }
                list_TableSeat.Controls.Add(btn);
            }
            
        }
        //lấy id bill từ table
        public string getIdBillTable(string id)
        {
            string idBill = "";
            string query = "select b.id from seat_food as a, bill as b where a.id = b.seat_id and a.id = "+id+" and status = 0";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                idBill = item["id"].ToString() ;
            }
            return idBill;
        }

        //event
        public void btnButton_Click(object sender, EventArgs e)
        {
            int id = ((sender as Button).Tag as TableModel).Id;
            txt_id_table.Value = id;
            txt_id_bill.Text = this.getIdBillTable(id.ToString());
            showBill(id.ToString());
        }

        public void showBill(string id)
        {
            try
            {
                string query = "select d.name as TENMON, d.price as GIA , c.quantity as SOLUONG, c.quantity*d.price as TONG" +
                "           from seat_food as a, bill as b , bill_detail as c , food as d " +
                "           where a.id = b.seat_id and b.id = c.bill_id and c.food_id = d.id and a.id = " + id + " and b.status = 0";
                DataTable data = DataProvider.Intance.ExcuteQuery(query);
                dgv_Food_index.DataSource = data;
                int sum = 0;
                foreach (DataRow item in data.Rows)
                {
                    sum += Convert.ToInt32(item["TONG"]);
                }
                txt_total_bill.Text = sum.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quảnLýAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin A = new Admin();
            this.Hide();
            A.ShowDialog();   
            this.loadTable();
            this.Show();
        }

        private void txt_Category_Food_index_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoryName = txt_Category_Food_index.Text;
            int idCategory = this.getIdCategory(categoryName);
            this.getListFoodInCategory(idCategory);
            txt_Name_Food_index.SelectedIndex = 0;
        }
        //lấy id của thức ăn
        public string getIdFood(string name)
        {
            string idFood = "";
            string query = "select id as ID from food where name = N'" + name + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                idFood = item["ID"].ToString();
            }
            return idFood;
        }
        //kiểm tra food đã tồn tại trong bill chưa
        public bool isFoodInBillDetail(string idTable, string idFood, string billId)
        {

            string query = "select c.id " +
                           "from seat_food as a, bill as b, bill_detail as c " +
                           "where a.id = b.seat_id and b.id = c.bill_id and a.id = "+idTable+" and c.food_id = "+idFood+" and c.bill_id = "+billId+"";
            DataTable data =  DataProvider.Intance.ExcuteQuery(query);
            if(data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        
        public int getQuantityFood(string idTable, string idFood)
        {
            int quantity = 0;
            string query = "select c.quantity as quantity " +
                           "from seat_food as a, bill as b, bill_detail as c " +
                           "where a.id = b.seat_id and b.id = c.bill_id " +
                           "and a.id = " + idTable + " and c.food_id = " + idFood + "";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                quantity = (int)item["quantity"];
            }
            return quantity;
        }
        //thêm món vào bàn
        private void btn_Insert_Food_Table_Click(object sender, EventArgs e)
        {
            try
            {
                string nameFood = txt_Name_Food_index.Text;
                string idTable = txt_id_table.Value.ToString();
                string idFood = this.getIdFood(nameFood);
                string idBill = txt_id_bill.Text;

                if(idBill == "")
                {
                    BillController.Instance.InsertBill(idTable);
                    idBill = this.getIdBillTable(idTable);
                    BillController.Instance.InsertBillDetail(idBill, idFood);
                    showBill(idTable);
                    txt_id_bill.Text = idBill;
                    MessageBox.Show("Thêm món thành công");
                }
                else if(idBill == this.getIdBillTable(idTable))
                {
                    if (this.isFoodInBillDetail(idTable, idFood, idBill))
                    {
                        int quantity = getQuantityFood(idTable, idFood) + 1;
                        BillController.Instance.UpdateBillDetailFood(idBill, idFood, quantity);
                        showBill(idTable);
                        MessageBox.Show("Update món thành công");
                    }
                    else
                    {
                        BillController.Instance.InsertBillDetail(idBill, idFood);
                        showBill(idTable);
                        MessageBox.Show("Thêm món thành công");
                    }
                }
                loadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //thanh toán
        private void txt_bill_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                string idTable = txt_id_table.Value.ToString();
                string idBill = txt_id_bill.Text;
                string totalPrice = txt_total_bill.Text;
                BillController.Instance.checkOutBill(idBill, totalPrice);
                txt_id_bill.Text = "";
                showBill(idTable);
                loadTable();
                MessageBox.Show("Thanh toán thành công!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không có đơn hàng để thanh toán");
            }
            
        }

        private void txt_destroy_food_Click(object sender, EventArgs e)
        {
            try
            {
                string nameFood = txt_Name_Food_index.Text;
                string idTable = txt_id_table.Value.ToString();
                string idFood = this.getIdFood(nameFood);
                string idBill = txt_id_bill.Text;
                if (this.isFoodInBillDetail(idTable, idFood, idBill))
                {
                    BillController.Instance.destroyFoodInTable(idBill, idFood);
                    showBill(idTable);
                }
                else
                {
                    MessageBox.Show("Không có món nào để xóa trên bàn này");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void dgv_Food_index_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_Food_index.CurrentRow.Index;
            txt_Name_Food_index.Text = dgv_Food_index.Rows[index].Cells[0].Value.ToString();
        }
    }
}
