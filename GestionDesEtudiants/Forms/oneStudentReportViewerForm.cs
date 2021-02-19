using ClassLibrary;
using GestionDesEtudiants.ReportAdapters;
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

namespace GestionDesEtudiants.Forms
{
    public partial class oneStudentReportViewerForm : Form
    {
        private Student student;
        public oneStudentReportViewerForm(Student student)
        {
            InitializeComponent();
            this.student = student;
            this.Text = student.Nom + " " + student.Prenom;
        }

        private void oneStudentReportForm_Load(object sender, EventArgs e)
        {
            if (!student.Equals(null))
                OneStudentReportAdapterBindingSource.DataSource = new OneStudentReportAdapter(student);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
