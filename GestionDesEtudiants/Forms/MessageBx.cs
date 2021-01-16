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
    public partial class MessageBx : Form
    {
        public MessageBx(string message, string title)
        {
            InitializeComponent();
            msg.Text = message;
            this.title.Text = title;
        }

        private void validate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
