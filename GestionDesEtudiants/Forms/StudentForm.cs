using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;


namespace GestionDesEtudiants.Forms
{
    public partial class StudentForm : Form
    {

        private int id = 15;
        public StudentForm()
        {
            InitializeComponent();

            actualiserLeTableau();

            //désactiver l'édition du tableau
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        private void actualiserLeTableau()
        {
            try
            {
                Request request = new Request(RequestType.GetAllBranches, null);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                MainForm.socket.Send(buffer);
                buffer = new byte[1024];
                int size = MainForm.socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                dataGridView1.Rows.Clear();
                List<Branch> branches = (List<Branch>)SerializeDeserializeObject.Deserialize(buffer);
                foreach (Branch branch in branches)
                {
                    branchStudent.Items.Add(branch);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
/*            dataGridView1.Rows.Clear();
            List<Etudiant> etudiants = connectivitie.avoirTousLesEtudiant();
            foreach (Etudiant etudiant in etudiants)
            {
                dataGridView1.Rows.Add(etudiant.CNE, etudiant.nom, etudiant.prenom, etudiant.sex, etudiant.dateNessance, etudiant.adresse, etudiant.telephone, etudiant.filiere.nom);
            }*/
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addStudent_Click(object sender, EventArgs e)
        {
            string sex = female.Text;
            if (male.Checked) sex = male.Text;
            Request request = new Request(RequestType.AddStudent, new Student(0, (Branch)branchStudent.SelectedItem, cneStudent.Text, studentName.Text, studenLastName.Text, sex, address.Text, dateTimePicker1.Value, phone.Text));
            byte[] buffer = SerializeDeserializeObject.Serialize(request);
            MainForm.socket.Send(buffer);
            buffer = new byte[1024];
            int size = MainForm.socket.Receive(buffer);
            Array.Resize(ref buffer, size);
            bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
            if (!answer)
            {
                MessageBox.Show("Probléme", "title");
            }
            resetAllAttributes();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
/*            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string cne = dataGridView1.SelectedRows[i].Cells["CNE"].Value.ToString();
                     lignes += connectivitie.supprimerUnEtudiant(cne);
                    actualiserLeTableau();
                }

                MessageBox.Show(lignes + " lignes ont ete supprime", "lignes supprime");

            }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void resetAllAttributes()
        {
            branchStudent.SelectedItem = "";
            cneStudent.Text = "";
            studentName.Text = "";
            studenLastName.Text = "";
            male.Checked = false;
            female.Checked = false;
            address.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            phone.Text = "";
        }

        private void grabStudentByCNE(object sender, EventArgs e)
        {
            try
            {
                Request request = new Request(RequestType.GetOneStudnet, cneSearch.Text);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                MainForm.socket.Send(buffer);
                buffer = new byte[1024];
                int size = MainForm.socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                Student student = SerializeDeserializeObject.Deserialize(buffer) as Student;
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(student.CNE, student.Nom, student.Prenom, student.Sex, student.DateNessance, student.Adresse, student.Telephone, student.Branch.Nom);

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
