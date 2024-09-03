
namespace Main_Screen
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.btnCheck = new System.Windows.Forms.Button();
            this.lbpass = new System.Windows.Forms.Label();
            this.lbshow = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.pictureBox_log = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Check_Box = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_log)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.btnCheck, "btnCheck");
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.Check);
            // 
            // lbpass
            // 
            resources.ApplyResources(this.lbpass, "lbpass");
            this.lbpass.Name = "lbpass";
            // 
            // lbshow
            // 
            resources.ApplyResources(this.lbshow, "lbshow");
            this.lbshow.Name = "lbshow";
            // 
            // name
            // 
            this.name.AllowDrop = true;
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // pictureBox_log
            // 
            resources.ApplyResources(this.pictureBox_log, "pictureBox_log");
            this.pictureBox_log.Name = "pictureBox_log";
            this.pictureBox_log.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Password
            // 
            this.Password.AllowDrop = true;
            resources.ApplyResources(this.Password, "Password");
            this.Password.Name = "Password";
            // 
            // Check_Box
            // 
            resources.ApplyResources(this.Check_Box, "Check_Box");
            this.Check_Box.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Check_Box.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Check_Box.Name = "Check_Box";
            this.Check_Box.TabStop = false;
            this.Check_Box.UseVisualStyleBackColor = false;
            this.Check_Box.Click += new System.EventHandler(this.Show_Password);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LogIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.Check_Box);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbshow);
            this.Controls.Add(this.name);
            this.Controls.Add(this.pictureBox_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_log)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Label lbshow;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.PictureBox pictureBox_log;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.CheckBox Check_Box;
        private System.Windows.Forms.Label label1;
    }
}