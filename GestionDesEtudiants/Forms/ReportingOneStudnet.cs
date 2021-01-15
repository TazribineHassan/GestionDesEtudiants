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
        public ReportingOneStudnet()
        {
            InitializeComponent();
        }

        private void download_Click(object sender, EventArgs e)
        {
            try
            {
                //get the student by his cne from the server. 
                Request request = new Request(RequestType.GetOneStudnet, cneStudent.Text);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                MainForm.socket.Send(buffer);
                buffer = new byte[2048];
                int size = MainForm.socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                Student student = (Student)SerializeDeserializeObject.Deserialize(buffer);

                //create the pdf file
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(@"C:\Users\admin\Desktop\" + student.CNE + "_" + student.Nom + ".pdf", FileMode.Create));
                document.Open();
                // ENSAS Logo
                iTextSharp.text.Image ensasLogo = iTextSharp.text.Image.GetInstance(@"C:\Users\admin\source\repos\GestionDesEtudiants\GestionDesEtudiants\Resources\logo.png");
                ensasLogo.ScalePercent(50);
                ensasLogo.SetAbsolutePosition(document.PageSize.Width - 120f, document.PageSize.Height - 100f);
                document.Add(ensasLogo);
                // UCA Logo
                iTextSharp.text.Image ucaLogo = iTextSharp.text.Image.GetInstance(@"C:\Users\admin\source\repos\GestionDesEtudiants\GestionDesEtudiants\Resources\ucaLogo.jpg");
                ucaLogo.ScalePercent(50);
                ucaLogo.SetAbsolutePosition(15f, document.PageSize.Height - 100f);
                document.Add(ucaLogo);
                // Title 
                Paragraph paragraph = new Paragraph("Ecole Nationale des Sciences Appliquées de safi");
                paragraph.IndentationLeft = 130f;
                document.Add(paragraph);

                //New Lines  
                document.Add(new Paragraph("\n\n\n\n\n\n\n\n"));

                // added name of the student
                Paragraph title = new Paragraph("Information de L'Etudiant(e): " + student.Nom + " " + student.Prenom + "\n\n\n");
                title.IndentationLeft = 150f;
                document.Add(title);

                //  set cne of the setudent
                Phrase cne = new Phrase("CNE:            ");
                document.Add(cne);
                document.Add(new Phrase(student.CNE + "\n\n"));
                //  set branch name of the setudent
                Phrase branch = new Phrase("Nom filière:  ");
                document.Add(branch);
                document.Add(new Phrase(student.Branch.ToString() + "\n\n"));

                // set the other information:
                PdfPTable table = new PdfPTable(4);
                
                // First  row in the table
                table.AddCell("Date de Naissance");
                table.AddCell("Adresse");
                table.AddCell("Téléphone");
                table.AddCell("Sexe");

                // Second  row in the table
                table.AddCell(student.DateNessance.ToShortDateString());
                table.AddCell(student.Adresse);
                table.AddCell(student.Telephone);
                table.AddCell(student.Sex);
                document.Add(table);

                document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"));
                document.Add(new Paragraph("Date du jour: " + DateTime.Today.ToShortDateString() + 
                    "                                            " + "Signature"));
                document.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
