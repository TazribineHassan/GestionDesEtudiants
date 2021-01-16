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
    public partial class MessageBoxYesNo : Form
    {
        bool answer;
        public bool Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public MessageBoxYesNo(string msg, string title)
        {
            InitializeComponent();
            message.Text = msg;
            this.title.Text = title;
        }

        private void MessageBoxYesNo_Load(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Dispose();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            answer = true;
           this.Dispose();
        }
    }
}
