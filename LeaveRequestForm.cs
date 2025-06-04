using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using NikNameHost_ZS.Models;

namespace NikNameHost_ZS
{
    public partial class LeaveRequestForm : Form
    {
        private string _fullName;
        public LeaveRequestForm(string fullName)
        {
            InitializeComponent();
            _fullName = fullName;
        }
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SEPIDYARHESAB;Database=Project_ZS;User Id=damavand;Password=damavand;");
            }
        }
        private void dateTimePickerStart_zs_ValueChanged(object sender, EventArgs e)
        {


        }
        private void UpdateDays_S()
        {
            comboBoxDayS_zs.Items.Clear();
            int selectedYear = Convert.ToInt32(comboBoxYearS_zs.SelectedItem);
            int selectedMonth = Convert.ToInt32(comboBoxMonthS_zs.SelectedItem);

            int daysInMonth;
            if (selectedMonth <= 6)
                daysInMonth = 31;
            else if (selectedMonth <= 11)
                daysInMonth = 30;
            else
            {

                PersianCalendar pc = new PersianCalendar();
                if (pc.IsLeapYear(selectedYear))
                    daysInMonth = 30;
                else
                    daysInMonth = 29;
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                comboBoxDayS_zs.Items.Add(i);
            }

            comboBoxDayS_zs.SelectedIndex = 0;
        }
        private void UpdateDays_F()
        {
            comboBoxDayF_zs.Items.Clear();
            int selectedYear = Convert.ToInt32(comboBoxYearF_zs.SelectedItem);
            int selectedMonth = Convert.ToInt32(comboBoxMonthF_zs.SelectedItem);

            int daysInMonth;
            if (selectedMonth <= 6)
                daysInMonth = 31;
            else if (selectedMonth <= 11)
                daysInMonth = 30;
            else
            {

                PersianCalendar pc = new PersianCalendar();
                if (pc.IsLeapYear(selectedYear))
                    daysInMonth = 30;
                else
                    daysInMonth = 29;
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                comboBoxDayF_zs.Items.Add(i);
            }

            comboBoxDayF_zs.SelectedIndex = 0;
        }
        private void LeaveRequestForm_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            int YearS = pc.GetYear(DateTime.Now);


            for (int i = YearS - 5; i <= YearS + 5; i++)
            {
                comboBoxYearS_zs.Items.Add(i);
            }
            comboBoxYearS_zs.SelectedItem = YearS;


            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonthS_zs.Items.Add(i);
            }
            comboBoxMonthS_zs.SelectedItem = pc.GetMonth(DateTime.Now);

            UpdateDays_S();



            int YearF = pc.GetYear(DateTime.Now);


            for (int i = YearF - 5; i <= YearF + 5; i++)
            {
                comboBoxYearF_zs.Items.Add(i);
            }
            comboBoxYearF_zs.SelectedItem = YearF;


            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonthF_zs.Items.Add(i);
            }
            comboBoxMonthF_zs.SelectedItem = pc.GetMonth(DateTime.Now);

            UpdateDays_F();


            var context = new DbContextZS();

            dataGridViewLeaveRequests_zs.DataSource = null;
          
          
            var leaveRequests = (from u in context.LeaveRequests
                                 join a in context.Employees on u.EmploeeId equals a.Id
                                 select new leaveRequestsGridViewModels
                                 {
                                     Id = u.Id,
                                     EmploeeId = u.EmploeeId,
                                     FormDate = DateConverter.ConvertToPersianDate(u.FormDate),
                                     ToDate = DateConverter.ConvertToPersianDate(u.ToDate),
                                     Text = u.Text,
                                     Name = a.Name,
                                     Family = a.Family,
                                     Status = u.Status
                                 }).ToList();

            dataGridViewLeaveRequests_zs.DataSource = leaveRequests;


            dataGridViewLeaveRequests_zs.Columns["Id"].Visible = false;
            dataGridViewLeaveRequests_zs.Columns["EmploeeId"].Visible = false;
            dataGridViewLeaveRequests_zs.Columns["Name"].HeaderText = "نام";
            dataGridViewLeaveRequests_zs.Columns["family"].HeaderText = "نام خانوادگی";
            dataGridViewLeaveRequests_zs.Columns["FormDate"].HeaderText = "از تاریخ";
            dataGridViewLeaveRequests_zs.Columns["ToDate"].HeaderText = "تا تاریخ";
            dataGridViewLeaveRequests_zs.Columns["Text"].HeaderText = "علت";
            dataGridViewLeaveRequests_zs.Columns["Status"].HeaderText = "نتیجه درخواست";


            // تنظیم فونت
            dataGridViewLeaveRequests_zs.DefaultCellStyle.Font = new Font("Tahoma", 12);

            // تغییر رنگ ردیف‌ها
            dataGridViewLeaveRequests_zs.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // تغییر رنگ ردیف‌ها هنگام انتخاب
            dataGridViewLeaveRequests_zs.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridViewLeaveRequests_zs.DefaultCellStyle.SelectionForeColor = Color.White;

            // تنظیم رنگ پس‌زمینه سلول‌ها در حالت معمولی
            dataGridViewLeaveRequests_zs.DefaultCellStyle.BackColor = Color.White;



        }

        private void comboBoxYearS_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonthS_zs.SelectedItem != null)
                UpdateDays_S();
        }

        private void comboBoxMonthS_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYearS_zs.SelectedItem != null)
                UpdateDays_S();
        }

        private void comboBoxYearF_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonthF_zs.SelectedItem != null)
                UpdateDays_F();
        }

        private void comboBoxMonthF_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYearF_zs.SelectedItem != null)
                UpdateDays_F();
        }

        private void buttonOk_zs_Click(object sender, EventArgs e)
        {
            try
            {
                int startYear = int.Parse(comboBoxYearS_zs.Text);
                int startMonth = int.Parse(comboBoxMonthS_zs.Text);
                int startDay = int.Parse(comboBoxDayS_zs.Text);
                int finishYear = int.Parse(comboBoxYearF_zs.Text);
                int finishMonth = int.Parse(comboBoxMonthF_zs.Text);
                int finishDay = int.Parse(comboBoxDayF_zs.Text);

                var startDate = new PersianCalendar().ToDateTime(startYear, startMonth, startDay, 0, 0, 0, 0);
                var finishDate = new PersianCalendar().ToDateTime(finishYear, finishMonth, finishDay, 0, 0, 0, 0);

                if (finishDate < startDate)
                {
                    MessageBox.Show("تاریخ پایان نمیتواند قبل از تاریخ شروع باشد");
                    return;
                }

                var context = new DbContextZS();
                var id = Guid.NewGuid();
                var userId = LoggedInUser.UserId;
                var request = new LeaveRequest
                {
                    Id = id,
                    EmploeeId = userId,
                    FormDate = startDate,
                    ToDate = finishDate,
                    Text = richTextBox_zs.Text.Trim(),
                    Status = "در انتظار تائید"
                };
                context.LeaveRequests.Add(request);
                context.SaveChanges();
                MessageBox.Show("درخواست مرخصی با موفقیت ثبت شد");
            }
            catch (Exception exception)
            {
                MessageBox.Show("خطا در ثبت مرخصی");
                Console.WriteLine(exception);
                throw;
            }
        }

        private void buttonDelete_zs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLeaveRequests_zs.SelectedRows.Count > 0)
                {
                    var selectedId = dataGridViewLeaveRequests_zs.SelectedRows[0].Cells["Id"].Value;
                    var context=new DbContextZS();
                    if (selectedId!=null && Guid.TryParse(selectedId.ToString(),out Guid idValue))
                    {
                        var leave = context.LeaveRequests.FirstOrDefault(u => u.Id == idValue);
                        if (leave!=null)
                        {
                            context.LeaveRequests.Remove(leave);
                            context.SaveChanges();
                            MessageBox.Show("درخواست مرخصی با موفقیت حذف شد");

                            var data = context.LeaveRequests.ToList();
                            dataGridViewLeaveRequests_zs.DataSource = data;
                        }
                        else
                        {
                            MessageBox.Show("درخواست مرخصی پیدا نشد");
                        }
                    }
                    
                }

                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void dataGridViewLeaveRequests_zs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           MainFormClient  ExForm = new MainFormClient(_fullName);
           ExForm.Show();
            this.Hide();
        }
    }
}
