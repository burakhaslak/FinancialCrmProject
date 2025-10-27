using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            cmbCurrency.Items.AddRange(new string[] { "TL", "USD", "EUR" });
            LoadSettings();

            cmbLanguage.Items.AddRange(new string[] { "TR", "EN" });
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadSettings();
        }

        private void LoadSettings()
        {
            var currency = db.Settings.FirstOrDefault(x => x.Name == "DefaultCurrency");
            if (currency != null) cmbCurrency.SelectedItem = currency.Value;

            var reminder = db.Settings.FirstOrDefault(x => x.Name == "AutoReminder");
            if (reminder != null) chkAutoReminder.Checked = reminder.Value == "true";

            var lang = db.Settings.FirstOrDefault(x => x.Name == "AppLanguage");
            if (lang != null)
            {
                cmbLanguage.SelectedItem = lang.Value; // TR veya EN
            }

            var currency2 = db.Settings.FirstOrDefault(x => x.Name == "DefaultCurrency");
            if (currency2 != null)
                cmbCurrency.SelectedItem = currency.Value;

            var reminder2 = db.Settings.FirstOrDefault(x => x.Name == "AutoReminder");
            if (reminder2 != null)
                chkAutoReminder.Checked = reminder.Value == "true";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSetting("DefaultCurrency", cmbCurrency.SelectedItem.ToString());
            SaveSetting("AutoReminder", chkAutoReminder.Checked ? "true" : "false");
            SaveSetting("AppLanguage", cmbLanguage.SelectedItem.ToString());

            MessageBox.Show("Ayarlar kaydedildi!");
        }

        private void SaveSetting(string name, string value)
        {
            var setting = db.Settings.FirstOrDefault(x => x.Name == name);
            if (setting != null)
            {
                setting.Value = value;
            }
            else
            {
                db.Settings.Add(new Settings { Name = name, Value = value });
            }
            db.SaveChanges();

            var setting2 = db.Settings.FirstOrDefault(x => x.Name == name);
            if (setting2 != null)
            {
                setting2.Value = value;
            }
            else
            {
                db.Settings.Add(new Settings { Name = name, Value = value });
            }
            db.SaveChanges();
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

        private void button3_Click(object sender, EventArgs e)
        {
            FrmFaturalar frm = new FrmFaturalar();
            frm.Show();
            this.Hide();
        }

        private void btnGiderler_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
