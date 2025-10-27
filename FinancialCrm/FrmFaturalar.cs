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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();

        private void ListPayments()
        {
            var payments = db.Payments
                             .Select(x => new
                             {
                                 x.PaymentId,
                                 x.BillName,
                                 x.Amount,
                                 x.PaymentDate,
                                 Durum = (bool)x.IsActive ? "Aktif" : "Pasif"
                             }).ToList();

            dataGridView1.DataSource = payments;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Payments payment = new Payments();
            payment.BillName = txtBillName.Text;
            payment.Amount = decimal.Parse(txtAmount.Text);
            payment.PaymentDate = dtpPaymentDate.Value;
            payment.IsActive = chkIsActive.Checked;

            db.Payments.Add(payment);
            db.SaveChanges();

            MessageBox.Show("Otomatik ödeme talimatı başarıyla eklendi!");
            ListPayments();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.Payments.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListPayments();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmProfile frm = new FrmProfile();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
