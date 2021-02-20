
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.user = new System.Windows.Forms.Label();
            this.image = new FontAwesome.Sharp.IconPictureBox();
            this.currentLblText = new System.Windows.Forms.Label();
            this.currentBtnIcon = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.desktop = new System.Windows.Forms.Panel();
            this.param = new System.Windows.Forms.GroupBox();
            this.validate = new FontAwesome.Sharp.IconButton();
            this.importer = new FontAwesome.Sharp.IconButton();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.currrentPass = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setting = new FontAwesome.Sharp.IconButton();
            this.hour = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.subMenu.SuspendLayout();
            this.logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBtnIcon)).BeginInit();
            this.desktop.SuspendLayout();
            this.param.SuspendLayout();
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
            this.btnStart.Image = global::GestionDesEtudiants.Properties.Resources.GESTION_Des_ÉTUDIANTS;
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
            this.header.Controls.Add(this.iconPictureBox2);
            this.header.Controls.Add(this.user);
            this.header.Controls.Add(this.image);
            this.header.Controls.Add(this.currentLblText);
            this.header.Controls.Add(this.currentBtnIcon);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(200, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(984, 80);
            this.header.TabIndex = 1;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 50;
            this.iconPictureBox2.Location = new System.Drawing.Point(875, 21);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Padding = new System.Windows.Forms.Padding(2, 3, 0, 0);
            this.iconPictureBox2.Size = new System.Drawing.Size(50, 50);
            this.iconPictureBox2.TabIndex = 4;
            this.iconPictureBox2.TabStop = false;
            // 
            // user
            // 
            this.user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.ForeColor = System.Drawing.Color.White;
            this.user.Location = new System.Drawing.Point(696, 34);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(139, 21);
            this.user.TabIndex = 3;
            this.user.Text = "Tazribine Hassan";
            // 
            // image
            // 
            this.image.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.image.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.image.IconColor = System.Drawing.Color.White;
            this.image.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.image.IconSize = 50;
            this.image.Location = new System.Drawing.Point(931, 21);
            this.image.Name = "image";
            this.image.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.image.Size = new System.Drawing.Size(50, 50);
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            // 
            // currentLblText
            // 
            this.currentLblText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentLblText.AutoSize = true;
            this.currentLblText.Font = new System.Drawing.Font("Microsoft New Tai Lue", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLblText.ForeColor = System.Drawing.Color.White;
            this.currentLblText.Location = new System.Drawing.Point(52, 30);
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
            this.currentBtnIcon.Location = new System.Drawing.Point(6, 21);
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
            this.desktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(251)))));
            this.desktop.Controls.Add(this.param);
            this.desktop.Controls.Add(this.setting);
            this.desktop.Controls.Add(this.hour);
            this.desktop.Controls.Add(this.date);
            this.desktop.Controls.Add(this.label2);
            this.desktop.Controls.Add(this.label1);
            this.desktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desktop.Location = new System.Drawing.Point(200, 90);
            this.desktop.Name = "desktop";
            this.desktop.Size = new System.Drawing.Size(984, 551);
            this.desktop.TabIndex = 3;
            // 
            // param
            // 
            this.param.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param.Controls.Add(this.validate);
            this.param.Controls.Add(this.importer);
            this.param.Controls.Add(this.newPassword);
            this.param.Controls.Add(this.currrentPass);
            this.param.Controls.Add(this.username);
            this.param.Controls.Add(this.label6);
            this.param.Controls.Add(this.label5);
            this.param.Controls.Add(this.label4);
            this.param.Controls.Add(this.label3);
            this.param.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.param.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.param.Location = new System.Drawing.Point(322, 190);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(408, 317);
            this.param.TabIndex = 4;
            this.param.TabStop = false;
            this.param.Text = "Paramétrage: ";
            this.param.Visible = false;
            // 
            // validate
            // 
            this.validate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.validate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.validate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.validate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validate.ForeColor = System.Drawing.Color.White;
            this.validate.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.validate.IconColor = System.Drawing.Color.White;
            this.validate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.validate.IconSize = 30;
            this.validate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.validate.Location = new System.Drawing.Point(232, 266);
            this.validate.Name = "validate";
            this.validate.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.validate.Size = new System.Drawing.Size(98, 36);
            this.validate.TabIndex = 9;
            this.validate.Text = "Valider";
            this.validate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.validate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.validate.UseVisualStyleBackColor = false;
            this.validate.Click += new System.EventHandler(this.validate_Click);
            // 
            // importer
            // 
            this.importer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.importer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.importer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importer.ForeColor = System.Drawing.Color.White;
            this.importer.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.importer.IconColor = System.Drawing.Color.White;
            this.importer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.importer.IconSize = 25;
            this.importer.Location = new System.Drawing.Point(191, 215);
            this.importer.Name = "importer";
            this.importer.Size = new System.Drawing.Size(172, 33);
            this.importer.TabIndex = 6;
            this.importer.Text = "Importer";
            this.importer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.importer.UseVisualStyleBackColor = false;
            this.importer.Click += new System.EventHandler(this.importer_Click);
            // 
            // newPassword
            // 
            this.newPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.Location = new System.Drawing.Point(191, 161);
            this.newPassword.Name = "newPassword";
            this.newPassword.PasswordChar = '*';
            this.newPassword.Size = new System.Drawing.Size(172, 23);
            this.newPassword.TabIndex = 4;
            // 
            // currrentPass
            // 
            this.currrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currrentPass.Location = new System.Drawing.Point(191, 102);
            this.currrentPass.Name = "currrentPass";
            this.currrentPass.PasswordChar = '*';
            this.currrentPass.Size = new System.Drawing.Size(172, 23);
            this.currrentPass.TabIndex = 3;
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(191, 43);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(172, 23);
            this.username.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(27, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Changer l\'image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nouveau mot de passe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mot de passe actuel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nom d\'ulitisateur";
            // 
            // setting
            // 
            this.setting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.setting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(78)))), ((int)(((byte)(132)))));
            this.setting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setting.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.setting.IconColor = System.Drawing.Color.White;
            this.setting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.setting.Location = new System.Drawing.Point(760, 81);
            this.setting.Name = "setting";
            this.setting.Padding = new System.Windows.Forms.Padding(2, 5, 0, 0);
            this.setting.Size = new System.Drawing.Size(53, 56);
            this.setting.TabIndex = 3;
            this.setting.UseVisualStyleBackColor = false;
            this.setting.Click += new System.EventHandler(this.setting_Click);
            // 
            // hour
            // 
            this.hour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hour.AutoSize = true;
            this.hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(57)))), ((int)(((byte)(8)))));
            this.hour.Location = new System.Drawing.Point(237, 130);
            this.hour.Name = "hour";
            this.hour.Size = new System.Drawing.Size(57, 20);
            this.hour.TabIndex = 2;
            this.hour.Text = "label4";
            // 
            // date
            // 
            this.date.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(57)))), ((int)(((byte)(8)))));
            this.date.Location = new System.Drawing.Point(237, 50);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(57, 20);
            this.date.TabIndex = 1;
            this.date.Text = "label3";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(97, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Heur             :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(97, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date du jour :";
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application de gestion des étudiants";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu.ResumeLayout(false);
            this.subMenu.ResumeLayout(false);
            this.logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBtnIcon)).EndInit();
            this.desktop.ResumeLayout(false);
            this.desktop.PerformLayout();
            this.param.ResumeLayout(false);
            this.param.PerformLayout();
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
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label user;
        private FontAwesome.Sharp.IconPictureBox image;
        private System.Windows.Forms.Label hour;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton setting;
        private System.Windows.Forms.GroupBox param;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.TextBox currrentPass;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton importer;
        private FontAwesome.Sharp.IconButton validate;
    }
}

