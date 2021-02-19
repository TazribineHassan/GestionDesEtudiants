using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GestionDesEtudiants.Forms
{
    public partial class ReportingOneStudnet : Form
    {
        private Socket socket;
        public ReportingOneStudnet(Socket sock)
        {
            InitializeComponent();
            socket = sock;
        }

        private void download_Click(object sender, EventArgs e)
        {
            if(cneStudent.Text != "")
            {

                try
                {
                    //get the student by his cne from the server. 
                    Request request = new Request(RequestType.GetOneStudnet, cneStudent.Text);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[2048];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    Dictionary<bool, Student> answer = SerializeDeserializeObject.Deserialize(buffer) as Dictionary<bool, Student>;
                    /*                    FolderBrowserDialog folder = new FolderBrowserDialog();
                                        if (folder.ShowDialog() == DialogResult.OK)
                                        {*/
                    if (answer.Keys.First())
                    {
                        // Get the folder path
                        string path = string.Empty;
                        FolderBrowserDialog folder = new FolderBrowserDialog();
                        if (folder.ShowDialog() == DialogResult.OK)
                        {

                            path = folder.SelectedPath;

                            Document document = new Document();
                            PdfWriter.GetInstance(document, new FileStream(path + "\\" + answer.Values.First().CNE + ".pdf", FileMode.Create));
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
                            document.Add(new Paragraph("\n\n\n\n\n\n\n\n"));

                            // added name of the student
                            Paragraph title = new Paragraph(new Phrase("Information de L'Etudiant(e): " + answer.Values.First().Nom + " " + answer.Values.First().Prenom, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14f, iTextSharp.text.Font.BOLDITALIC, iTextSharp.text.BaseColor.BLACK)));
                            title.IndentationLeft = 80f;
                            document.Add(title);

                            //New Lines  
                            document.Add(new Paragraph("\n\n\n\n\n"));

                            //  set cne of the setudent
                            Phrase cne = new Phrase("CNE:          ", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                            document.Add(cne);
                            document.Add(new Phrase(answer.Values.First().CNE + "\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 13f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));
                            //  set branch name of the setudent
                            Phrase branch = new Phrase("Nom filière:  ", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                            document.Add(branch);
                            document.Add(new Phrase(answer.Values.First().Branch.ToString() + "\n\n\n\n\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 13f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE)));

                            // set the other information:
                            PdfPTable table = new PdfPTable(4);
                            table.TotalWidth = 520f;
                            table.LockedWidth = true;
                            float[] widths = new float[] { 150f, 150f, 110f, 110f };
                            table.SetWidths(widths);

                            // First  row in the table
                            // First Row :
                            PdfPCell cell1 = new PdfPCell(new Phrase("Date de Naissance", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)));
                            MakePaddingAndColor(cell1);
                            table.AddCell(cell1);
                            PdfPCell cell2 = new PdfPCell(new Phrase("Adresse", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)));
                            MakePaddingAndColor(cell2);
                            table.AddCell(cell2);
                            PdfPCell cell3 = new PdfPCell(new Phrase("Téléphone", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)));
                            MakePaddingAndColor(cell3);
                            table.AddCell(cell3);
                            PdfPCell cell4 = new PdfPCell(new Phrase("Sexe", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE)));
                            MakePaddingAndColor(cell4);
                            table.AddCell(cell4);


                            // Second  row in the table

                            table.AddCell(MakePadding(new PdfPCell(new Phrase(answer.Values.First().DateNessance.ToShortDateString()))));
                            table.AddCell(MakePadding(new PdfPCell(new Phrase(answer.Values.First().Adresse))));
                            table.AddCell(MakePadding(new PdfPCell(new Phrase(answer.Values.First().Telephone))));
                            table.AddCell(MakePadding(new PdfPCell(new Phrase(answer.Values.First().Sex))));
                            document.Add(table);

                            document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n"));
                            document.Add(new Paragraph("Date du jour: " + DateTime.Today.ToShortDateString() +
                                "                                                                                 " + "Signature"));
                            document.Close();

                            new MessageBx("Le téléchargement est terminé", "Le téléchargement").Show();
                            cneStudent.Text = "";
                        }
                    }
                    else 
                    {
                        new MessageBx("Veuillez vérifier le CNE", "Attention").Show();
                    }
                }
                catch (SocketException)
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }
            else
            {
                new MessageBx("Veuillez remplir le champs", "Attention").Show();
            }
        }

        private void MakePaddingAndColor(PdfPCell cell)
        {
            cell.BackgroundColor = new BaseColor(43, 78, 132);
            cell.MinimumHeight = 40;
            cell.Padding = 10;
            cell.HorizontalAlignment = 1;

        }
        private PdfPCell MakePadding(PdfPCell cell)
        {
            
            cell.MinimumHeight = 40;
            cell.VerticalAlignment = 1;
            cell.PaddingLeft = 5;
            cell.PaddingTop = 10;
            return cell;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (cneStudent.Text != "")
            {

                try
                {
                    //get the student by his cne from the server. 
                    Request request = new Request(RequestType.GetOneStudnet, cneStudent.Text);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[2048];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    Dictionary<bool, Student> answer = SerializeDeserializeObject.Deserialize(buffer) as Dictionary<bool, Student>;
                    /*                    FolderBrowserDialog folder = new FolderBrowserDialog();
                                        if (folder.ShowDialog() == DialogResult.OK)
                                        {*/
                    if (answer.Keys.First())
                    {

                        new oneStudentReportViewerForm(answer.Values.First()).Show();
                        cneStudent.Text = "";
                    }
                    else
                    {
                        new MessageBx("Veuillez vérifier le CNE", "Attention").Show();
                    }
                }
                catch (SocketException)
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }
            else
            {
                new MessageBx("Veuillez remplir le champs", "Attention").Show();
            }
        }

        private void ReportingOneStudnet_Load(object sender, EventArgs e)
        {

        }
    }
}
