namespace Sales_market_application
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_log = new System.Windows.Forms.PictureBox();
            this.lb_log = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.checkBob_pass = new System.Windows.Forms.CheckBox();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.lbshow = new System.Windows.Forms.Label();
            this.lbuser = new System.Windows.Forms.Label();
            this.lbpass = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_log)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_log
            // 
            this.pictureBox_log.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_log.Image")));
            this.pictureBox_log.Location = new System.Drawing.Point(305, 12);
            this.pictureBox_log.Name = "pictureBox_log";
            this.pictureBox_log.Size = new System.Drawing.Size(106, 123);
            this.pictureBox_log.TabIndex = 0;
            this.pictureBox_log.TabStop = false;
            // 
            // lb_log
            // 
            this.lb_log.AutoSize = true;
            this.lb_log.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_log.Location = new System.Drawing.Point(308, 138);
            this.lb_log.Name = "lb_log";
            this.lb_log.Size = new System.Drawing.Size(103, 39);
            this.lb_log.TabIndex = 1;
            this.lb_log.Text = "Log in";
            // 
            // textBox_user
            // 
            this.textBox_user.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_user.Location = new System.Drawing.Point(252, 225);
            this.textBox_user.MaxLength = 26;
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(229, 26);
            this.textBox_user.TabIndex = 4;
            // 
            // checkBob_pass
            // 
            this.checkBob_pass.AutoSize = true;
            this.checkBob_pass.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBob_pass.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBob_pass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBob_pass.Location = new System.Drawing.Point(456, 345);
            this.checkBob_pass.Name = "checkBob_pass";
            this.checkBob_pass.Size = new System.Drawing.Size(15, 14);
            this.checkBob_pass.TabIndex = 2;
            this.checkBob_pass.UseVisualStyleBackColor = false;
            this.checkBob_pass.CheckedChanged += new System.EventHandler(this.checkBob_pass_CheckedChanged);
            // 
            // textBox_pass
            // 
            this.textBox_pass.AcceptsReturn = true;
            this.textBox_pass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pass.Location = new System.Drawing.Point(252, 341);
            this.textBox_pass.MaxLength = 15;
            this.textBox_pass.Multiline = true;
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.PasswordChar = '*';
            this.textBox_pass.Size = new System.Drawing.Size(229, 26);
            this.textBox_pass.TabIndex = 3;
            // 
            // lbshow
            // 
            this.lbshow.AutoSize = true;
            this.lbshow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbshow.Location = new System.Drawing.Point(487, 363);
            this.lbshow.Name = "lbshow";
            this.lbshow.Size = new System.Drawing.Size(40, 16);
            this.lbshow.TabIndex = 5;
            this.lbshow.Text = "Show";
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbuser.Location = new System.Drawing.Point(121, 222);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(113, 25);
            this.lbuser.TabIndex = 6;
            this.lbuser.Text = "User name";
            // 
            // lbpass
            // 
            this.lbpass.AutoSize = true;
            this.lbpass.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpass.Location = new System.Drawing.Point(134, 342);
            this.lbpass.Name = "lbpass";
            this.lbpass.Size = new System.Drawing.Size(100, 25);
            this.lbpass.TabIndex = 7;
            this.lbpass.Text = "Password";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheck.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.Location = new System.Drawing.Point(591, 424);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(114, 53);
            this.btnCheck.TabIndex = 8;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(713, 489);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbpass);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.lbshow);
            this.Controls.Add(this.checkBob_pass);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.lb_log);
            this.Controls.Add(this.pictureBox_log);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Market";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_log)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_log;
        private System.Windows.Forms.Label lb_log;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.CheckBox checkBob_pass;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.Label lbshow;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Label lbpass;
        private System.Windows.Forms.Button btnCheck;
    }
}

