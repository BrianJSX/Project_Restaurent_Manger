using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Restaurent.Controller
{
    class BillController
    {
        private static BillController __instance;

        public BillController()
        {
        }

        internal static BillController Instance {
            get { if (__instance == null) __instance = new BillController(); return __instance; }
            private set => __instance = value; 
        }

        public void InsertBill(string idTable)
        {
            string query1 = "insert into bill (checkin_at, checkout_at, seat_id, status)" +
                                "values ( GETDATE(), GETDATE(), " + idTable + ", 0 ) ";
            DataProvider.Intance.ExcuteQueryIU(query1);
        }

        public void InsertBillDetail(string billId, string foodId)
        {
            string query = "insert into bill_detail(bill_id, food_id, quantity, staff)" +
                            "values (" + billId + ", " + foodId + ", 1, 2 )";
            DataProvider.Intance.ExcuteQueryIU(query);
        }

        public void UpdateBillDetailFood(string billId, string foodId, int quantity)
        {
            string query = "UPDATE bill_detail SET quantity = "+quantity+" " +
                            "WHERE bill_id = "+billId+" and food_id = "+foodId+" ";
            DataProvider.Intance.ExcuteQueryIU(query);
        }
        public void checkOutBill(string billId, string totalPrice)
        {
            string query = "UPDATE bill SET status = 1, totalPrice = "+totalPrice+"" +
                            "WHERE id = " + billId + "";
            DataProvider.Intance.ExcuteQueryIU(query);
        }
        public void destroyFoodInTable(string billId, string FoodId)
        {
            string query = "DELETE FROM bill_detail WHERE bill_id = "+billId+" and food_id = "+FoodId+"";
            DataProvider.Intance.ExcuteQueryIU(query);
        }
    }
}
