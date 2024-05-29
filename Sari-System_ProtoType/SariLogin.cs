using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sari_System_ProtoType
{
    public partial class SariLogin : Form
    {
        public static SariLogin instance;
        public static TextBox textbox;
        public SariLogin()
        {
            InitializeComponent();
            instance = this;
            textbox = txtUsernem;
        }

        private void btnRgster_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsernem.Text == "SariAdmin" && txtPasswerd.Text == "Sari1234")
                {
                    SariReg reg = new SariReg();
                    this.Visible = false;
                    reg.Show();
                }

                else
                {
                    MessageBox.Show("You are trying to access Admin level Privileges.");
                    txtPasswerd.Clear();
                    txtUsernem.Clear();
                }
            }

            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPasok_Click(object sender, EventArgs e)
        {
            SariMethods obj = new SariMethods();
            SariMain men = new SariMain(sender);
            try
            {
                if(obj.IpasokMo(txtUsernem.Text, txtPasswerd.Text))
                {
                    men.Show();
                    this.Visible = false;
                    SariMain.instance.label.Text = txtUsernem.Text;
                    txtUsernem.Clear();
                    txtPasswerd.Clear();
                }
                else if (txtUsernem.Text == " " || txtPasswerd.Text == " ")
                {
                    MessageBox.Show("Please input username or password");
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                    txtPasswerd.Clear();
                    txtUsernem.Clear();
                }
            }

            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SariLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SariLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
