using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDesEtudiants.Forms
{
    public partial class ExcelViewer : Form
    {
        private List<Student> students;
        public ExcelViewer(List<Student> students)
        {
            InitializeComponent();
            this.students = students;
            foreach(var student in students)
            {
                dataGridView1.Rows.Add(student.CNE, student.Nom, student.Prenom, student.Sex, student.Adresse, student.DateNessance, student.Telephone, student.Branch.Nom);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

            foreach (var student in students)
            {
                Console.WriteLine("uploading " + student.Nom);
                Request request = new Request(RequestType.AddStudent, student);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                MainForm.socket.Send(buffer);
                buffer = new byte[1024];
                int size = MainForm.socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                if (!answer)
                {
                    MessageBox.Show("Probléme", "title");
                    break;
                }else
                    Console.WriteLine("student added!");
            }
            this.Dispose();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
