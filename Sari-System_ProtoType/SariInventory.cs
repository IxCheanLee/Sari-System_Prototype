using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using DGVPrinterHelper;

namespace Sari_System_ProtoType
{
    public partial class SariInventory : Form
    {
        int itemCud = 0;
        public SariInventory()
        {
            InitializeComponent();
            bobDaTableBuilder();
            getWat2Buy();
        }


        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SariDatabase.mdf;Integrated Security=True");
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();
            try
            {
                if(itemCud == 0)
                {
                    throw new FormatException();
                }

                else
                {
                    obj.DeleteItem(Convert.ToString(itemCud));
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                itemCud = 0;
                itemNem.Clear();
                kategorii.Text = "";
                stok.Clear();
                InventoryTable.Refresh();
                bobDaTableBuilder();
                loadComboBoxer();
                getWat2Buy();
            }
        }

        private void btnAddInvent_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();

            try
            {
                if (obj.existingBa(Convert.ToString(itemCud), itemNem.Text))
                {
                    MessageBox.Show("Cannot enter an already existing entry.");
                }

                else if (Convert.ToInt32(stok.Text) < 0)
                {
                    throw new FormatException("Invalid Input, Negative Values are not allowed");
                }

                else
                {
                    obj.inventori(itemNem.Text, YunitPrays.Text, kategorii.Text, stok.Text);
                }

            }

            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                itemCud = 0;
                itemNem.Clear();
                kategorii.Text = "";
                stok.Clear();
                YunitPrays.Clear();
                InventoryTable.Refresh();
                bobDaTableBuilder();
                loadComboBoxer();
                getWat2Buy();
            }
        }

        public void bobDaTableBuilder()
        {
            string query = $"SELECT * FROM Inventory;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            InventoryTable.DataSource = dtbl;
        }

        public void bobDaCategorySorter(string x)
        {
            if (x == "All")
            {
                bobDaTableBuilder();
            }

            else
            {
                string query = $"SELECT * FROM Inventory WHERE Category = '{x}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                InventoryTable.DataSource = dtbl;
            }
        }

        public void bobDaDataFinder(string x)
        {
            try
            {
                if (x == "" || x == " ")
                {
                    bobDaTableBuilder();
                }

                else
                {
                    string query = $"SELECT * FROM Inventory WHERE ItemCode = {x};";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    InventoryTable.DataSource = dtbl;

                    if (dtbl.Rows.Count == 0)
                    {
                        MessageBox.Show("Non existing Item Code");
                        textBox1.Clear();
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InventoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.InventoryTable.Rows[e.RowIndex];

                itemCud = Convert.ToInt32(row.Cells["ItemCode"].Value);
                itemNem.Text = Convert.ToString(row.Cells["ItemName"].Value);
                YunitPrays.Text = Convert.ToString(row.Cells["UnitPrice"].Value);
                kategorii.Text = Convert.ToString(row.Cells["Category"].Value);
                stok.Text = Convert.ToString(row.Cells["Stock"].Value);
            }
        }

        private void btnEditz_Click(object sender, EventArgs e)
        {
            try
            {
                SariMethods obj = new SariMethods();

                if (Convert.ToInt32(stok.Text) < 0)
                {
                    throw new FormatException("Invalid Input, Negative Values are not allowed");
                }

                else
                {
                    obj.editItem(Convert.ToString(itemCud), itemNem.Text, YunitPrays.Text, kategorii.Text, stok.Text);
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                itemCud = 0;
                itemNem.Clear();
                kategorii.Text = "";
                stok.Clear();
                YunitPrays.Clear();
                InventoryTable.Refresh();
                bobDaTableBuilder();
                loadComboBoxer();
                getWat2Buy();
            }
        }

        private void btnADDstock_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();

            try
            {
                if (stokstok.Text == "" || stokstok.Text == " ")
                {
                    throw new FormatException();
                }

                else
                {
                    obj.Stokining(Convert.ToString(itemCud), stokstok.Text, "+");
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                itemCud = 0;
                itemNem.Clear();
                kategorii.Text = "";
                stok.Clear();
                stokstok.Clear();
                YunitPrays.Clear();
                InventoryTable.Refresh();
                bobDaTableBuilder();
                loadComboBoxer();
                getWat2Buy();
            }
        }

        private void btnRMVstock_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();

            try
            {
                if (obj.checkerz(0, Convert.ToInt32(stokstok.Text), Convert.ToString(itemCud)))
                {
                    MessageBox.Show("Stock is Empty Please Restock");
                }

                else if (obj.checkerz(5, Convert.ToInt32(stokstok.Text), Convert.ToString(itemCud)))
                {
                    MessageBox.Show("Stock is Low Please Restock");
                    obj.Stokining(Convert.ToString(itemCud), stokstok.Text, "-");
                }

                else if (obj.checkerz(-1, Convert.ToInt32(stokstok.Text), Convert.ToString(itemCud)))
                {
                    MessageBox.Show("Cannot Remove Stock That Exceeds Current Stock");
                }

                else
                {
                    obj.Stokining(Convert.ToString(itemCud), stokstok.Text, "-");
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                itemCud = 0;
                itemNem.Clear();
                kategorii.Text = "";
                stok.Clear();
                stokstok.Clear();
                YunitPrays.Clear();
                InventoryTable.Refresh();
                bobDaTableBuilder();
                loadComboBoxer();
                getWat2Buy();
            }
        }

        private void SariInventory_Load(object sender, EventArgs e)
        {
            loadComboBoxer();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            itemCud = 0;
            itemNem.Clear();
            kategorii.Text = "";
            stok.Clear();
            YunitPrays.Clear();
            bobDaCategorySorter(comboBox1.SelectedItem.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            itemCud = 0;
            itemNem.Clear();
            kategorii.Text = "";
            stok.Clear();
            YunitPrays.Clear();
            bobDaDataFinder(textBox1.Text);
        }

        private void loadComboBoxer()
        {
            comboBox1.Items.Clear();
            kategorii.Items.Clear();
            string query = $"SELECT DISTINCT Category FROM Inventory;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            comboBox1.Items.Add("All");
            foreach (DataRow dr in dtbl.Rows)
            {
                comboBox1.Items.Add(dr["Category"]);
                kategorii.Items.Add(dr["Category"]);
            }
        }

        private bool getWat2Buy()
        {
            string query = $"SELECT ItemName FROM Inventory WHERE Stock <= 5;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;

            if(dtbl.Rows.Count <= 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void btnPrintShopList_Click(object sender, EventArgs e)
        {
            if(getWat2Buy())
            {
                MessageBox.Show("No Items Low In Stock.");
            }

            else
            {
                DGVPrinter pwint = new DGVPrinter();
                pwint.Title = "Sari-System";
                pwint.SubTitle = String.Format("Shopping List", pwint.SubTitleColor = Color.Black, pwint);
                pwint.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                pwint.PageNumbers = true;
                pwint.PageNumberInHeader = false;
                pwint.PorportionalColumns = true;
                pwint.HeaderCellAlignment = StringAlignment.Near;
                pwint.Footer = "Printed on: " + Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy")));
                pwint.FooterSpacing = 15;
                pwint.PrintPreviewDataGridView(dataGridView1);
            }
        }
    }
}
