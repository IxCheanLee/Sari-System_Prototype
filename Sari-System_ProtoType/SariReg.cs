using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sari_System_ProtoType
{
    public partial class SariReg : Form
    {
        SariMethods obj = new SariMethods();
        public SariReg()
        {
            InitializeComponent();
            lblPassConfirmer.Text = " ";
            lblPwedengPass.Text = " ";
            IzYunik.Text = " ";
        }

        private void btnBeck_Click(object sender, EventArgs e)
        {
            SariLogin log = new SariLogin();
            this.Close();
            log.Visible = true;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNewUser.Text == "" || txtNewPass.Text == "" || txtCnfrmPass.Text == "")
                {
                    MessageBox.Show("Please fill the field before to proceed.");
                }

                else if (obj.yunikBa(txtNewUser.Text))
                {
                    MessageBox.Show("Please enter a unique username.");
                }
                else if (txtNewPass.Text != txtCnfrmPass.Text)
                {
                    MessageBox.Show("Confirm Password does not matched to the original.");
                }
                else if(!txtNewPass.Text.Any(char.IsUpper) || !txtNewPass.Text.Any(char.IsLower) || txtNewPass.Text.Contains(" ") || 
                    !(txtNewPass.Text.Length >= 8 && txtNewPass.Text.Length <= 14))
                {
                    MessageBox.Show("Wrong password format");
                }
                else
                {
                    obj.RegUser(txtNewUser.Text, txtCnfrmPass.Text);
                    MessageBox.Show("Successfully Registered");
                    ClearField();
                }
            }

            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
    
            
        }
       private void ClearField()
        {
            txtNewUser.Clear();
            txtNewPass.Clear();
            txtCnfrmPass.Clear();
            lblPassConfirmer.Text = " ";
            lblPwedengPass.Text = " ";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNewUser.Clear();
            txtNewPass.Clear();
            txtCnfrmPass.Clear();
            lblPassConfirmer.Text = " ";
            lblPwedengPass.Text = " ";
        }

        private void txtCnfrmPass_TextChanged(object sender, EventArgs e)
        {
            if(txtNewPass.Text == txtCnfrmPass.Text)
            {
                lblPassConfirmer.ForeColor = Color.Green;
                lblPassConfirmer.Text = "✔";
            }

            else if(txtCnfrmPass.Text == "")
            {
                lblPassConfirmer.Text = " ";
            }

            else
            {
                lblPassConfirmer.ForeColor = Color.Red;
                lblPassConfirmer.Text = "✘";
            }
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            if(txtNewPass.Text.Length >= 8 && txtNewPass.Text.Length <= 14)
            {
                if (txtNewPass.Text.Any(char.IsUpper))
                {
                    if(txtNewPass.Text.Any(char.IsLower))
                    {
                        if(!txtNewPass.Text.Contains(" "))
                        {
                            lblPwedengPass.ForeColor = Color.Green;
                            lblPwedengPass.Text = "✔";
                        }

                        else
                        {
                            lblPwedengPass.ForeColor = Color.Red;
                            lblPwedengPass.Text = "No White Space";
                        }
                    }

                    else
                    {
                        lblPwedengPass.ForeColor = Color.Red;
                        lblPwedengPass.Text = "One Lower case";
                    }
                }

                else if(txtNewPass.Text == "")
                {
                    lblPwedengPass.Text = " ";
                }

                else
                {
                    lblPwedengPass.ForeColor = Color.Red;
                    lblPwedengPass.Text = "One Upper case";
                }
            }

            else if (txtNewPass.Text == "")
            {
                lblPwedengPass.Text = " ";
            }

            else
            {
                lblPwedengPass.ForeColor = Color.Red;
                lblPwedengPass.Text = "Min of 8, Max of 14 char.";
            }
        }


        private void txtNewUser_TextChanged(object sender, EventArgs e)
        {
            

                if (obj.yunikBa(txtNewUser.Text))
                {
                    IzYunik.ForeColor = Color.Red;
                    IzYunik.Text = "Username already in use";
                }

                else if(txtNewUser.Text == "")
                {
                    IzYunik.Text = " ";
                }

                else
                {
                    IzYunik.ForeColor = Color.Green;
                    IzYunik.Text = "✔";
                }
            

           

        }
    }
}
