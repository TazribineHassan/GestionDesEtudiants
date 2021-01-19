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
using System.Windows.Forms.DataVisualization.Charting;
using ClassLibrary;

namespace GestionDesEtudiants.Forms
{
    public partial class Graphic : Form
    {
        private Socket socket;
        public Graphic(Socket sock)
        {
            InitializeComponent();
            socket = sock;
            Request request = new Request(RequestType.GetStatics, null);
            byte[] buffer = SerializeDeserializeObject.Serialize(request);
            socket.Send(buffer);
            buffer = new byte[1024 * 1024];
            int size = socket.Receive(buffer);
            Array.Resize(ref buffer, size);
            int total = 0;
            Dictionary<string, int> answer = (Dictionary<string, int>)SerializeDeserializeObject.Deserialize(buffer);
            foreach (var item in answer)
            {
                total += item.Value;
            }
            int position = 0;
            foreach (var item in answer)
            {
                
                string percentage = Math.Round(((double)(item.Value * 100) / total), 2)  + "%";
                setGraph(item.Value, item.Key, percentage, position);
                position += 1;
                //Console.WriteLine(percentage + "  " + position);
            }
        }

        private void setGraph(int yValue, string axisLable, string label, int position)
        {
            chart1.Series["Nombre Etudiant"].Points.Add(yValue);
            chart1.Series["Nombre Etudiant"].Points[position].AxisLabel = axisLable;
            chart1.Series["Nombre Etudiant"].Points[position].Label = label;
        }
    }
}
