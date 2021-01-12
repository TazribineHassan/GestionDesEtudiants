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
            dataGridView1.Rows.Clear();
/*            List<Etudiant> etudiants = connectivitie.avoirTousLesEtudiant();
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

        private void iconButton2_Click(object sender, EventArgs e)
        {

/*            if(connectivitie.AjouterEtudiant(new Etudiant(id, new Filiere(1, "GINFO"), textBox2.Text, textBox3.Text, textBox4.Text, radioButton1.Checked ? "feminin" : "masculin", textBox7.Text, dateTimePicker1.Value, textBox8.Text)) == 1)
            {
                Console.WriteLine("i'm in");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                dateTimePicker1.Value = DateTime.Now;
                textBox7.Text = "";
                textBox8.Text = "";
                id++;
                actualiserLeTableau();
            }*/
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
    }
}
