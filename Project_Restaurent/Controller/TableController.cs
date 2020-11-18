using Project_Restaurent.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent.Controller
{
    class TableController
    {
        private static TableController __intance;

        public TableController()
        {
        }

        public static TableController Intance {
            get { if (__intance == null) __intance = new TableController(); return __intance; }
            private set => __intance = value;
        }
        public List<TableModel> getTableList()
        {
            List<TableModel> tablelist = new List<TableModel>();
            string query = "select * from seat_food";
            DataTable data = DataProvider.Intance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TableModel table = new TableModel(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
    }
}
