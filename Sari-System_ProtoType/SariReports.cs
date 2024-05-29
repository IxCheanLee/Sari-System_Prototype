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
using DGVPrinterHelper;

namespace Sari_System_ProtoType
{
    public partial class SariReports : Form
    {
        static string totQtt = "";
        static string totAmt = "";
        public SariReports()
        {
            InitializeComponent();
            bobDaTableBuilder();
            summerMan("");
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SariDatabase.mdf;Integrated Security=True");

        public void bobDaTableBuilder()
        {
            string query = $"SELECT Quantity, TotalAmount, Date FROM Reports;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView2.DataSource = dtbl;
        }

        public void bobDaTableDateSorter(string x)
        {
            if(x == "All")
            {
                bobDaTableBuilder();
            }

            else if(x == "Today")
            {
                string query = $"SELECT Quantity, TotalAmount, Date FROM Reports WHERE Date = '{Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy")))}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView2.DataSource = dtbl;
            }

            else
            {
                string query = $"SELECT Quantity, TotalAmount, Date FROM Reports WHERE Date = '{x}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                dataGridView2.DataSource = dtbl;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            totAmt = "";
            totQtt = "";
            bobDaTableDateSorter(comboBox1.SelectedItem.ToString());
            summerMan(comboBox1.SelectedItem.ToString());
        }

        private void SariReports_Load(object sender, EventArgs e)
        {
            string query = $"SELECT DISTINCT Date FROM Reports;";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Today");
            foreach (DataRow dr in dtbl.Rows)
            {
                comboBox1.Items.Add(Convert.ToString(dr["Date"]));
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == ""| comboBox1.Text == "All")
            {
                Wat2Pwint("All");
            }
            else if (comboBox1.Text == "Today")
            {
                Wat2Pwint(Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy"))));
            }
            else
            {
                Wat2Pwint(comboBox1.Text);
            }
        }

        private void Wat2Pwint(string x)
        {
            DGVPrinter pwint = new DGVPrinter();
            pwint.Title = "Sari-System";
            pwint.SubTitle = String.Format("Sales Reports on: "+x, pwint.SubTitleColor = Color.Black, pwint);
            pwint.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            pwint.PageNumbers = true;
            pwint.PageNumberInHeader = false;
            pwint.PorportionalColumns = true;
            pwint.HeaderCellAlignment = StringAlignment.Near;
            pwint.Footer ="Items Sold: "+totQtt+"\r\nAmount Earned: "+totAmt+"\r\n"+"Printed on: " + Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy")));
            pwint.FooterSpacing = 15;
            pwint.PrintPreviewDataGridView(dataGridView2);

        }

        private void summerMan(string x)
        {
            string query;
            if (comboBox1.Text == "" | comboBox1.Text == "All")
            {
                query = $"SELECT SUM(Quantity) AS 'TotQtty', SUM(TotalAmount) AS 'TotAmt' FROM Reports;";
            }

            else if (comboBox1.Text == "Today")
            {
                query = $"SELECT SUM(Quantity) AS 'TotQtty', SUM(TotalAmount) AS 'TotAmt' FROM Reports WHERE Date = '{Convert.ToString(Convert.ToString(DateTime.Today.ToString("MM/dd/yyyy")))}';";
            }

            else
            {
                query = $"SELECT SUM(Quantity) AS 'TotQtty', SUM(TotalAmount) AS 'TotAmt' FROM Reports WHERE Date = '{x}';";
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            foreach (DataRow row in dtbl.Rows)
            {
                totQtt = row[0].ToString();
                totAmt = row[1].ToString();
            }
        }

    }
}
