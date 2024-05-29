using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sari_System_ProtoType
{
    public partial class SariPOS : Form
    {
       
        static int amt = 0;
        static long prays = 0;
        static long tot = 0;
        static long totamt = 0;
        static int stok = 0;
        static int id = 0;

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SariDatabase.mdf;Integrated Security=True");
        public SariPOS()
        {
            InitializeComponent();
            bobDaTableBuilder();
            TotPrice.Text = "";
            Sokli.Text = "";
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            amt++;
            txtQtt.Text = Convert.ToString(amt);
        }

        private void btnMinusOne_Click(object sender, EventArgs e)
        {
            amt--;
            txtQtt.Text = Convert.ToString(amt);
        }

     

        private void btnBenta_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();
            obj.Repowt(Convert.ToString(totamt), TotPrice.Text, Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy"))));

            amt = 0;
            prays = 0;
            tot = 0;
            totamt = 0;
            stok = 0;
            id = 0;
            TotPrice.Text = "";
            Sokli.Text = "";
            txtCashMoneyz.Clear();
            dataGridView1.Rows.Clear();
        }


        private void btnCart_Click(object sender, EventArgs e)
        {
            try
            {
                prays = prays * Convert.ToInt64(txtQtt.Text);
                stok = stok - Convert.ToInt32(txtQtt.Text);

                if (stok == 0 || (stok <= 5 && stok > 0))
                {
                    MessageBox.Show("Stock is low restock soon");
                    SariMethods obj = new SariMethods();
                    obj.Stokining(Convert.ToString(id), txtQtt.Text, "-");

                    dataGridView1.Rows.Add(itmNem.Text, txtQtt.Text, Convert.ToString(prays));
                    tot = tot + prays;
                    totamt = totamt + Convert.ToInt32(txtQtt.Text);

                    TotPrice.Text = Convert.ToString(tot);
                    itmNem.Clear();
                    txtQtt.Clear();
                    amt = 0;
                }

                else if (stok < 0)
                {
                    MessageBox.Show("Item is Out of Stock please restock Item");
                    itmNem.Clear();
                    txtQtt.Clear();
                    amt = 0;
                }

                else
                {
                    SariMethods obj = new SariMethods();
                    obj.Stokining(Convert.ToString(id), txtQtt.Text, "-");

                    dataGridView1.Rows.Add(itmNem.Text, txtQtt.Text, Convert.ToString(prays));
                    tot = tot + prays;
                    totamt = totamt + Convert.ToInt64(txtQtt.Text);

                    TotPrice.Text = Convert.ToString(tot);
                    itmNem.Clear();
                    txtQtt.Clear();
                    amt = 0;
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                bobDaTableBuilder();
            }
        }

        private void btnRmvCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    SariMethods obj = new SariMethods();
                    obj.Stokining(Convert.ToString(id), Convert.ToString(selectedRow.Cells["Quantity"].Value), "+");

                    tot = tot - Convert.ToInt64(selectedRow.Cells["TotalPriceperUnit"].Value);
                    totamt = totamt - Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                    TotPrice.Text = Convert.ToString(tot);
                    dataGridView1.Rows.RemoveAt(selectedrowindex);
                    id = 0;
                }
            }

            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("No selected item from cart");
                Console.WriteLine(ex.Message);
            }

            finally
            {
                bobDaTableBuilder();
            }
        }

        public void bobDaTableBuilder()
        {
            string query = $"SELECT ItemCode, ItemName, UnitPrice, Stock FROM Inventory;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            cartView.DataSource = dtbl;
        }

        public void bobDaCategorySorter(string x)
        {
            if(x == "All")
            {
                bobDaTableBuilder();
            }

            else
            {
                string query = $"SELECT ItemCode, ItemName, UnitPrice, Stock FROM Inventory WHERE Category = '{x}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                cartView.DataSource = dtbl;
            }
        }

        public void bobDaDataFinder(string x)
        {
            if(x == "" || x == " ")
            {
                bobDaTableBuilder();
            }

            else
            {
                try
                {


                    string query = $"SELECT ItemCode, ItemName, UnitPrice, Stock FROM Inventory WHERE ItemCode = {x};";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    cartView.DataSource = dtbl;
                    
                        if (dtbl.Rows.Count == 0)
                        {
                            MessageBox.Show("Non existing Item Code");
                        textBox1.Clear();
                        }
                   
                }
               
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    textBox1.Clear();
                }
            }
        }

        private void cartView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.cartView.Rows[e.RowIndex];

                itmNem.Text = Convert.ToString(row.Cells["ItemName"].Value);
                prays = Convert.ToInt64(row.Cells["UnitPrice"].Value);
                stok = Convert.ToInt32(row.Cells["Stock"].Value);
                id = Convert.ToInt32(row.Cells["ItemCode"].Value);
               
            }
        }

        private void txtCashMoneyz_TextChanged(object sender, EventArgs e)
        {
            if(txtCashMoneyz.Text == "")
            {
                Sokli.Text = "";
            }
            else
            {
                try
                {
                    Sokli.Text = Convert.ToString(Convert.ToInt64(txtCashMoneyz.Text) - tot);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Only numbers are valid in cash amount, Please Try Again.");
                    txtCashMoneyz.Clear();
                    Sokli.Text = "";
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bobDaDataFinder(textBox1.Text);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bobDaCategorySorter(comboBox1.SelectedItem.ToString());
        }

        private void SariPOS_Load(object sender, EventArgs e)
        {
            loadComboBoxer();
        }

        private void loadComboBoxer()
        {
            string query = $"SELECT DISTINCT Category FROM Inventory;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            comboBox1.Items.Add("All");
            foreach (DataRow dr in dtbl.Rows)
            {
                comboBox1.Items.Add(Convert.ToString(dr["Category"]));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.cartView.Rows[e.RowIndex];

                    string x = Convert.ToString(row.Cells["ItemName"].Value);

                    string query = $"SELECT ItemCode FROM Inventory Where ItemName = {x};";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);

                    id = Convert.ToInt32(dtbl.Rows[0][0]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Sokli_Click(object sender, EventArgs e)
        {

        }
    }
}
