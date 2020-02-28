namespace FiratObs.CourseRegistrationChecker
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCourses = new System.Windows.Forms.Label();
            this.tbxCourses = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(308, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Tamam";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(161, 23);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(222, 22);
            this.tbxUserName.TabIndex = 2;
            this.tbxUserName.Text = "16260012";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(161, 71);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(222, 22);
            this.tbxPassword.TabIndex = 4;
            this.tbxPassword.Text = "Harun27..";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre : ";
            // 
            // lblCourses
            // 
            this.lblCourses.AutoSize = true;
            this.lblCourses.Location = new System.Drawing.Point(55, 287);
            this.lblCourses.Name = "lblCourses";
            this.lblCourses.Size = new System.Drawing.Size(0, 17);
            this.lblCourses.TabIndex = 5;
            // 
            // tbxCourses
            // 
            this.tbxCourses.Location = new System.Drawing.Point(161, 102);
            this.tbxCourses.Name = "tbxCourses";
            this.tbxCourses.Size = new System.Drawing.Size(222, 96);
            this.tbxCourses.TabIndex = 6;
            this.tbxCourses.Text = "BİYOİNFORMATİK-ELEKTRONİK TİCARET-KABLOSUZ VE MOBİL AĞLAR";
            this.tbxCourses.TextChanged += new System.EventHandler(this.tbxCourses_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dersler :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(445, 354);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxCourses);
            this.Controls.Add(this.lblCourses);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCourses;
        private System.Windows.Forms.RichTextBox tbxCourses;
        private System.Windows.Forms.Label label3;
    }
}

