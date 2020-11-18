namespace Project_Restaurent
{
    partial class TableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list_TableSeat = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_Food_index = new System.Windows.Forms.DataGridView();
            this.btn_Insert_Food_Table = new System.Windows.Forms.Button();
            this.txt_Category_Food_index = new System.Windows.Forms.ComboBox();
            this.txt_Name_Food_index = new System.Windows.Forms.ComboBox();
            this.txt_id_table = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_total_bill = new System.Windows.Forms.TextBox();
            this.total = new System.Windows.Forms.Label();
            this.txt_bill_checkout = new System.Windows.Forms.Button();
            this.txt_id_bill = new System.Windows.Forms.TextBox();
            this.txt_destroy_food = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Food_index)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id_table)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýAdminToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýAdminToolStripMenuItem
            // 
            this.quảnLýAdminToolStripMenuItem.Name = "quảnLýAdminToolStripMenuItem";
            this.quảnLýAdminToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.quảnLýAdminToolStripMenuItem.Text = "Quản lý Admin";
            this.quảnLýAdminToolStripMenuItem.Click += new System.EventHandler(this.quảnLýAdminToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemThôngTinToolStripMenuItem});
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông Tin Cá Nhân";
            // 
            // xemThôngTinToolStripMenuItem
            // 
            this.xemThôngTinToolStripMenuItem.Name = "xemThôngTinToolStripMenuItem";
            this.xemThôngTinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xemThôngTinToolStripMenuItem.Text = "Xem Thông tin";
            // 
            // list_TableSeat
            // 
            this.list_TableSeat.Location = new System.Drawing.Point(0, 27);
            this.list_TableSeat.Name = "list_TableSeat";
            this.list_TableSeat.Size = new System.Drawing.Size(882, 237);
            this.list_TableSeat.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Food_index);
            this.panel2.Location = new System.Drawing.Point(0, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 198);
            this.panel2.TabIndex = 3;
            // 
            // dgv_Food_index
            // 
            this.dgv_Food_index.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv_Food_index.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Food_index.Location = new System.Drawing.Point(0, 0);
            this.dgv_Food_index.Name = "dgv_Food_index";
            this.dgv_Food_index.Size = new System.Drawing.Size(407, 195);
            this.dgv_Food_index.TabIndex = 0;
            this.dgv_Food_index.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Food_index_CellClick);
            // 
            // btn_Insert_Food_Table
            // 
            this.btn_Insert_Food_Table.Location = new System.Drawing.Point(750, 276);
            this.btn_Insert_Food_Table.Name = "btn_Insert_Food_Table";
            this.btn_Insert_Food_Table.Size = new System.Drawing.Size(94, 57);
            this.btn_Insert_Food_Table.TabIndex = 4;
            this.btn_Insert_Food_Table.Text = "Thêm Món";
            this.btn_Insert_Food_Table.UseVisualStyleBackColor = true;
            this.btn_Insert_Food_Table.Click += new System.EventHandler(this.btn_Insert_Food_Table_Click);
            // 
            // txt_Category_Food_index
            // 
            this.txt_Category_Food_index.FormattingEnabled = true;
            this.txt_Category_Food_index.Location = new System.Drawing.Point(548, 283);
            this.txt_Category_Food_index.Name = "txt_Category_Food_index";
            this.txt_Category_Food_index.Size = new System.Drawing.Size(185, 21);
            this.txt_Category_Food_index.TabIndex = 7;
            this.txt_Category_Food_index.SelectedIndexChanged += new System.EventHandler(this.txt_Category_Food_index_SelectedIndexChanged);
            // 
            // txt_Name_Food_index
            // 
            this.txt_Name_Food_index.FormattingEnabled = true;
            this.txt_Name_Food_index.Location = new System.Drawing.Point(548, 322);
            this.txt_Name_Food_index.Name = "txt_Name_Food_index";
            this.txt_Name_Food_index.Size = new System.Drawing.Size(185, 21);
            this.txt_Name_Food_index.TabIndex = 8;
            // 
            // txt_id_table
            // 
            this.txt_id_table.Location = new System.Drawing.Point(441, 364);
            this.txt_id_table.Name = "txt_id_table";
            this.txt_id_table.Size = new System.Drawing.Size(31, 20);
            this.txt_id_table.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(437, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(437, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên món";
            // 
            // txt_total_bill
            // 
            this.txt_total_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total_bill.Location = new System.Drawing.Point(476, 427);
            this.txt_total_bill.Name = "txt_total_bill";
            this.txt_total_bill.Size = new System.Drawing.Size(168, 26);
            this.txt_total_bill.TabIndex = 14;
            this.txt_total_bill.Text = "0.0";
            this.txt_total_bill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.total.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.ForeColor = System.Drawing.Color.Maroon;
            this.total.Location = new System.Drawing.Point(415, 427);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(57, 25);
            this.total.TabIndex = 15;
            this.total.Text = "Tổng";
            // 
            // txt_bill_checkout
            // 
            this.txt_bill_checkout.Location = new System.Drawing.Point(669, 401);
            this.txt_bill_checkout.Name = "txt_bill_checkout";
            this.txt_bill_checkout.Size = new System.Drawing.Size(138, 52);
            this.txt_bill_checkout.TabIndex = 16;
            this.txt_bill_checkout.Text = "Thanh Toán";
            this.txt_bill_checkout.UseVisualStyleBackColor = true;
            this.txt_bill_checkout.Click += new System.EventHandler(this.txt_bill_checkout_Click);
            // 
            // txt_id_bill
            // 
            this.txt_id_bill.Enabled = false;
            this.txt_id_bill.Location = new System.Drawing.Point(441, 390);
            this.txt_id_bill.Name = "txt_id_bill";
            this.txt_id_bill.Size = new System.Drawing.Size(31, 20);
            this.txt_id_bill.TabIndex = 17;
            this.txt_id_bill.Text = "0";
            // 
            // txt_destroy_food
            // 
            this.txt_destroy_food.Location = new System.Drawing.Point(750, 339);
            this.txt_destroy_food.Name = "txt_destroy_food";
            this.txt_destroy_food.Size = new System.Drawing.Size(94, 32);
            this.txt_destroy_food.TabIndex = 18;
            this.txt_destroy_food.Text = "Xóa Món";
            this.txt_destroy_food.UseVisualStyleBackColor = true;
            this.txt_destroy_food.Click += new System.EventHandler(this.txt_destroy_food_Click);
            // 
            // TableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(894, 465);
            this.Controls.Add(this.txt_destroy_food);
            this.Controls.Add(this.txt_id_bill);
            this.Controls.Add(this.txt_bill_checkout);
            this.Controls.Add(this.total);
            this.Controls.Add(this.txt_total_bill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_id_table);
            this.Controls.Add(this.txt_Name_Food_index);
            this.Controls.Add(this.txt_Category_Food_index);
            this.Controls.Add(this.btn_Insert_Food_Table);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.list_TableSeat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableManager";
            this.Text = "TableManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Food_index)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThôngTinToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel list_TableSeat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_Food_index;
        private System.Windows.Forms.Button btn_Insert_Food_Table;
        private System.Windows.Forms.ComboBox txt_Category_Food_index;
        private System.Windows.Forms.ComboBox txt_Name_Food_index;
        private System.Windows.Forms.NumericUpDown txt_id_table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_total_bill;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Button txt_bill_checkout;
        private System.Windows.Forms.TextBox txt_id_bill;
        private System.Windows.Forms.Button txt_destroy_food;
    }
}