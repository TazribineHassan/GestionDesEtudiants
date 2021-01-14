
namespace GestionDesEtudiants
{
    partial class MainForm
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
            this.menu = new System.Windows.Forms.Panel();
            this.subMenu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.repo = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.logo = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.header = new System.Windows.Forms.Panel();
            this.currentLblText = new System.Windows.Forms.Label();
            this.currentBtnIcon = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.desktop = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.subMenu.SuspendLayout();
            this.logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentBtnIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoScroll = true;
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.menu.Controls.Add(this.subMenu);
            this.menu.Controls.Add(this.repo);
            this.menu.Controls.Add(this.iconButton3);
            this.menu.Controls.Add(this.iconButton2);
            this.menu.Controls.Add(this.iconButton1);
            this.menu.Controls.Add(this.logo);
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(200, 641);
            this.menu.TabIndex = 0;
            // 
            // subMenu
            // 
            this.subMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(160)))));
            this.subMenu.Controls.Add(this.button2);
            this.subMenu.Controls.Add(this.button1);
            this.subMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.subMenu.Location = new System.Drawing.Point(0, 400);
            this.subMenu.Name = "subMenu";
            this.subMenu.Size = new System.Drawing.Size(200, 100);
            this.subMenu.TabIndex = 5;
            this.subMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 50);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(200, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Chaque étudiant";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Touts les étudiants";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.download_Click);
            // 
            // repo
            // 
            this.repo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repo.Dock = System.Windows.Forms.DockStyle.Top;
            this.repo.FlatAppearance.BorderSize = 0;
            this.repo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repo.ForeColor = System.Drawing.Color.White;
            this.repo.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.repo.IconColor = System.Drawing.Color.White;
            this.repo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.repo.IconSize = 40;
            this.repo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.repo.Location = new System.Drawing.Point(0, 340);
            this.repo.Name = "repo";
            this.repo.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.repo.Size = new System.Drawing.Size(200, 60);
            this.repo.TabIndex = 4;
            this.repo.Text = "Reporting";
            this.repo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.repo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.repo.UseVisualStyleBackColor = true;
            this.repo.Click += new System.EventHandler(this.btnReportClick);
            // 
            // iconButton3
            // 
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.White;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 40;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 280);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton3.Size = new System.Drawing.Size(200, 60);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "Statistique";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.btnStaticsCilck);
            // 
            // iconButton2
            // 
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.White;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 40;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 220);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton2.Size = new System.Drawing.Size(200, 60);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "Etudiant";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.btnStudentClick);
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.CodeBranch;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 160);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton1.Size = new System.Drawing.Size(200, 60);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Filière";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.btnBranchClick);
            // 
            // logo
            // 
            this.logo.Controls.Add(this.btnStart);
            this.logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(200, 160);
            this.logo.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Image = global::GestionDesEtudiants.Properties.Resources.logo;
            this.btnStart.Location = new System.Drawing.Point(12, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(167, 117);
            this.btnStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnStart.TabIndex = 0;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.header.Controls.Add(this.currentLblText);
            this.header.Controls.Add(this.currentBtnIcon);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(200, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(984, 80);
            this.header.TabIndex = 1;
            // 
            // currentLblText
            // 
            this.currentLblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentLblText.AutoSize = true;
            this.currentLblText.Font = new System.Drawing.Font("Microsoft New Tai Lue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLblText.ForeColor = System.Drawing.Color.White;
            this.currentLblText.Location = new System.Drawing.Point(474, 30);
            this.currentLblText.Name = "currentLblText";
            this.currentLblText.Size = new System.Drawing.Size(68, 27);
            this.currentLblText.TabIndex = 1;
            this.currentLblText.Text = "Home";
            // 
            // currentBtnIcon
            // 
            this.currentBtnIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentBtnIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.currentBtnIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.currentBtnIcon.IconColor = System.Drawing.Color.White;
            this.currentBtnIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.currentBtnIcon.IconSize = 40;
            this.currentBtnIcon.Location = new System.Drawing.Point(416, 21);
            this.currentBtnIcon.Name = "currentBtnIcon";
            this.currentBtnIcon.Size = new System.Drawing.Size(40, 40);
            this.currentBtnIcon.TabIndex = 0;
            this.currentBtnIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(101)))), ((int)(((byte)(160)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 10);
            this.panel1.TabIndex = 2;
            // 
            // desktop
            // 
            this.desktop.AutoScroll = true;
            this.desktop.AutoScrollMinSize = new System.Drawing.Size(984, 476);
            this.desktop.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.desktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktop.Location = new System.Drawing.Point(200, 90);
            this.desktop.Name = "desktop";
            this.desktop.Size = new System.Drawing.Size(984, 551);
            this.desktop.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 641);
            this.Controls.Add(this.desktop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.Controls.Add(this.menu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application de gestion des étudiants";
            this.menu.ResumeLayout(false);
            this.subMenu.ResumeLayout(false);
            this.logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentBtnIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel logo;
        private FontAwesome.Sharp.IconButton repo;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label currentLblText;
        private FontAwesome.Sharp.IconPictureBox currentBtnIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel desktop;
        private System.Windows.Forms.Panel subMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

