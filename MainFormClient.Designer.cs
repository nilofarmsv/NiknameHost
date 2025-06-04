namespace NikNameHost_ZS
{
    partial class MainFormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormClient));
            this.labelText_zs = new System.Windows.Forms.Label();
            this.buttonAttendance_zs = new System.Windows.Forms.Button();
            this.buttonAttendanceOut_zs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelClock_zs = new System.Windows.Forms.Label();
            this.buttonLeaveRequest_zs = new System.Windows.Forms.Button();
            this.labelDate_zs = new System.Windows.Forms.Label();
            this.labelWelcome_zs = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabelSingIn_zs = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelText_zs
            // 
            this.labelText_zs.AutoSize = true;
            this.labelText_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelText_zs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelText_zs.ForeColor = System.Drawing.Color.White;
            this.labelText_zs.Location = new System.Drawing.Point(138, 50);
            this.labelText_zs.Name = "labelText_zs";
            this.labelText_zs.Size = new System.Drawing.Size(135, 19);
            this.labelText_zs.TabIndex = 9;
            this.labelText_zs.Text = "ثبت ورود و خروج ";
            // 
            // buttonAttendance_zs
            // 
            this.buttonAttendance_zs.Location = new System.Drawing.Point(222, 169);
            this.buttonAttendance_zs.Name = "buttonAttendance_zs";
            this.buttonAttendance_zs.Size = new System.Drawing.Size(31, 29);
            this.buttonAttendance_zs.TabIndex = 10;
            this.buttonAttendance_zs.UseVisualStyleBackColor = true;
            this.buttonAttendance_zs.Click += new System.EventHandler(this.buttonAttendance_zs_Click);
            // 
            // buttonAttendanceOut_zs
            // 
            this.buttonAttendanceOut_zs.Location = new System.Drawing.Point(160, 169);
            this.buttonAttendanceOut_zs.Name = "buttonAttendanceOut_zs";
            this.buttonAttendanceOut_zs.Size = new System.Drawing.Size(31, 29);
            this.buttonAttendanceOut_zs.TabIndex = 11;
            this.buttonAttendanceOut_zs.UseVisualStyleBackColor = true;
            this.buttonAttendanceOut_zs.Click += new System.EventHandler(this.buttonAttendanceOut_zs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(219, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "ورود";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(155, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "خروج";
            // 
            // labelClock_zs
            // 
            this.labelClock_zs.AutoSize = true;
            this.labelClock_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelClock_zs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelClock_zs.ForeColor = System.Drawing.Color.White;
            this.labelClock_zs.Location = new System.Drawing.Point(26, 98);
            this.labelClock_zs.Name = "labelClock_zs";
            this.labelClock_zs.Size = new System.Drawing.Size(44, 16);
            this.labelClock_zs.TabIndex = 14;
            this.labelClock_zs.Text = "ساعت";
            // 
            // buttonLeaveRequest_zs
            // 
            this.buttonLeaveRequest_zs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLeaveRequest_zs.Location = new System.Drawing.Point(151, 327);
            this.buttonLeaveRequest_zs.Name = "buttonLeaveRequest_zs";
            this.buttonLeaveRequest_zs.Size = new System.Drawing.Size(120, 23);
            this.buttonLeaveRequest_zs.TabIndex = 15;
            this.buttonLeaveRequest_zs.Text = "درخواست مرخصی";
            this.buttonLeaveRequest_zs.UseVisualStyleBackColor = true;
            this.buttonLeaveRequest_zs.Click += new System.EventHandler(this.buttonLeaveRequest_zs_Click);
            // 
            // labelDate_zs
            // 
            this.labelDate_zs.AutoSize = true;
            this.labelDate_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelDate_zs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate_zs.ForeColor = System.Drawing.Color.White;
            this.labelDate_zs.Location = new System.Drawing.Point(316, 98);
            this.labelDate_zs.Name = "labelDate_zs";
            this.labelDate_zs.Size = new System.Drawing.Size(33, 16);
            this.labelDate_zs.TabIndex = 16;
            this.labelDate_zs.Text = "تاریخ";
            this.labelDate_zs.Click += new System.EventHandler(this.labelDate_zs_Click);
            // 
            // labelWelcome_zs
            // 
            this.labelWelcome_zs.AutoSize = true;
            this.labelWelcome_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome_zs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWelcome_zs.ForeColor = System.Drawing.Color.White;
            this.labelWelcome_zs.Location = new System.Drawing.Point(12, 9);
            this.labelWelcome_zs.Name = "labelWelcome_zs";
            this.labelWelcome_zs.Size = new System.Drawing.Size(21, 14);
            this.labelWelcome_zs.TabIndex = 17;
            this.labelWelcome_zs.Text = "نام";
            this.labelWelcome_zs.Click += new System.EventHandler(this.labelWelcome_zs_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // linkLabelSingIn_zs
            // 
            this.linkLabelSingIn_zs.AutoSize = true;
            this.linkLabelSingIn_zs.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSingIn_zs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(172)))), ((int)(((byte)(83)))));
            this.linkLabelSingIn_zs.Location = new System.Drawing.Point(368, 380);
            this.linkLabelSingIn_zs.Name = "linkLabelSingIn_zs";
            this.linkLabelSingIn_zs.Size = new System.Drawing.Size(32, 15);
            this.linkLabelSingIn_zs.TabIndex = 33;
            this.linkLabelSingIn_zs.TabStop = true;
            this.linkLabelSingIn_zs.Text = "خروج";
            this.linkLabelSingIn_zs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSingIn_zs_LinkClicked);
            // 
            // MainFormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NikNameHost_ZS.Properties.Resources.photo_2025_04_17_16_20_23;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(415, 404);
            this.Controls.Add(this.linkLabelSingIn_zs);
            this.Controls.Add(this.labelWelcome_zs);
            this.Controls.Add(this.labelDate_zs);
            this.Controls.Add(this.buttonLeaveRequest_zs);
            this.Controls.Add(this.labelClock_zs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAttendanceOut_zs);
            this.Controls.Add(this.buttonAttendance_zs);
            this.Controls.Add(this.labelText_zs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه اصلی";
            this.Load += new System.EventHandler(this.MainFormClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelText_zs;
        private Button buttonAttendance_zs;
        private Button buttonAttendanceOut_zs;
        private Label label1;
        private Label label2;
        private Label labelClock_zs;
        private Button buttonLeaveRequest_zs;
        private Label labelDate_zs;
        private Label labelWelcome_zs;
        private System.Windows.Forms.Timer timer1;
        private LinkLabel linkLabelSingIn_zs;
    }
}