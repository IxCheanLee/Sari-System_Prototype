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
    public partial class SariMain : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private PictureBox pictureBox;
        public Label label;
        public static SariMain instance;

       
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                   
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(208, 212, 202);
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(108, 95, 91);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        public SariMain(object btnSender)
        {
            InitializeComponent();
            instance = this;
            label = label2;
            random = new Random();
           
            AddCOntrols(new SariHome(), btnSender);

        }
        public void AddCOntrols(Form f, object btnSender)
        {
            ActivateButton(btnSender);
            panel3.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
            label3.Text = f.Text;
        }



        private void btnPOS_Click(object sender, EventArgs e)
        {
            AddCOntrols(new SariPOS(), sender);
            pictureBox5.BackColor = Color.FromArgb(208, 212, 202);
            pictureBox3.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox4.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox6.BackColor = Color.FromArgb(108, 95, 91);


        }

        private void btnInventoree_Click(object sender, EventArgs e)
        {
            AddCOntrols(new SariInventory(), sender);
            pictureBox5.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox4.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox6.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox3.BackColor = Color.FromArgb(208, 212, 202);
        }

        private void btnRepowts_Click(object sender, EventArgs e)
        {
            AddCOntrols(new SariReports(), sender);
            pictureBox5.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox3.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox6.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox4.BackColor = Color.FromArgb(208, 212, 202);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddCOntrols(new SariHome(), sender);
            pictureBox5.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox3.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox4.BackColor = Color.FromArgb(108, 95, 91);
            pictureBox6.BackColor = Color.FromArgb(208, 212, 202);
        }
        private void lblLogAwt_MouseHover(object sender, EventArgs e)
        {
            lblLogAwt.ForeColor = Color.Yellow;
        }

        private void lblLogAwt_Click(object sender, EventArgs e)
        {
            SariLogin bek = new SariLogin();
            DialogResult ilabasMo = MessageBox.Show("Are you sure you want to log-out?", "Confirm Log-Out", MessageBoxButtons.YesNo);
            if (ilabasMo == DialogResult.Yes)
            {
                bek.Visible = true;
                this.Close();
            }
            else if (ilabasMo == DialogResult.No)
            {
                //Do nothing
            }
        }
        

        private void lblLogAwt_MouseLeave(object sender, EventArgs e)
        {
            lblLogAwt.ForeColor = Color.White;
        }

    

        private void SariMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void SariMain_Load(object sender, EventArgs e)
        {

        }

    }
}
