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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Lütfen doğru kullanıcı adı ve şifreyi giriniz.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                using (var db = new FinancialCrmDbEntities1())
                {
                    
                    var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                    if (user != null)
                    {
                        
                        MessageBox.Show($"Hoşgeldin, {user.Username}!", "Giriş İşlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        FrmBanks mainForm = new FrmBanks();
                        mainForm.Show();

                        
                        this.Hide();
                    }
                    else
                    {
                        
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre.", "Giriş İşlemi Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred while connecting to the database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
