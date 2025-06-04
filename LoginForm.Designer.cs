namespace NikNameHost_ZS
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBoxUserName_zs = new System.Windows.Forms.TextBox();
            this.textBoxPass_zs = new System.Windows.Forms.TextBox();
            this.labelUserName_zs = new System.Windows.Forms.Label();
            this.labelPass_zs = new System.Windows.Forms.Label();
            this.labelText_zs = new System.Windows.Forms.Label();
            this.buttonLogin_zs = new System.Windows.Forms.Button();
            this.linkLabelSingIn_zs = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBoxUserName_zs
            // 
            this.textBoxUserName_zs.Location = new System.Drawing.Point(147, 154);
            this.textBoxUserName_zs.Name = "textBoxUserName_zs";
            this.textBoxUserName_zs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxUserName_zs.Size = new System.Drawing.Size(179, 23);
            this.textBoxUserName_zs.TabIndex = 0;
            this.textBoxUserName_zs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_zs_KeyDown);
            // 
            // textBoxPass_zs
            // 
            this.textBoxPass_zs.Location = new System.Drawing.Point(147, 197);
            this.textBoxPass_zs.Name = "textBoxPass_zs";
            this.textBoxPass_zs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxPass_zs.Size = new System.Drawing.Size(179, 23);
            this.textBoxPass_zs.TabIndex = 1;
            this.textBoxPass_zs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPass_zs_KeyDown);
            // 
            // labelUserName_zs
            // 
            this.labelUserName_zs.AutoSize = true;
            this.labelUserName_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName_zs.ForeColor = System.Drawing.Color.White;
            this.labelUserName_zs.Location = new System.Drawing.Point(379, 156);
            this.labelUserName_zs.Name = "labelUserName_zs";
            this.labelUserName_zs.Size = new System.Drawing.Size(55, 15);
            this.labelUserName_zs.TabIndex = 2;
            this.labelUserName_zs.Text = "نام کاربری";
            // 
            // labelPass_zs
            // 
            this.labelPass_zs.AutoSize = true;
            this.labelPass_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelPass_zs.ForeColor = System.Drawing.Color.White;
            this.labelPass_zs.Location = new System.Drawing.Point(379, 197);
            this.labelPass_zs.Name = "labelPass_zs";
            this.labelPass_zs.Size = new System.Drawing.Size(48, 15);
            this.labelPass_zs.TabIndex = 3;
            this.labelPass_zs.Text = "رمز عبور";
            // 
            // labelText_zs
            // 
            this.labelText_zs.AutoSize = true;
            this.labelText_zs.BackColor = System.Drawing.Color.Transparent;
            this.labelText_zs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelText_zs.ForeColor = System.Drawing.Color.White;
            this.labelText_zs.Location = new System.Drawing.Point(120, 57);
            this.labelText_zs.Name = "labelText_zs";
            this.labelText_zs.Size = new System.Drawing.Size(231, 19);
            this.labelText_zs.TabIndex = 8;
            this.labelText_zs.Text = "ورود به سیستم حضور و غیاب";
            // 
            // buttonLogin_zs
            // 
            this.buttonLogin_zs.Location = new System.Drawing.Point(201, 262);
            this.buttonLogin_zs.Name = "buttonLogin_zs";
            this.buttonLogin_zs.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin_zs.TabIndex = 9;
            this.buttonLogin_zs.Text = "ورود";
            this.buttonLogin_zs.UseVisualStyleBackColor = true;
            this.buttonLogin_zs.Click += new System.EventHandler(this.buttonLogin_zs_Click);
            // 
            // linkLabelSingIn_zs
            // 
            this.linkLabelSingIn_zs.AutoSize = true;
            this.linkLabelSingIn_zs.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSingIn_zs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(172)))), ((int)(((byte)(83)))));
            this.linkLabelSingIn_zs.Location = new System.Drawing.Point(309, 411);
            this.linkLabelSingIn_zs.Name = "linkLabelSingIn_zs";
            this.linkLabelSingIn_zs.Size = new System.Drawing.Size(126, 15);
            this.linkLabelSingIn_zs.TabIndex = 12;
            this.linkLabelSingIn_zs.TabStop = true;
            this.linkLabelSingIn_zs.Text = "ثبت نام نکردی ؟کلیک کن";
            this.linkLabelSingIn_zs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSingIn_zs_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(172)))), ((int)(((byte)(83)))));
            this.linkLabel1.Location = new System.Drawing.Point(31, 411);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(32, 15);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "خروج";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NikNameHost_ZS.Properties.Resources.photo_2025_04_17_16_20_23;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(476, 480);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabelSingIn_zs);
            this.Controls.Add(this.buttonLogin_zs);
            this.Controls.Add(this.labelText_zs);
            this.Controls.Add(this.labelPass_zs);
            this.Controls.Add(this.labelUserName_zs);
            this.Controls.Add(this.textBoxPass_zs);
            this.Controls.Add(this.textBoxUserName_zs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxUserName_zs;
        private TextBox textBoxPass_zs;
        private Label labelUserName_zs;
        private Label labelPass_zs;
        private Label labelText_zs;
        private Button buttonLogin_zs;
        private LinkLabel linkLabelSingIn_zs;
        private LinkLabel linkLabel1;
    }
}