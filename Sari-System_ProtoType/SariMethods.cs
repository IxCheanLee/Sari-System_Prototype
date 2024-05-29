using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Sari_System_ProtoType
{
    internal class SariMethods
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SariDatabase.mdf;Integrated Security=True");

        public void RegUser(string x, string y)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Accounts VALUES (@Username, @Password)", connection);
                cmd.Parameters.AddWithValue("@UserName", x);
                cmd.Parameters.AddWithValue("@Password", y);
                cmd.ExecuteNonQuery();
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

        public bool IpasokMo(string x, string y)
        {
            bool ibato = false;
            try
            {
                string query = $"SELECT * FROM Accounts WHERE UserName = '{x}' COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = '{y}' COLLATE SQL_Latin1_General_CP1_CS_AS;";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    ibato = true;
                }

            }


            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return ibato;
        }

        public bool yunikBa(string x)
        {
            bool ibato = false;
            try
            {
                string query = $"SELECT * FROM Accounts WHERE UserName = '{x}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    ibato = true;
                }
            }


            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return ibato;

        }

        public void inventori(string w, string x, string y, string z)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Inventory VALUES (@ItemName, @UnitPrice, @Category, @Stock)", connection);
                cmd.Parameters.AddWithValue("@ItemName", w);
                cmd.Parameters.AddWithValue("@UnitPrice", x);
                cmd.Parameters.AddWithValue("@Category", y);
                cmd.Parameters.AddWithValue("@Stock", z);
                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool existingBa(string x, string y)
        {
            bool ibato = false;
            try
            {
                string query = $"SELECT * FROM Inventory WHERE ItemCode = {x} OR ItemName = '{y}';";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    ibato = true;
                }
            
            }


            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }

            return ibato;

        }

        public void DeleteItem(string x)
        {

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Inventory WHERE ItemCode = @ItemCode", connection);
                cmd.Parameters.AddWithValue("@ItemCode", x);
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }

        }

        public void editItem(string v, string w, string x, string y, string z)
        {

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Inventory SET ItemName = @ItemName, UnitPrice = @UnitPrice, Category = @Category, Stock = @Stock WHERE ItemCode = @ItemCode", connection);
                cmd.Parameters.AddWithValue("@ItemCode", v);
                cmd.Parameters.AddWithValue("@ItemName", w);
                cmd.Parameters.AddWithValue("@UnitPrice", x);
                cmd.Parameters.AddWithValue("@Category", y);
                cmd.Parameters.AddWithValue("@Stock", z);
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Stokining(string x, string y, string z)
        {
            try
            {

                if (z == "+")
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Inventory Set Stock = Stock + @add WHERE ItemCode = @ID", connection);
                    cmd.Parameters.AddWithValue("@ID", x);
                    cmd.Parameters.AddWithValue("@add", y);
                    cmd.ExecuteNonQuery();
                }

                else if (z == "-")
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Inventory Set Stock = Stock - @Minus WHERE ItemCode = @ID", connection);
                    cmd.Parameters.AddWithValue("@ID", x);
                    cmd.Parameters.AddWithValue("@Minus", y);
                    cmd.ExecuteNonQuery();
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }

        }

        public bool checkerz(int x, int y, string z)
        {
            bool ibato = false;

            try
            {
                string query = $"SELECT STOCK FROM Inventory WHERE ItemCode = {z};";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);

                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (Convert.ToInt32(dtbl.Rows[0][0]) < y && x == -1)
                {
                    ibato = true;
                }

                else if (Convert.ToInt32(dtbl.Rows[0][0]) <= x && Convert.ToInt32(dtbl.Rows[0][0]) > 0)
                {
                    ibato = true;
                }

                else if (Convert.ToInt32(dtbl.Rows[0][0]) == x)
                {
                    ibato = true;
                }

                else
                {
                    ibato = false;
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

            return ibato;
        }

        public void Repowt(string x, string y, string z)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Reports VALUES (@Quantity, @TotalAmount, @Date)", connection);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(x));
                cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToInt64(y));
                cmd.Parameters.AddWithValue("@Date", z);
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }
        }

    }
}
