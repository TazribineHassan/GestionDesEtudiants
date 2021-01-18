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
        public bool answer { get; set; }
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
            answer = true;
            this.Dispose();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Dispose();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Dispose();
        }
    }
}
