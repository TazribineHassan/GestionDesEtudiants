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
        private Socket socket;

        public BranchForm( Socket sock)
        {
            InitializeComponent();
            socket = sock;
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
                socket.Send(buffer);
                buffer = new byte[1024];
                int size = socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                dataGridView1.Rows.Clear();
                List<Branch> filieres = (List<Branch>)SerializeDeserializeObject.Deserialize(buffer);
                foreach (Branch filiere in filieres)
                {
                    dataGridView1.Rows.Add(filiere.Id, filiere.Nom);
                }
            }
            catch (SocketException )
            {
                new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
            }
            finally
            {
                
            }


        }


        private void Branch_Load(object sender, EventArgs e)
        {

        }

        private void addBranch_Click(object sender, EventArgs e)
        {
            if (BranchName.Text != "")
            {
                try
                {
                    Request request = new Request(RequestType.AddBranch, new Branch(0, BranchName.Text));
                    byte[] buffer = SerializeDeserializeObject.Serialize(request);
                    socket.Send(buffer);
                    buffer = new byte[1024];
                    int size = socket.Receive(buffer);
                    Array.Resize(ref buffer, size);
                    bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                    if (answer)
                    {
                        new MessageBx("L'ajout a réussi", "L'ajout").Show();
                        BranchName.Text = "";
                        actualiserLeTableau();
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
            else
            {
                new MessageBx("Veuillez remplir le champ", "Attention").Show();
                 
            }


        }

        private void deleteBranch_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                
                for (int i = 0; i < selectedRowCount; i++)
                {
                    int id = Int32.Parse(dataGridView1.SelectedRows[i].Cells["Id_Filière"].Value.ToString());
                    try
                    {
                        Request request = new Request(RequestType.DeleteBranch, id);
                        byte[] buffer = SerializeDeserializeObject.Serialize(request);
                        socket.Send(buffer);
                        buffer = new byte[1024];
                        int size = socket.Receive(buffer);
                        Array.Resize(ref buffer, size);
                        bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                        if (answer)
                        {
                            actualiserLeTableau();
                            new MessageBx("La suppression a réussi", "Suppression").Show();
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

        private void BranchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateBranch_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //int lignes = 0;
                for (int i = 0; i < selectedRowCount; i++)
                {
                    int id = Int32.Parse(dataGridView1.SelectedRows[i].Cells["Id_Filière"].Value.ToString());
                    string branchNameTable = dataGridView1.SelectedRows[i].Cells["Nom_Filière"].Value.ToString();
                    try
                    {
                        MessageUpdate msg = new MessageUpdate();
                        msg.UpdateNamebranch.Text = branchNameTable;
                        msg.ShowDialog();
                        Request request = new Request(RequestType.UpdateBranch, new Branch(id, msg.UpdateNamebranch.Text));
                        byte[] buffer = SerializeDeserializeObject.Serialize(request);
                        socket.Send(buffer);
                        buffer = new byte[1024];
                        int size = socket.Receive(buffer);
                        Array.Resize(ref buffer, size);
                        bool answer = (bool)SerializeDeserializeObject.Deserialize(buffer);
                        if (answer)
                        {
                            new MessageBx("La modification a réussi", "Modification").Show();
                            actualiserLeTableau();
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

    }
}
