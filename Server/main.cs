using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class main
    {
        static void Main(string[] args)
        {
            //just testing
            ConnectivityHandler conn = new ConnectivityHandler();
            foreach (var element in conn.getStudentsByBranch())
            {
                Console.WriteLine("========================= " + element.Key + " =========================");
                foreach (var etu in element.Value)
                {
                    Console.WriteLine("full name = " + etu.nom + " " + etu.prenom + "\t\t\tCNE = " + etu.CNE);
                }
            }
            Console.Read();
        }
        
    }
}
