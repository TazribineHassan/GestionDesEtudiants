﻿using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GestionDesEtudiants.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GestionDesEtudiants
{
    public partial class MainForm : Form
    {
        private IconButton btn;
        private Panel leftPanelBtn;
        private Form currentForm;
        public static Socket socket;
        IPEndPoint localEndPoint;


        public MainForm()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                socket.Connect(localEndPoint);
            }
            catch (SocketException ex)
            {
                socket.Close();
                Console.WriteLine("Unable to connect with the server try later (" + ex.Message + ")");
            }
            leftPanelBtn = new Panel();
            leftPanelBtn.Size = new Size(5, 60);
            menu.Controls.Add(leftPanelBtn);
            subMenu.Visible = false;
        }

        // Ta activate a button we use this method
        //(it adds a left border in the activate btn and also it moves the icon into the right side)
        private void activateBtn(object sender, Color color)
        {
            if(sender != null)
            {
                disableBtn();
                btn = sender as IconButton;
                btn.BackColor = Color.FromArgb(62, 101, 160);
                btn.ForeColor = color;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.IconColor = color;
                btn.TextImageRelation = TextImageRelation.TextBeforeImage;
                btn.ImageAlign = ContentAlignment.MiddleRight;
                leftPanelBtn.BackColor = color;
                leftPanelBtn.Location = new Point(0, btn.Location.Y);
                leftPanelBtn.Visible = true;
                leftPanelBtn.BringToFront();
                currentBtnIcon.IconChar = btn.IconChar;
                currentBtnIcon.IconColor = color;
                currentLblText.Text = btn.Text;
                currentLblText.ForeColor = color;
                if (btn.Name == "repo")
                {
                    subMenu.Visible = true;
                }
            }
        }

        private void disableBtn()
        {
            if(btn != null)
            {
                btn.BackColor = Color.FromArgb(43, 78, 132);
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.IconColor = Color.White;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                subMenu.Visible = false;
                
            }
        }

        private void openForm(Form form)
        {
            if(currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            desktop.Controls.Add(form);
            desktop.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void btnBranchClick(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(241, 109, 109));
            openForm(new BranchForm());
        }

        private void btnStudentClick(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(109, 233, 241));
            openForm(new StudentForm());
        }

        private void btnStaticsCilck(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(221, 109, 241));
            openForm(new Graphic());
        }

        private void btnReportClick(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(241, 109, 141));
            openForm(new Reporting());
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentForm.Close();
            Reset();
        }

        private void Reset()
        {
            disableBtn();
            leftPanelBtn.Visible = false;
            currentBtnIcon.IconChar = IconChar.Home;
            currentBtnIcon.IconColor = Color.White;
            currentLblText.Text = "Home";
            currentLblText.ForeColor = Color.White;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openForm(new ReportingOneStudnet());
        }

        private void download_Click(object sender, EventArgs e)
        {
            openForm(new Reporting());
            DialogResult dialogResult = MessageBox.Show("Vous voulez Télécharger le Reporting", "Télécharger le Reporting", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream("C:\\Users\\admin\\Desktop\\Reporting.pdf", FileMode.Create));
                document.Open();
                iTextSharp.text.Image ensasLogo = iTextSharp.text.Image.GetInstance("C:\\Users\\admin\\source\\repos\\GestionDesEtudiants\\GestionDesEtudiants\\Resources\\logo.png");
                //ensasLogo.ScalePercent(10f);
                ensasLogo.IndentationRight(20f);
                document.Add(ensasLogo);
                document.Add(new Paragraph("Hello worrld"));
                document.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }

}
