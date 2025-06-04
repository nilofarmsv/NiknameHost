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
using System.Runtime.InteropServices;
using System.Globalization;


namespace NikNameHost_ZS
{
    public partial class MainFormClient : Form
    {
        private string _fullName;

        public MainFormClient(string fullName)
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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect,  // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private bool isOn = true;
        Color orange = Color.FromArgb(253, 172, 83);

        private void SetButtonState(bool checkIn)
        {
            isOn = checkIn;

            if (checkIn)
            {
                buttonAttendance_zs.BackColor = orange;
                buttonAttendance_zs.ForeColor = Color.White;

                buttonAttendanceOut_zs.BackColor = Color.White;
                buttonAttendanceOut_zs.ForeColor = orange;
            }
            else
            {
                buttonAttendanceOut_zs.BackColor = orange;
                buttonAttendanceOut_zs.ForeColor = Color.White;

                buttonAttendance_zs.BackColor = Color.White;
                buttonAttendance_zs.ForeColor = orange;
            }
        }

        private void buttonAttendance_zs_Click(object sender, EventArgs e)
        {

            SetButtonState(true);
            var context = new DbContextZS();

            var userId = LoggedInUser.UserId;
            var attendances =
                context.Attendances.FirstOrDefault(a => a.EmployeeId == userId && a.Date == DateTime.Today);
            if (attendances != null)
            {
              
                if (attendances.CheckInTime != null)
                {
                    MessageBox.Show("شما قبلا حضور خود را ثبت کردید");
                    return;
                }
                else
                {
                    MessageBox.Show("امروز هیچ حضوری ثبت نشده");
                    return;
                }

            }

            var attendance = new Attendance();
            var Id = Guid.NewGuid();
            attendance.Id = Id;
            attendance.EmployeeId = userId;
            attendance.Date = DateTime.Today;
            attendance.CheckInTime = DateTime.Now;
            attendance.Status = "ثبت";
            attendance.Text = "";
            context.Attendances.Add(attendance);
            context.SaveChanges();
            MessageBox.Show("حضور ثبت شد");
        }

        private void MainFormClient_Load(object sender, EventArgs e)
        {
            buttonAttendance_zs.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonAttendance_zs.Width, buttonAttendance_zs.Height, 30, 30));
            buttonAttendanceOut_zs.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, buttonAttendanceOut_zs.Width, buttonAttendanceOut_zs.Height, 30, 30));

            SetButtonState(true);
            
            timer1.Start();
            

        }

        private void buttonAttendanceOut_zs_Click(object sender, EventArgs e)
        {
            SetButtonState(false);
            var context = new DbContextZS();

            var userId = LoggedInUser.UserId;

            var attendance =
                context.Attendances.FirstOrDefault(a => a.EmployeeId == userId && a.Date == DateTime.Today);
            if (attendance.CheckOutTime == null)
            {
                DateTime Today = DateTime.Now;
                var id = Guid.NewGuid();

                var query = "UPDATE [General].[Attendance] SET  [CheckOutTime] = '" + Today + "' WHERE EmployeeId='" +
                            userId + "'";
                var result = context.Database.ExecuteSqlRaw(query);
                if (result != null)
                {
                    MessageBox.Show("خروج با موفقیت ثبت شد");
                }
                else
                {
                    MessageBox.Show("ثبت حضور برای امروز پیدا نشد یا قبلا خروج ثبت شده");
                }
            }
            else
            {
                if (attendance.CheckOutTime != null)
                {
                    MessageBox.Show("شما قبلا خروج خود را ثبت کردید");
                    return;
                }

                else
                {
                    MessageBox.Show("امروز هیچ حضوری ثبت نشده");
                    return;
                }
            }





        }



        private void buttonLeaveRequest_zs_Click(object sender, EventArgs e)
        {
            LeaveRequestForm request = new LeaveRequestForm(_fullName);
            request.ShowDialog();
        }

        private void labelWelcome_zs_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelClock_zs.Text = DateTime.Now.ToString("HH:mm");
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            labelDate_zs.Text = pc.GetYear(now) + "/" + pc.GetMonth(now).ToString("00") + "/" +
                                pc.GetDayOfMonth(now).ToString("00");
        }

        private void labelDate_zs_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelSingIn_zs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
