using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GestionDesEtudiants.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClassLibrary;
using System.Collections.Generic;

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

            MessageBoxYesNo messageBoxYesNo = new MessageBoxYesNo("Vous voulez Télécharger le Reporting ?", "Télécharger le Reporting");
            messageBoxYesNo.ShowDialog();
            if (messageBoxYesNo.Answer)
            {
                try
                {
                    Request request = new Request(RequestType.GetStudentByBranch, null);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[1024 * 1024];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    Dictionary<string, List<Student>> StudentsByBranch = (Dictionary<string, List<Student>>)SerializeDeserializeObject.Deserialize(buffer);

                    // Create the pdf
                    Document document = new Document();
                    PdfWriter.GetInstance(document, new FileStream(@"C:\Users\Matrouh\Desktop\Reporting.pdf", FileMode.Create));
                    document.Open();
                    // ENSAS Logo
                    iTextSharp.text.Image ensasLogo = iTextSharp.text.Image.GetInstance(@"D:\mini projets\GestionDesEtudiants\GestionDesEtudiants\Resources\logo.png");
                    ensasLogo.ScalePercent(50);
                    ensasLogo.SetAbsolutePosition(document.PageSize.Width - 120f, document.PageSize.Height - 100f);
                    document.Add(ensasLogo);
                    // UCA Logo
                    iTextSharp.text.Image ucaLogo = iTextSharp.text.Image.GetInstance(@"D:\mini projets\GestionDesEtudiants\GestionDesEtudiants\Resources\ucaLogo.jpg");
                    ucaLogo.ScalePercent(50);
                    ucaLogo.SetAbsolutePosition(15f, document.PageSize.Height - 100f);
                    document.Add(ucaLogo);
                    // Title 
                    Paragraph paragraph = new Paragraph("Ecole Nationale des Sciences Appliquées de safi");
                    paragraph.IndentationLeft = 130f;
                    document.Add(paragraph);

                    //New Lines  
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    // Set the data of all students by branch:
                    foreach (var item in StudentsByBranch)
                    {
                        PdfPTable table = new PdfPTable(5);
                        PdfPCell cell = new PdfPCell(new Phrase(item.Key));
                        cell.Colspan = 5;
                        cell.HorizontalAlignment = 1;
                        table.AddCell(cell);

                        // First Row :
                        table.AddCell("CNE");
                        table.AddCell("Nom et prénom");
                        table.AddCell("Date de naissance");
                        table.AddCell("Adresse");
                        table.AddCell("Téléphone");

                        // the rest of each table:
                        foreach (var student in item.Value)
                        {
                            table.AddCell(student.CNE);
                            table.AddCell(student.Nom.ToUpper() + " " + student.Prenom);
                            table.AddCell(student.DateNessance.ToShortDateString());
                            table.AddCell(student.Adresse);
                            table.AddCell(student.Telephone);
                        }

                        // add the table
                        document.Add(table);
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                    }
                    
                    document.Close();
                    new MessageBx("Le téléchargement est terminé", "Le téléchargement").Show();
                }
                catch (SocketException )
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }

        }
    }

}
