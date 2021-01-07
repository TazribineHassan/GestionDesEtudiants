using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDesEtudiants
{
   
    public partial class Branch : Form
    {
        int id = 4;
        Connectivitie connectivitie;
        public Branch()
        {
            InitializeComponent();
            connectivitie = new Connectivitie();
            actualiserLeTableau();

            //désactiver l'édition du tableau
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        private void actualiserLeTableau()
        {
            dataGridView1.Rows.Clear();
            List<Filiere> filieres = connectivitie.avoirTousLesFiliere();
            foreach (Filiere filiere in filieres)
            {
                dataGridView1.Rows.Add(filiere.id, filiere.nom);
            }
        }


        private void Branch_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            connectivitie.AjouterFiliere(new Filiere(id, BranchName.Text));
            BranchName.Text = "";
            id++;
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
                    lignes += connectivitie.supprimerUneFiliere(id);
                    actualiserLeTableau();
                }

                MessageBox.Show(lignes + " lignes ont ete supprime", "lignes supprime");

            }
        }
    }
}
