﻿using GestionDesEtudiants.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace GestionDesEtudiants
{
    public partial class Login : Form
    {

        private  Socket socket;
        IPEndPoint localEndPoint;
        public Login()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                socket.Connect(localEndPoint);
            }
            catch (SocketException )
            {
                socket.Close();
                new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
            }
            eyeSlash.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void eye_Click_1(object sender, EventArgs e)
        {
            if (password.PasswordChar == '*')
            {
                eye.Visible = false;
                eyeSlash.Visible = true;
                password.PasswordChar = '\0';
            }
        }

        private void eyeSlash_Click_1(object sender, EventArgs e)
        {
            if (password.PasswordChar == '\0')
            {
                eye.Visible = true;
                eyeSlash.Visible = false;
                password.PasswordChar = '*';
            }
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            User user;
            try
            {
                user = new User(0, username.Text, password.Text);
                Request request = new Request(RequestType.CheckUser, user);
                byte[] buffer = SerializeDeserializeObject.Serialize(request);
                socket.Send(buffer);
                buffer = new byte[2048];
                int size = socket.Receive(buffer);
                Array.Resize(ref buffer, size);
                Dictionary<bool, int> answer = (Dictionary<bool, int>)SerializeDeserializeObject.Deserialize(buffer);

                if (answer.Keys.First())
                {   
                    new MainForm(answer.Values.First() ,username.Text, socket, this).Show();
                    Console.WriteLine(user.Id);
                    Hide();
                }
                else
                {
                    new MessageBx("Le mot de passe ou le nom d'utilisateur\nest incorrect", "Attention").Show();
                }
            }
            catch (SocketException )
            {
                new MessageBx("Nous avons rencontré un problème!\nRéessayer plus tard.", "Problème de serveur").Show();
                
            }


        }
    }
}
