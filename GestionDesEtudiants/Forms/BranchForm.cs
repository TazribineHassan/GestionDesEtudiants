using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using GestionDesEtudiants.Forms;

namespace GestionDesEtudiants
{
 
    public partial class BranchForm : Form
    {


        public BranchForm()
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
                List<Branch> filieres = (List<Branch>)SerializeDeserializeObject.Deserialize(buffer);
                foreach (Branch filiere in filieres)
                {
                    dataGridView1.Rows.Add(filiere.Id, filiere.Nom);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
            }


        }


        private void Branch_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Request request = new Request(RequestType.AddBranch, new Branch(0, BranchName.Text));
            byte[] buffer = SerializeDeserializeObject.Serialize(request);
            MainForm.socket.Send(buffer);
            buffer = new byte[1024];
            int size = MainForm.socket.Receive(buffer);
            Array.Resize(ref buffer, size);
            bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
            if (answer)
            {
                MessageBox.Show("La Filière a été ajouter", "succ");
            }
            else
            {
                MessageBox.Show("Probléme", "succ");
            }
            BranchName.Text = "";
            actualiserLeTableau();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    int id = Int32.Parse(dataGridView1.SelectedRows[i].Cells["Id_Filière"].Value.ToString());
                    Request request = new Request(RequestType.DeleteBranch, id);
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    MainForm.socket.Send(buffer);
                    buffer = new byte[1024];
                    int size = MainForm.socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                    if (!answer)
                    {
                        MessageBox.Show("Probléme", "succ");
                    }
                    actualiserLeTableau();
                }

                MessageBox.Show(lignes + " lignes ont ete supprime", "lignes supprime");

            }
        }

        private void BranchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    int id = Int32.Parse(dataGridView1.SelectedRows[i].Cells["Id_Filière"].Value.ToString());
                    string branchNameTable = dataGridView1.SelectedRows[i].Cells["Nom_Filière"].Value.ToString();
                    MessageUpdate msg = new MessageUpdate( );
                    msg.UpdateNamebranch.Text = branchNameTable;
                    //Console.WriteLine(msg.UpdateNamebranch.Text);
                    msg.ShowDialog();
                    Request request = new Request(RequestType.UpdateBranch, new Branch(id, msg.UpdateNamebranch.Text));
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    MainForm.socket.Send(buffer);
                    buffer = new byte[1024];
                    int size = MainForm.socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                    if (!answer)
                    {
                        MessageBox.Show("Probléme", "succ");
                    }
                }

                //MessageBox.Show(lignes + " lignes ont ete supprime", "lignes supprime");
                actualiserLeTableau();
            }
           
        }

    }
}
