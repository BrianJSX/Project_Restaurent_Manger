using Project_Restaurent.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent.Controller
{
    class AdminController
    {
        private static AdminController __intance;

        public AdminController()
        {

        }
        public static AdminController Intance 
        {
            get { if (__intance == null) __intance = new AdminController(); return __intance; }
            private set => __intance = value; 
        }

        //load tất cả danh sách food 
        public DataTable loadlist(string query)
        {
            DataTable list = DataProvider.Intance.ExcuteQuery(query);
            return list;
        }

        //load tất cả danh mục
        public List<TableModel> loadListCategory(string query)
        {
            List<TableModel> listData = new List<TableModel>();
            DataTable lists = DataProvider.Intance.ExcuteQuery(query);

            foreach(DataRow item in lists.Rows)
            {
                TableModel table = new TableModel(item);
                listData.Add(table);
            }
            return listData;
        }
        //Thêm thức ăn 
        public void insert(string query)
        {
            try
            {
                DataProvider.Intance.ExcuteQueryIU(query);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //sửa thức ăn
        public void update(string query)
        {
            try
            {
                DataProvider.Intance.ExcuteQueryIU(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //xóa thức ăn
        public void delete(string query)
        {
            try
            {
                DataProvider.Intance.ExcuteQueryIU(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //tìm kiếm thức ăn
        public DataTable search(string query)
        {
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            return data;
        }
        //load List Danh thu
        public DataTable loadListDanhThu(DateTime checkin , DateTime checkout)
        {
            string query = "select a.name, b.totalPrice as Total, b.checkin_at, b.checkout_at " +
                            "from seat_food as a, bill as b where a.id = b.seat_id" +
                            " and checkin_at >= '" + checkin + "' and checkout_at <= '" + checkout + "'";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);
            return data;
        }


    }
}
