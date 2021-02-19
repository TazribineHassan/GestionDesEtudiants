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
    public partial class Reporting : Form
    {
        Socket socket;
        public Reporting(Socket socket)
        {
            this.socket = socket;
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            new allStudentsReportViewerForm(socket).Show();
        }
    }
}
