using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NikNameHost_ZS.Models;



namespace NikNameHost_ZS
{
    public partial class RigisterForm : Form
    {
        public RigisterForm()
        {
            InitializeComponent();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }
        protected  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SEPIDYARHESAB;Database=Project_ZS;User Id=damavand;Password=damavand;");
            }
        }

        private byte[] uploadedImageBytes;
        private void buttonRegister_zs_Click(object sender, EventArgs e)
        {

            try
            {
                if (
                    string.IsNullOrWhiteSpace(textBoxName_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxFamily_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxNationalCode_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPass_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPhon_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxRePass_zs.Text) ||
                    string.IsNullOrWhiteSpace(textBoxUserName_zs.Text))
                {
                    MessageBox.Show("لطفا همه‌ی فیلدها را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!radioButtonAdmin_zs.Checked && !radioButtonClient_zs.Checked)
                {
                    MessageBox.Show("لطفا سمت را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textBoxPass_zs.Text != textBoxRePass_zs.Text)
                {
                    MessageBox.Show("رمز عبور با تکرار آن یکسان نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                string role = "";
                foreach (Control control in groupBox1.Controls)
                {
                    if (control is RadioButton radio && radio.Checked)
                    {
                        role = radio.Tag.ToString();
                        break;
                    }
                }

              
                var context = new DbContextZS();
                var id = Guid.NewGuid();
              
                var user = new Employee()
                {
                    Id = id,
                    Name = textBoxName_zs.Text,
                    Family = textBoxFamily_zs.Text,
                    NationalCode = textBoxNationalCode_zs.Text,
                    Phone = textBoxPhon_zs.Text,
                    HireDate = DateTime.Now,
                    UserName = textBoxUserName_zs.Text,
                    Password = textBoxPass_zs.Text,
                    Position = role,
                    IsActive = true,
                    filePath =  uploadedImageBytes
                };

                context.Employees.Add(user);
                context.SaveChanges();

                MessageBox.Show("ثبت‌ نام با موفقیت انجام شد", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm loginform=new LoginForm();
                loginform.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ذخیره‌سازی: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm nextForm = new LoginForm();
            nextForm.Show();
            this.Hide();
           

        }

        private void buttonUploadImage_zs_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = $"Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog1.Title = "انتخاب تصویر";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
              pictureBoxSingIn_zs.Image= Image.FromFile(openFileDialog1.FileName);
              var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
              var binaryReader=new BinaryReader(stream);
              uploadedImageBytes = binaryReader.ReadBytes((int)stream.Length);
            }
        }

        private void textBoxName_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                textBoxFamily_zs.Focus();
            }
        }

        private void textBoxFamily_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxNationalCode_zs.Focus();
            }
        }

        private void textBoxNationalCode_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPhon_zs.Focus();
            }
        }

        private void textBoxPhon_zs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxUserName_zs.Focus();
            }
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
                textBoxRePass_zs.Focus();
            }
        }

        private void RigisterForm_Load(object sender, EventArgs e)
        {
           
                textBoxName_zs.Focus();
            
        }
    }

   
}
