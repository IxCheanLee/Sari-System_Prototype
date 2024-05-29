using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sari_System_ProtoType
{
    public partial class SariHome : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SariDatabase.mdf;Integrated Security=True");
        public SariHome()
        {
            InitializeComponent();
            TotEarned.Text = "";
            TotSold.Text = "";
            NeedRestock.Text = "";
            SoldToday.Text = "";
            EarnedToday.Text = "";

            GetData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            try
            {
                string query = $"SELECT SUM(Quantity) AS 'TotQtty', SUM(TotalAmount) AS 'TotAmt' FROM Reports;";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                foreach (DataRow row in dtbl.Rows)
                {
                    TotSold.Text = row[0].ToString();
                    TotEarned.Text = row[1].ToString();
                  
                }

                string query2 = $"SELECT SUM(Quantity) AS 'TotQtty', SUM(TotalAmount) AS 'TotAmt' FROM Reports WHERE Date = '{Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy")))}';";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, connection);
                DataTable dtbl2 = new DataTable();
                sda2.Fill(dtbl2);

                foreach (DataRow row2 in dtbl2.Rows)
                {
                    if(row2[0].ToString() == "")
                    {
                        SoldToday.Text = "0";
                    }

                    else
                    {
                        SoldToday.Text = row2[0].ToString();
                    }
                    
                    if(row2[1].ToString() == "")
                    {
                        EarnedToday.Text = "0";
                    }
                    else
                    {
                       EarnedToday.Text = row2[1].ToString();
                       
                    }
                }

                string query3 = $"SELECT COUNT(ItemCode) AS 'NeedStock' FROM Inventory WHERE Stock <= 5;";
                SqlDataAdapter sda3 = new SqlDataAdapter(query3, connection);
                DataTable dtbl3 = new DataTable();
                sda3.Fill(dtbl3);


                foreach (DataRow row3 in dtbl3.Rows)
                {
                    NeedRestock.Text = row3[0].ToString();
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }

        private void SariHome_Load(object sender, EventArgs e)
        {

        }
    }
}
