using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NikNameHost_ZS.Models;

namespace NikNameHost_ZS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_zs_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxUserName_zs.Text) || string.IsNullOrWhiteSpace(textBoxPass_zs.Text))
                {
                    MessageBox.Show("لطفا همه‌ی فیلدها را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = new DbContextZS())
                {
                    var username = textBoxUserName_zs.Text;
                    var password = textBoxPass_zs.Text;

                    var user = context.Employees
                        .Where(u => u.UserName == username && u.Password == password).Select(u=>new{u.Id,u.UserName,u.Password,u.Name,u.Family,u.Position}).FirstOrDefault();

                    if (user != null)
                    {
                        MessageBox.Show($"خوش آمدید {user.Name} {user.Family}");

                        var fullName = $"{user.Name} {user.Family}";

                       
                        if (user.Position != "Admin" && user.Position!= "Rigister")
                        {
                            LoggedInUser.UserId = user.Id;
                            MainFormClient userPanel = new MainFormClient(fullName);
                            userPanel.Show();
                            this.Hide();
                        }
                        else
                        {
                            LoggedInUser.UserId = user.Id;
                            MainForm formAdmin = new MainForm(fullName);
                            formAdmin.Show();
                            this.Hide();
                            return;
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("نام کاربری یا رمز عبور اشتباه است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
               
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RigisterForm nextForm = new RigisterForm();
            nextForm.Show();
            this.Hide();
        }

        private void textBoxUserName_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPass_zs.Focus();
            }
        }

        private void textBoxPass_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_zs.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
                textBoxUserName_zs.Focus();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
