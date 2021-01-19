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
        private Socket socket;
        public StudentForm(Socket sock)
        {
            InitializeComponent();
            socket = sock;
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
                socket.Send(buffer);
                buffer = new byte[1024];
                int size = socket.Receive(buffer);
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
                new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show(); Console.WriteLine(ex.Message);
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
            if (!checkEmptyAttributes())
            {
                Request request = new Request(RequestType.AddStudent, new Student(0, (Branch)branchStudent.SelectedItem, cneStudent.Text, studentName.Text, studenLastName.Text, sex, address.Text, dateTimePicker1.Value, phone.Text));
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                socket.Send(buffer);
                buffer = new byte[1024];
                int size = socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                if (answer)
                {
                    new MessageBx("L'ajout a réussi", "L'ajout").Show();
                }
                else
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
                resetAllAttributes();
                refreshDataGrid();
            }
            else
            {
                new MessageBx("Veuillez remplir tous les champs", "Attention").Show();
            } 

        }

        private void deleteStudent_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    // get the data
                    try
                    {
                        string cne = dataGridView1.SelectedRows[i].Cells["CNE"].Value.ToString();
                        Request request = new Request(RequestType.DeleteStudent, cne);
                        byte[] buffer = SerializeDeserializeObject.Serialize(request);
                        socket.Send(buffer);
                        buffer = new byte[1024];
                        int size = socket.Receive(buffer);
                        Array.Resize(ref buffer, size);
                        bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                        if (answer)
                        {
                            new MessageBx("La suppression a réussi", "Suppression").Show();
                            refreshDataGrid();
                        }
                        else
                        {
                            new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                        }
                    }
                    catch (Exception)
                    {
                        new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                    }

                }
                
            }
            else
            {
                new MessageBx("Veuillez sélectionner une ligne", "Attention").Show();
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
            if(cneSearch.Text != "")
            {
                try
                {
                    Request request = new Request(RequestType.GetOneStudnet, cneSearch.Text);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[1024 * 1024];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    Dictionary<bool, Student> answer = SerializeDeserializeObject.Deserialize(buffer) as Dictionary<bool, Student>;

                    foreach (var item in answer)
                    {
                        if (item.Key)
                        {
                            dataGridView1.Rows.Clear();
                            dataGridView1.Rows.Add(item.Value.CNE, item.Value.Nom, item.Value.Prenom, item.Value.Sex, item.Value.DateNessance, item.Value.Adresse, item.Value.Telephone, item.Value.Branch.Nom, item.Value.Id);
                            cneSearch.Text = "";
                        }
                        else
                        {
                            new MessageBx("Veuillez vérifier le CNE", "Attention").Show();
                        }
                    }

                }
                catch (SocketException )
                {
                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }
            }
            else
            {
                new MessageBx("Veuillez remplir le champ", "Attention").Show();
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
                socket.Send(buffer);
                buffer = new byte[1024 * 1024];
                int size = socket.Receive(buffer);
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
                new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
            }
        }

        private void updateStudent_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    // Get the data from the datagrid view and sotre it in to textboxes

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
            else
            {
                new MessageBx("Veuillez sélectionner une ligne", "Attention").Show();
            }
        }

        private void validate_Click(object sender, EventArgs e)
        {
            if (!checkEmptyAttributes())
            {
                try
                {
                    string sex = female.Text;
                    if (male.Checked) sex = male.Text;
                    Student updateStudent = new Student(idStudentUpdate, (Branch)branchStudent.SelectedItem, cneStudent.Text, studentName.Text, studenLastName.Text, sex, address.Text, dateTimePicker1.Value, phone.Text);
                    Request request = new Request(RequestType.UpdateStudent, updateStudent);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[1024];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                    if (answer)
                    {
                        new MessageBx("La modification a réussi", "Modification").Show();
                        refreshDataGrid();
                    }
                    else
                    {
                        new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                    }
                }
                catch (SocketException )
                {

                    new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                }

                resetAllAttributes();
                addStudent.Visible = true;
                validate.Visible = false;
            }
            else
            {
                new MessageBx("Veuillez remplir tous les champs", "Attention").Show();
            }

        }

        private bool checkEmptyAttributes()
        {
            if (branchStudent.Text == "" || cneStudent.Text == "" || studentName.Text == ""
                || studenLastName.Text == "" || address.Text == "" || phone.Text == "" || !checkredioBox()) return true;
            else return false;
                           
        }

        private bool checkredioBox()
        {
            if (male.Checked == false && female.Checked == true) return true;
            else if (male.Checked == true && female.Checked == false) return true;
            else return false;
        }
    }
}
