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
using GestionDesEtudiants.ReportAdapters;

namespace GestionDesEtudiants
{
    public partial class MainForm : Form
    {
        private IconButton btn;
        private Panel leftPanelBtn;
        private Form currentForm , loginForm;
        private  Socket socket;
        private int idUser;
        Timer t = new Timer();

        public MainForm(int id,string userName, Socket sock, Form form)
        {
            InitializeComponent();
            user.Text = userName;
            socket = sock;
            loginForm = form;
            idUser = id;
            leftPanelBtn = new Panel();
            leftPanelBtn.Size = new Size(5, 60);
            menu.Controls.Add(leftPanelBtn);
            subMenu.Visible = false;
            date.Text = DateTime.Now.ToShortDateString();
            hour.Text = DateTime.Now.Hour + " : " + DateTime.Now.Minute + " : " + DateTime.Now.Millisecond;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //timer interval
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method
        }


        //timer eventhandler
        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            hour.Text = time;
        }
        // To activate a button we use this method
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
            openForm(new BranchForm(socket));
        }

        private void btnStudentClick(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(109, 233, 241));
            openForm(new StudentForm(socket));
        }

        private void btnStaticsCilck(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(221, 109, 241));
            openForm(new Graphic(socket));
        }

        private void btnReportClick(object sender, EventArgs e)
        {
            activateBtn(sender, Color.FromArgb(241, 109, 141));
            openForm(new Reporting(socket));
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
            openForm(new ReportingOneStudnet(socket));
        }

        private void download_Click(object sender, EventArgs e)
        {
            openForm(new allStudentsReportViewerForm(socket));

/*
            openForm(new Reporting(socket));

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

                    //select the path of the folder where we will store the pdf file
                    FolderBrowserDialog folder = new FolderBrowserDialog();
                    if (folder.ShowDialog() == DialogResult.OK)
                    {
                        // Create the pdf
                        Document document = new Document();
                        PdfWriter.GetInstance(document, new FileStream(folder.SelectedPath + "\\Reporting.pdf", FileMode.Create));
                        document.Open();
                        // ENSAS Logo
                        iTextSharp.text.Image ensasLogo = iTextSharp.text.Image.GetInstance(@".\Resources\logo.png");
                        ensasLogo.ScalePercent(50);
                        ensasLogo.SetAbsolutePosition(document.PageSize.Width - 120f, document.PageSize.Height - 100f);
                        document.Add(ensasLogo);
                        // UCA Logo
                        iTextSharp.text.Image ucaLogo = iTextSharp.text.Image.GetInstance(@".\Resources\ucaLogo.jpg");
                        ucaLogo.ScalePercent(50);
                        ucaLogo.SetAbsolutePosition(15f, document.PageSize.Height - 100f);
                        document.Add(ucaLogo);

                        // Title 
                        Paragraph paragraph = new Paragraph(new Phrase("Ecole Nationale des Sciences Appliquées de", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 13f, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLUE)));
                        paragraph.IndentationLeft = 95f;
                        document.Add(paragraph);
                        Paragraph paragraph_2 = new Paragraph(new Phrase("SAFI", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 13f, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLUE)));
                        paragraph_2.IndentationLeft = 250f;
                        document.Add(paragraph_2);

                        //New Lines  
                        document.Add(new Paragraph("\n\n\n\n\n"));
                        // Set the data of all students by branch:
                        foreach (var item in StudentsByBranch)
                        {
                            // Create a table
                            PdfPTable table = new PdfPTable(5);
                            table.TotalWidth = 545f;
                            table.LockedWidth = true;
                            float[] widths = new float[] { 90f, 115f, 140f, 110f, 90f };
                            table.SetWidths(widths);
                            PdfPCell cell = new PdfPCell(new Phrase(item.Key, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(43, 78, 132);

                            // Added some padding into the headercell
                            cell.PaddingTop = 10;
                            cell.PaddingBottom = 10;
                            cell.Colspan = 5;
                            cell.HorizontalAlignment = 1;
                            table.AddCell(cell);

                            // First Row :
                            PdfPCell cell1 = new PdfPCell(new Phrase("CNE", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                            MakePaddingAndColor(cell1);
                            table.AddCell(cell1);
                            PdfPCell cell2 = new PdfPCell(new Phrase("Nom et prénom", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                            MakePaddingAndColor(cell2);
                            table.AddCell(cell2);
                            PdfPCell cell3 = new PdfPCell(new Phrase("Date de naissance", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                            MakePaddingAndColor(cell3);
                            table.AddCell(cell3);
                            PdfPCell cell4 = new PdfPCell(new Phrase("Adresse", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                            MakePaddingAndColor(cell4);
                            table.AddCell(cell4);
                            PdfPCell cell5 = new PdfPCell(new Phrase("Téléphone", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)));
                            MakePaddingAndColor(cell5);
                            table.AddCell(cell5);


                            // the rest of each table:
                            foreach (var student in item.Value)
                            {
                                table.AddCell(MakePadding(new PdfPCell(new Phrase(student.CNE))));
                                table.AddCell(MakePadding(new PdfPCell(new Phrase(student.Nom.ToUpper() + " " + student.Prenom))));
                                table.AddCell(MakePadding(new PdfPCell(new Phrase(student.DateNessance.ToShortDateString()))));
                                table.AddCell(MakePadding(new PdfPCell(new Phrase(student.Adresse))));
                                table.AddCell(MakePadding(new PdfPCell(new Phrase(student.Telephone))));
                            }

                            // add the table
                            document.Add(table);
                            document.Add(new Paragraph("\n\n"));
                        }

                        document.Close();
                        new MessageBx("Le téléchargement est terminé", "Le téléchargement").Show();
                    }
                        


                }
                catch (SocketException )
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }*/

        }
        private void MakePaddingAndColor(PdfPCell cell)
        {
            cell.MinimumHeight = 40;
            cell.Padding = 5;
            cell.HorizontalAlignment = 1;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxYesNo messageBox = new MessageBoxYesNo("Vous voullez quitter l'application ?", "Quitter l'application");
            messageBox.ShowDialog();
            if (messageBox.Answer)
            { 
                loginForm.Close();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void setting_Click(object sender, EventArgs e)
        {
            if(param.Visible && currrentPass.Text == "" && newPassword.Text == "") param.Visible = false;
            else
            {
                param.Visible = true;
                username.Text = user.Text;
            }

        }

        private void validate_Click(object sender, EventArgs e)
        {
            if (currrentPass.Text == "" || newPassword.Text == "")
            {
                new MessageBx("Veuillez remplir tous les champs", "Attention").Show();
            }
            else
            {
                Request request = new Request(RequestType.UpdateUser, new User(idUser ,username.Text, newPassword.Text));
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                socket.Send(buffer);
                buffer = new byte[1024];
                int size = socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                Console.WriteLine(idUser + "");
                Console.WriteLine(answer);
                if (answer)
                {
                    new MessageBx("La modification a réussi", "Modification").Show();
                    user.Text = username.Text;
                }
                else new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();

                param.Visible = false;
            }
            
        }

        private void importer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Sélectionner une image(*.jpg;*.png) | *.jpg;*.png";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.SizeMode = PictureBoxSizeMode.Zoom;
                System.Drawing.Image photo = System.Drawing.Image.FromFile(openFileDialog.FileName);
                photo.Save(@".\Resources\user.png");
                image.Image = System.Drawing.Image.FromFile(@".\Resources\user.png");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();            
        }

        private PdfPCell MakePadding(PdfPCell cell)
        {

            cell.MinimumHeight = 40;
            cell.VerticalAlignment = 1;
            cell.PaddingLeft = 5;
            cell.PaddingTop = 10;
            return cell;
        }
    }

}
