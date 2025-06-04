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
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace NikNameHost_ZS
{
    public partial class MainForm : Form
    {
        private string _fullName;
        public MainForm(string fullName)
        {
            InitializeComponent();
            _fullName = fullName;
            labelWelcome_zs.Text = $"خوش آمدید {_fullName}";
        }
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SEPIDYARHESAB;Database=Project_ZS;User Id=damavand;Password=damavand;");
            }
        }

        private void RefreshDataGridView()
        {
            dataGridViewClient_zs.DataSource = null;
            dataGridViewClient_zs.Rows.Clear();
            dataGridViewClient_zs.Refresh();

            using (var context = new DbContextZS())
            {
                var users = context.Employees.ToList();
                dataGridViewClient_zs.DataSource = users;
            }
        }
        private Image ImageFromBytes(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        private void UpdateDays()
        {
            comboBoxDay_zs.Items.Clear();
            int selectedYear = Convert.ToInt32(comboBoxYear_zs.SelectedItem);
            int selectedMonth = Convert.ToInt32(comboBoxMonth_zs.SelectedItem);

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
                comboBoxDay_zs.Items.Add(i);
            }

            comboBoxDay_zs.SelectedIndex = 0;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            var context = new DbContextZS();
            var userGuid = LoggedInUser.UserId;
            var findUser = context.Employees.FirstOrDefault(emp => emp.Id == userGuid);
            var role = findUser.Position;
            if (role != "Rigister")
            {
                buttonDelete_zs.Enabled=false;
                buttonDele_zs.Enabled=false;
                
            }
            timer1.Start();
            dataGridViewClient_zs.DataSource = null;
           
            var users = context.Employees.Select(u => new UserGridViewModels
            {
                Id = u.Id,
                Name = u.Name,
                Family = u.Family,
                Phone = u.Phone,
                NationalCode = u.NationalCode,
                Position = u.Position,
                UserName = u.UserName,
                Password = u.Password,
                filePath = u.filePath
            }).ToList();

            dataGridViewClient_zs.DataSource = users;


            dataGridViewClient_zs.Columns["Id"].Visible = false;
            dataGridViewClient_zs.Columns["Name"].HeaderText = "نام";
            dataGridViewClient_zs.Columns["family"].HeaderText = "نام خانوادگی";
            dataGridViewClient_zs.Columns["UserName"].HeaderText = "نام کاربری";
            dataGridViewClient_zs.Columns["Password"].HeaderText = "رمز عبور";
            dataGridViewClient_zs.Columns["Phone"].HeaderText = "تلفن";
            dataGridViewClient_zs.Columns["Position"].HeaderText = "سمت";
            dataGridViewClient_zs.Columns["NationalCode"].HeaderText = "کد ملی";

            dataGridViewClient_zs.Columns["filePath"].HeaderText = "عکس کاربر";
            ((DataGridViewImageColumn)dataGridViewClient_zs.Columns["filePath"]).ImageLayout =
                DataGridViewImageCellLayout.Zoom;
            dataGridViewClient_zs.Columns["filePath"].Width = 100;









            // تنظیم فونت
            dataGridViewClient_zs.DefaultCellStyle.Font = new Font("Tahoma", 12);

            // تغییر رنگ ردیف‌ها
            dataGridViewClient_zs.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // تغییر رنگ ردیف‌ها هنگام انتخاب
            dataGridViewClient_zs.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridViewClient_zs.DefaultCellStyle.SelectionForeColor = Color.White;

            // تنظیم رنگ پس‌زمینه سلول‌ها در حالت معمولی
            dataGridViewClient_zs.DefaultCellStyle.BackColor = Color.White;


            RefreshDataGridView();

            dataGridViewAttendance_zs.DataSource = null;

            var attendance = (from u in context.Attendances
                              join a in context.Employees on u.EmployeeId equals a.Id
                              select new AttendanceGridViewModels
                              {
                                  Id = u.Id,
                                  EmployeeId = u.EmployeeId,
                                  Date = DateConverter.ConvertToPersianDate(u.Date),
                                  CheckInTime = u.CheckInTime.HasValue ? u.CheckInTime.Value.ToString("HH:mm") : " ",
                                  CheckOutTime = u.CheckOutTime.HasValue ? u.CheckOutTime.Value.ToString("HH:mm") : " ",
                                  Text = u.Text,
                                  Name = a.Name,
                                  Family = a.Family,
                              }).ToList();

            dataGridViewAttendance_zs.DataSource = attendance;


            dataGridViewAttendance_zs.Columns["Id"].Visible = false;
            dataGridViewAttendance_zs.Columns["Name"].HeaderText = "نام";
            dataGridViewAttendance_zs.Columns["family"].HeaderText = "نام خانوادگی";
            dataGridViewAttendance_zs.Columns["Date"].HeaderText = "تاریخ";
            dataGridViewAttendance_zs.Columns["CheckInTime"].HeaderText = "ساعت ورود";
            dataGridViewAttendance_zs.Columns["CheckOutTime"].HeaderText = "ساعت خروج";


            // تنظیم فونت
            dataGridViewAttendance_zs.DefaultCellStyle.Font = new Font("Tahoma", 12);

            // تغییر رنگ ردیف‌ها
            dataGridViewAttendance_zs.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // تغییر رنگ ردیف‌ها هنگام انتخاب
            dataGridViewAttendance_zs.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridViewAttendance_zs.DefaultCellStyle.SelectionForeColor = Color.White;

            // تنظیم رنگ پس‌زمینه سلول‌ها در حالت معمولی
            dataGridViewAttendance_zs.DefaultCellStyle.BackColor = Color.White;


            RefreshDataGridView();
            PersianCalendar pc = new PersianCalendar();
            int YearS = pc.GetYear(DateTime.Now);


            for (int i = YearS - 5; i <= YearS + 5; i++)
            {
                comboBoxYear_zs.Items.Add(i);
            }
            comboBoxYear_zs.SelectedItem = YearS;


            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth_zs.Items.Add(i);
            }
            comboBoxMonth_zs.SelectedItem = pc.GetMonth(DateTime.Now);
            UpdateDays();



            dataGridViewLeaveRequest_zs.DataSource = null;


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

            dataGridViewLeaveRequest_zs.DataSource = leaveRequests;


            dataGridViewLeaveRequest_zs.Columns["Id"].Visible = false;
            dataGridViewLeaveRequest_zs.Columns["EmploeeId"].Visible = false;
            dataGridViewLeaveRequest_zs.Columns["Name"].HeaderText = "نام";
            dataGridViewLeaveRequest_zs.Columns["family"].HeaderText = "نام خانوادگی";
            dataGridViewLeaveRequest_zs.Columns["FormDate"].HeaderText = "از تاریخ";
            dataGridViewLeaveRequest_zs.Columns["ToDate"].HeaderText = "تا تاریخ";
            dataGridViewLeaveRequest_zs.Columns["Text"].HeaderText = "علت";
            dataGridViewLeaveRequest_zs.Columns["Status"].HeaderText = "نتیجه درخواست";


            // تنظیم فونت
            dataGridViewLeaveRequest_zs.DefaultCellStyle.Font = new Font("Tahoma", 12);

            // تغییر رنگ ردیف‌ها
            dataGridViewLeaveRequest_zs.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // تغییر رنگ ردیف‌ها هنگام انتخاب
            dataGridViewLeaveRequest_zs.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridViewLeaveRequest_zs.DefaultCellStyle.SelectionForeColor = Color.White;

            // تنظیم رنگ پس‌زمینه سلول‌ها در حالت معمولی
            dataGridViewLeaveRequest_zs.DefaultCellStyle.BackColor = Color.White;
        }

        private void dataGridViewClient_zs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = dataGridViewClient_zs.Rows[e.RowIndex];
                    var userId = selectedRow.Cells["Id"].Value.ToString();

                    if (userId != null)
                    {
                        var editUserForm = new FormEditUser(userId);
                        editUserForm.Show();

                    }
                    else
                    {
                        MessageBox.Show("لطفا ابتدا یک کاربر را انتخاب کنید", "خطا", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }


                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void buttonAdd_zs_Click(object sender, EventArgs e)
        {

            RigisterForm addUser = new RigisterForm();
            addUser.Show();
            this.Hide();
        }

        private void buttonSearch_zs_Click(object sender, EventArgs e)
        {
        }

        private void textBoxSearch_zs_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxSearch_zs.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                var context = new DbContextZS();
                var filtered = context.Employees.Where(emp =>
                    emp.Name.ToLower().Contains(filterText) || emp.Family.ToLower().Contains(filterText)).ToList();
                dataGridViewClient_zs.DataSource = filtered;
            }
        }

        private void textBoxSearchAttendance_zs_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBoxSearchAttendance_zs.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                var context = new DbContextZS();
                var filtered = (from u in context.Attendances
                                join a in context.Employees on u.EmployeeId equals a.Id
                                where a.Name.ToLower().Contains(filterText) || a.Family.ToLower().Contains(filterText)
                                select new AttendanceGridViewModels
                                {
                                    Id = u.Id,
                                    EmployeeId = u.EmployeeId,
                                    Date = DateConverter.ConvertToPersianDate(u.Date),
                                    CheckInTime = u.CheckInTime.HasValue ? u.CheckInTime.Value.ToString("HH:mm") : " ",
                                    CheckOutTime = u.CheckInTime.HasValue ? u.CheckInTime.Value.ToString("HH:mm") : " ",

                                    Text = u.Text,
                                    Name = a.Name,
                                    Family = a.Family,
                                }).ToList();


                dataGridViewAttendance_zs.DataSource = filtered;
            }
        }
        private void LoadAttendanceByDate()
        {

        }



        private void comboBoxDay_zs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMonth_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxYear_zs.SelectedItem != null)
                UpdateDays();

        }

        private void comboBoxYear_zs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth_zs.SelectedItem != null)
                UpdateDays();

        }

        private void buttonSearch_zs_Click_1(object sender, EventArgs e)
        {
            try
            {
                int Day = int.Parse(comboBoxDay_zs.SelectedItem.ToString());
                int Month = int.Parse(comboBoxMonth_zs.SelectedItem.ToString());
                int Year = int.Parse(comboBoxYear_zs.SelectedItem.ToString());

                var date = new PersianCalendar().ToDateTime(Year, Month, Day, 0, 0, 0, 0);

                var context = new DbContextZS();
                var result = (from u in context.Attendances
                              join a in context.Employees on u.EmployeeId equals a.Id
                              where u.Date == date
                              select new AttendanceGridViewModels
                              {
                                  Id = u.Id,
                                  EmployeeId = u.EmployeeId,
                                  Date = DateConverter.ConvertToPersianDate(u.Date),
                                  CheckInTime = u.CheckInTime.HasValue ? u.CheckInTime.Value.ToString("HH:mm") : "",
                                  CheckOutTime = u.CheckOutTime.HasValue ? u.CheckOutTime.Value.ToString("HH:mm") : "",
                                  Name = a.Name,
                                  Family = a.Family
                              }).ToList();




                dataGridViewAttendance_zs.DataSource = result;
            }
            catch (Exception exception)
            {
                MessageBox.Show("خطا در جستجو");
                Console.WriteLine(exception);
                throw;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            labelDayAttendance_zs.Text = pc.GetYear(now) + "/" + pc.GetMonth(now).ToString("00") + "/" +
                                pc.GetDayOfMonth(now).ToString("00");
        }

        private void SearchLeaveRequest_zs_TextChanged(object sender, EventArgs e)
        {
            string filterText = SearchLeaveRequest_zs.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                var context = new DbContextZS();
                var filtered = (from u in context.LeaveRequests
                                join a in context.Employees on u.EmploeeId equals a.Id
                                where a.Name.ToLower().Contains(filterText) || a.Family.ToLower().Contains(filterText)
                                select new leaveRequestsGridViewModels()
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


                dataGridViewAttendance_zs.DataSource = filtered;
            }
        }

        private void dataGridViewLeaveRequest_zs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewLeaveRequest_zs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            var row = dataGridViewLeaveRequest_zs.Rows[e.RowIndex];
            textBoxAttName_zs.Text = row.Cells["Name"].Value?.ToString();
            textBoxFamilyAtt_zs.Text = row.Cells["Family"].Value?.ToString();
            textBoxAttDateS_zs.Text = Convert.ToDateTime(row.Cells["FormDate"].Value).ToString("yyyy/MM/dd");
            textBoxAttDateF_zs.Text = Convert.ToDateTime(row.Cells["ToDate"].Value).ToString("yyyy/MM/dd");
            richTextBox_zs.Text = row.Cells["Text"].Value?.ToString();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAttDateS_zs_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewLeaveRequest_zs_SelectionChanged(object sender, EventArgs e)
        {




        }

        private void buttonDelete_zs_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridViewLeaveRequest_zs.SelectedRows.Count > 0)
                {
                    var selectedId = dataGridViewLeaveRequest_zs.SelectedRows[0].Cells["Id"].Value;
                    var context = new DbContextZS();
                    if (selectedId != null && Guid.TryParse(selectedId.ToString(), out Guid idValue))
                    {
                        var leave = context.LeaveRequests.FirstOrDefault(u => u.Id == idValue);
                        if (leave != null)
                        {
                            context.LeaveRequests.Remove(leave);
                            context.SaveChanges();
                            MessageBox.Show("درخواست مرخصی با موفقیت حذف شد");

                            var data = context.LeaveRequests.ToList();
                            dataGridViewLeaveRequest_zs.DataSource = data;
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
        private void UpdateLeaveRequestStatus(string newStatus)
        {
            using (SqlConnection con = new SqlConnection("Server=.\\SEPIDYARHESAB;Database=Project_ZS;User Id=damavand;Password=damavand"))
            {
                if (dataGridViewLeaveRequest_zs.SelectedRows.Count > 0)
                {
                    var row = dataGridViewLeaveRequest_zs.SelectedRows[0];


                    if (row.Cells["ID"].Value != null)
                    {
                        Guid selectedRequestId;

                        if (Guid.TryParse(row.Cells["ID"].Value.ToString(), out selectedRequestId))
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE [General].[LeaveRequests] SET [Status] = @status WHERE ID = @id", con);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@id", selectedRequestId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("درخواست با موفقیت " + newStatus + " شد.");

                                textBoxAttName_zs.Clear();
                                textBoxFamilyAtt_zs.Clear();
                                textBoxAttDateS_zs.Clear();
                                textBoxAttDateF_zs.Clear();
                                richTextBox_zs.Clear();
                                using (var context = new DbContextZS())
                                {
                                    var data = context.LeaveRequests.ToList();
                                    dataGridViewLeaveRequest_zs.DataSource = data;
                                }
                            }
                            else
                            {
                                MessageBox.Show("خطا در بروزرسانی درخواست!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("فرمت ID انتخاب‌شده معتبر نیست.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ستون ID خالی است.");
                    }
                }
                else
                {
                    MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
                }
            }



        }
        private void buttonNo_zs_Click(object sender, EventArgs e)
        {
            UpdateLeaveRequestStatus("رد شد");

        }

        private void buttonOk_zs_Click(object sender, EventArgs e)
        {
            UpdateLeaveRequestStatus("تأیید شد");
        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void buttonDele_zs_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClient_zs.SelectedRows.Count > 0)
                {
                    var selectedId = dataGridViewClient_zs.SelectedRows[0].Cells["Id"].Value;
                    var context = new DbContextZS();
                    if (selectedId != null && Guid.TryParse(selectedId.ToString(), out Guid idValue))
                    {
                        var leave = context.Employees.FirstOrDefault(u => u.Id == idValue);
                        if (leave != null)
                        {
                            context.Employees.Remove(leave);
                            context.SaveChanges();
                            MessageBox.Show("کاربر با موفقیت حذف شد");

                            var data = context.LeaveRequests.ToList();
                            dataGridViewClient_zs.DataSource = data;
                        }
                        else
                        {
                            MessageBox.Show("کاربر پیدا نشد");
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
    }
}
    
