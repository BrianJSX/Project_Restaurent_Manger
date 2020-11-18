using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Restaurent.helper
{
    class TableModel
    {
        private int __id;
        private string __name;

        public string Name
        {
            get => this.__name;
            set => this.__name = value;
        }
        public int Id
        {
            get => this.__id;
            set => this.__id = value;
        }

        public TableModel(int id, string name)
        {
            this.__id = id;
            this.__name = name;
        }
        public TableModel(DataRow row)
        {
            this.__id = (int)row["id"];
            this.__name = row["name"].ToString();
        }
       
    }
}
