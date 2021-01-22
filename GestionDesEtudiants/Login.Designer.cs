
namespace GestionDesEtudiants
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.eyeSlash = new System.Windows.Forms.Button();
            this.eye = new System.Windows.Forms.Button();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.signIn = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.password);
            this.panel3.Controls.Add(this.username);
            this.panel3.Controls.Add(this.eyeSlash);
            this.panel3.Controls.Add(this.eye);
            this.panel3.Controls.Add(this.iconPictureBox3);
            this.panel3.Controls.Add(this.iconPictureBox2);
            this.panel3.Controls.Add(this.signIn);
            this.panel3.Controls.Add(this.iconPictureBox1);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(231, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 437);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 427);
            this.panel5.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 5);
            this.panel1.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(249, 5);
            this.panel8.TabIndex = 14;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(258, 256);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(233, 26);
            this.password.TabIndex = 11;
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(258, 197);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(233, 26);
            this.username.TabIndex = 10;
            // 
            // eyeSlash
            // 
            this.eyeSlash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eyeSlash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyeSlash.FlatAppearance.BorderSize = 0;
            this.eyeSlash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eyeSlash.Image = global::GestionDesEtudiants.Properties.Resources.eyeSlash;
            this.eyeSlash.Location = new System.Drawing.Point(497, 257);
            this.eyeSlash.Name = "eyeSlash";
            this.eyeSlash.Size = new System.Drawing.Size(37, 26);
            this.eyeSlash.TabIndex = 9;
            this.eyeSlash.UseVisualStyleBackColor = true;
            this.eyeSlash.Click += new System.EventHandler(this.eyeSlash_Click_1);
            // 
            // eye
            // 
            this.eye.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eye.FlatAppearance.BorderSize = 0;
            this.eye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eye.Image = global::GestionDesEtudiants.Properties.Resources.eye;
            this.eye.Location = new System.Drawing.Point(497, 256);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(37, 26);
            this.eye.TabIndex = 9;
            this.eye.UseVisualStyleBackColor = true;
            this.eye.Click += new System.EventHandler(this.eye_Click_1);
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 26;
            this.iconPictureBox3.Location = new System.Drawing.Point(222, 256);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.iconPictureBox3.Size = new System.Drawing.Size(30, 26);
            this.iconPictureBox3.TabIndex = 8;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 26;
            this.iconPictureBox2.Location = new System.Drawing.Point(222, 197);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.iconPictureBox2.Size = new System.Drawing.Size(30, 26);
            this.iconPictureBox2.TabIndex = 7;
            this.iconPictureBox2.TabStop = false;
            // 
            // signIn
            // 
            this.signIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.signIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signIn.ForeColor = System.Drawing.Color.White;
            this.signIn.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.signIn.IconColor = System.Drawing.Color.White;
            this.signIn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.signIn.IconSize = 35;
            this.signIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signIn.Location = new System.Drawing.Point(314, 329);
            this.signIn.Name = "signIn";
            this.signIn.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.signIn.Size = new System.Drawing.Size(121, 47);
            this.signIn.TabIndex = 6;
            this.signIn.Text = "S\'identifier";
            this.signIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.signIn.UseVisualStyleBackColor = false;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 100;
            this.iconPictureBox1.Location = new System.Drawing.Point(324, 41);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.iconPictureBox1.TabIndex = 4;
            this.iconPictureBox1.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 432);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(717, 5);
            this.panel6.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(717, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 432);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 5);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(721, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(463, 641);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(212)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application de gestion des étudiants";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button eyeSlash;
        private System.Windows.Forms.Button eye;
        private FontAwesome.Sharp.IconButton signIn;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}