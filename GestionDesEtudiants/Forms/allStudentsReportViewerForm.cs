using ClassLibrary;
using GestionDesEtudiants.ReportAdapters;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
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

namespace GestionDesEtudiants.Forms
{
    public partial class allStudentsReportViewerForm : Form
    {
        Dictionary<string, List<OneStudentReportAdapter>> students;
        List<AllStudentsReportAdapter> branches;
        Socket socket;
        public allStudentsReportViewerForm(Socket socket)
        {
            this.socket = socket;

            branches = new List<AllStudentsReportAdapter>();
            Request request = new Request(RequestType.GetStudentByBranch, null);
            byte[] buffer = SerializeDeserializeObject.Serialize(request);
            socket.Send(buffer);
            buffer = new byte[1024 * 1024];
            int size = socket.Receive(buffer);
            Array.Resize(ref buffer, size);
            Dictionary<string, List<Student>> StudentsByBranch = (Dictionary<string, List<Student>>)SerializeDeserializeObject.Deserialize(buffer);


            students = new Dictionary<string, List<OneStudentReportAdapter>>();
            foreach (var item in StudentsByBranch)
            {
                List<OneStudentReportAdapter> studentAdapters = new List<OneStudentReportAdapter>();
                foreach (var student in item.Value)
                {
                    studentAdapters.Add(new OneStudentReportAdapter(student));
                }
                students.Add(item.Key, studentAdapters);
            }


            foreach (var item in students.Keys)
            {
                branches.Add(new AllStudentsReportAdapter(item, null));
            }
            InitializeComponent();
        }

        private void allStudentsReportViewerForm_Load(object sender, EventArgs e)
        {
            AllStudentsReportAdapterBindingSource.DataSource = branches;
            reportViewer1.LocalReport.SubreportProcessing += AllStudentsSubReportProcessing;
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }

        private void AllStudentsSubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string branchName = e.Parameters[0].Values[0];
            if(e.ReportPath == "AllStudentsSubReport")
            {
                e.DataSources.Add(new ReportDataSource() { Name = "StudentDetailsDataSet", Value = students[branchName] });
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
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
                catch (SocketException)
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }


            
        }


        private void MakePaddingAndColor(PdfPCell cell)
        {
            cell.MinimumHeight = 40;
            cell.Padding = 5;
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
    }
}
