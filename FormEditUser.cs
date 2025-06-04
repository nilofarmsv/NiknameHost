using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NikNameHost_ZS.Models;

namespace NikNameHost_ZS
{
    public partial class FormEditUser : Form
    {
       
        private string _userId;
        public FormEditUser(string userId)
        {
            InitializeComponent();

            _userId = userId;
        }
        private byte[] uploadedImageBytes;
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SEPIDYARHESAB;Database=Project_ZS;User Id=damavand;Password=damavand;");
            }
        }
        private void FormEditUser_Load(object sender, EventArgs e)
        {
           var user= _userId;
            Guid userGuid;
            Guid.TryParse(user, out userGuid);
            var context = new DbContextZS();
            var findUser=context.Employees.FirstOrDefault(emp=>emp.Id == userGuid);
            if (findUser != null)
            {
                textBoxEditName_zs.Text = findUser.Name;
                textBoxEditFamily_zs.Text = findUser.Family;
                textBoxEditNationalCode_zs.Text=findUser.NationalCode;
                textBoxEditPhon_zs.Text = findUser.Phone;
                textBoxEditUserName_zs.Text = findUser.UserName;
                textBoxEditPass_zs.Text = findUser.Password;
                if (findUser.filePath!=null)
                {
                    MemoryStream ms=new MemoryStream(findUser.filePath);
                    pictureBoxEditImg_zs.Image=Image.FromStream(ms);

                }
                else
                {
                    MessageBox.Show("عکسی پیدا نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("کاربری پیدا نشد","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
           
        }

        private void buttonEditOk_zs_Click(object sender, EventArgs e)
        {
            var context=new DbContextZS();
            string role = "";
            foreach (Control control in groupBoxEditUser_zs.Controls)
            {
                if (control is RadioButton radio && radio.Checked)
                {
                    role = radio.Tag.ToString();
                    break;
                }
            }
            var user = _userId;
            Guid userGuid;
            Guid.TryParse(user, out userGuid);
            var editUser=context.Employees.FirstOrDefault(emp=>emp.Id == userGuid);
            if (editUser!=null)
            {
                editUser.Name = textBoxEditName_zs.Text;
                editUser.Family = textBoxEditFamily_zs.Text;
                editUser.NationalCode = textBoxEditNationalCode_zs.Text;
                editUser.UserName = textBoxEditUserName_zs.Text;
                editUser.Password = textBoxEditPass_zs.Text;
                editUser.Phone = textBoxEditPhon_zs.Text;
                editUser.Position = role;
                if (pictureBoxEditImg_zs.Image!=null)
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBoxEditImg_zs.Image.Save(ms,pictureBoxEditImg_zs.Image.RawFormat);
                    editUser.filePath = ms.ToArray();
                }

                context.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت بروزرسانی شد", "پیام", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("کاربر پیدا نشد", "خطا", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonEditUpload_zs_Click(object sender, EventArgs e)
        {
            this.openFileDialogEdit_zs = new System.Windows.Forms.OpenFileDialog();
            openFileDialogEdit_zs.Filter = $"Image Files|*.jpg;*.jpeg;*.png";
            openFileDialogEdit_zs.Title = "انتخاب تصویر";
            if (openFileDialogEdit_zs.ShowDialog() == DialogResult.OK)
            {
                pictureBoxEditImg_zs.Image = Image.FromFile(openFileDialogEdit_zs.FileName);
                var stream = new FileStream(openFileDialogEdit_zs.FileName, FileMode.Open, FileAccess.Read);
                var binaryReader = new BinaryReader(stream);
                uploadedImageBytes = binaryReader.ReadBytes((int)stream.Length);
            }
        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MainForm ExForm = new MainForm();
            //ExForm.Show();
            //this.Hide();
        }
    }
}
