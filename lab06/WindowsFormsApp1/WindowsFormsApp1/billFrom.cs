﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class billFrom : Form
    {
        public billFrom()
        {
            InitializeComponent();
        }

        public void LoadBills(string fromTime, string toTime)
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = connection.CreateCommand();

            sqlCommand.CommandText = String.Format("select * from Bills where CheckoutDate BETWEEN '{0}' AND '{1}'", fromTime, toTime);
            connection.Open();
            this.Text = "Danh sách hóa đơn từ ngày " + fromTime + "tới ngày " + toTime;

            sqlCommand.CommandText = "select * from Food";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            adapter.Fill(dt);

            dgvBill.DataSource = dt;

            dgvBill.Columns[0].ReadOnly = true;

            connection.Close();
            connection.Dispose();
            adapter.Dispose();
        }

        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            BillDetailsForm frm = new BillDetailsForm();
            string id = dgvBill.SelectedRows[0].Cells[0].Value.ToString();
            frm.Show(this);
            frm.LoadBillDetail(int.Parse(id));
        }

        private void billFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
