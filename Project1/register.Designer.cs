namespace Project1
{
    partial class register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.firstname = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.conpass = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstname
            // 
            this.firstname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.firstname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstname.Font = new System.Drawing.Font("sd fighter v1", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstname.Location = new System.Drawing.Point(114, 165);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(246, 27);
            this.firstname.TabIndex = 10;
            this.firstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstname_KeyPress);
            // 
            // lastname
            // 
            this.lastname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lastname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastname.Font = new System.Drawing.Font("sd fighter v1", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastname.Location = new System.Drawing.Point(444, 165);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(246, 27);
            this.lastname.TabIndex = 11;
            this.lastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstname_KeyPress);
            // 
            // tel
            // 
            this.tel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.tel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tel.Font = new System.Drawing.Font("sd fighter v1", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tel.Location = new System.Drawing.Point(278, 217);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(246, 27);
            this.tel.TabIndex = 12;
            this.tel.TextChanged += new System.EventHandler(this.tel_TextChanged);
            this.tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tel_KeyPress);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("sd fighter v1", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(278, 271);
            this.password.MaxLength = 8;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(246, 27);
            this.password.TabIndex = 13;
            this.password.UseSystemPasswordChar = true;
            // 
            // conpass
            // 
            this.conpass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.conpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conpass.Font = new System.Drawing.Font("sd fighter v1", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conpass.Location = new System.Drawing.Point(278, 327);
            this.conpass.MaxLength = 8;
            this.conpass.Name = "conpass";
            this.conpass.Size = new System.Drawing.Size(246, 27);
            this.conpass.TabIndex = 14;
            this.conpass.UseSystemPasswordChar = true;
            this.conpass.TextChanged += new System.EventHandler(this.conpass_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("sd klingon blade2", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(326, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 42);
            this.button2.TabIndex = 15;
            this.button2.Text = "REGISTER";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(108, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "Firstname";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(438, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 31);
            this.label2.TabIndex = 17;
            this.label2.Text = "Lastname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(196, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(128, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(128, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "Con-pass";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("sd newnormal", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(568, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 31);
            this.label6.TabIndex = 21;
            this.label6.Text = "*รหัสผ่านไม่ตรงกัน*";
            this.label6.Visible = false;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project1.Properties.Resources.regis;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.conpass);
            this.Controls.Add(this.password);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.firstname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "register";
            this.Text = "register";
            this.Load += new System.EventHandler(this.register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox conpass;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}