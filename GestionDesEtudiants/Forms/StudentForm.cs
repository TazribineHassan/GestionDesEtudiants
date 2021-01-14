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

        private int idStudentUpdate;
        public StudentForm()
        {
            InitializeComponent();
            validate.Visible = false;
            
            getAllBranches();

            //désactiver l'édition du tableau
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        private void getAllBranches()
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
            refreshDataGrid();
        }

        private void deleteStudent_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                   // get the data

                    string cne = dataGridView1.SelectedRows[i].Cells["CNE"].Value.ToString();
                    Request request = new Request(RequestType.DeleteStudent, cne);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    MainForm.socket.Send(buffer);
                    buffer = new byte[1024];
                    int size =  MainForm.socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                    if (!answer)
                    {
                        MessageBox.Show("Probléme", "title");
                    }

                }
                refreshDataGrid();
                MessageBox.Show(lignes + " lignes ont ete supprime", "lignes supprime");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["nom"], ListSortDirection.Descending);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void resetAllAttributes()
        {
            branchStudent.Text = "";
            cneStudent.Text = "";
            studentName.Text = "";
            studenLastName.Text = "";
            male.Checked = false;
            female.Checked = false;
            address.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            phone.Text = "";
        }

        private void getStudentByCNE(object sender, EventArgs e)
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
                dataGridView1.Rows.Add(student.CNE, student.Nom, student.Prenom, student.Sex, student.DateNessance, student.Adresse, student.Telephone, student.Branch.Nom, student.Id);
                cneSearch.Text = "";
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void getAllStudents_Click(object sender, EventArgs e)
        {
            refreshDataGrid();
        }
        private void refreshDataGrid()
        {
            try
            {
                Request request = new Request(RequestType.GetAllStudnets, null);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                MainForm.socket.Send(buffer);
                buffer = new byte[1024 * 1024];
                int size = MainForm.socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                dataGridView1.Rows.Clear();
                List<Student> students = (List<Student>)SerializeDeserializeObject.Deserialize(buffer);
                foreach (var student in students)
                {
                    dataGridView1.Rows.Add(student.CNE, student.Nom, student.Prenom, student.Sex, student.DateNessance, student.Adresse, student.Telephone, student.Branch.Nom, student.Id);
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("Probléme", "Error");
            }
        }

        private void updateStudent_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    // Get the data from the datagrid view and sotre it in textboxes

                    idStudentUpdate = int.Parse(dataGridView1.SelectedRows[i].Cells["id_student"].Value.ToString());
                    cneStudent.Text = dataGridView1.SelectedRows[i].Cells["cne"].Value.ToString();
                    studentName.Text = dataGridView1.SelectedRows[i].Cells["nom"].Value.ToString();
                    studenLastName.Text = dataGridView1.SelectedRows[i].Cells["prenom"].Value.ToString();
                    if (dataGridView1.SelectedRows[i].Cells["sexe"].Value.ToString() == "M") male.Checked = true;
                    else female.Checked = true;
                    dateTimePicker1.Text = dataGridView1.SelectedRows[i].Cells["dateNnaissance"].Value.ToString();
                    address.Text = dataGridView1.SelectedRows[i].Cells["adresse"].Value.ToString();
                    phone.Text = dataGridView1.SelectedRows[i].Cells["Tele"].Value.ToString();
                    branchStudent.Text = dataGridView1.SelectedRows[i].Cells["filiere"].Value.ToString();
                    validate.Visible = true;
                    addStudent.Visible = false;


                }
                
            }
        }

        private void validate_Click(object sender, EventArgs e)
        {
            try
            {
                string sex = female.Text;
                if (male.Checked) sex = male.Text;
                Student updateStudent = new Student(idStudentUpdate, (Branch)branchStudent.SelectedItem, cneStudent.Text, studentName.Text, studenLastName.Text, sex, address.Text,dateTimePicker1.Value, phone.Text);
                Request request = new Request(RequestType.UpdateStudent, updateStudent);
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
            }
            catch (SocketException ex)
            {

                MessageBox.Show(ex.Message, "title");
            }

            resetAllAttributes();
            refreshDataGrid();
            addStudent.Visible = true;
            validate.Visible = false;
        }
    }
}
