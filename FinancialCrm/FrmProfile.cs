using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        private int currentUserId = 1;

        private void FrmProfile_Load(object sender, EventArgs e)
        {

            LoadProfile();
        }

        private void LoadProfile()
        {
            var user = db.Profile.FirstOrDefault(u => u.UserId == currentUserId);
            if (user != null)
            {
                
                lblFirstName.Text = user.FirstName;
                lblLastName.Text = user.LastName;
                lblBirthPlace.Text = user.BirthPlace;
                lblBankBranch.Text = user.BankBranch;

              
                txtPhone.Text = user.Phone;
                txtEmail.Text = user.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = db.Profile.FirstOrDefault(u => u.UserId == currentUserId);
            if (user != null)
            {
                user.Phone = txtPhone.Text;
                user.Email = txtEmail.Text;

                db.SaveChanges();
                MessageBox.Show("Profil bilgileri başarıyla güncellendi!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmFaturalar frm = new FrmFaturalar();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }
    }
}
