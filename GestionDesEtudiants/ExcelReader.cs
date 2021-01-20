using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace GestionDesEtudiants
{
    public class ExcelReader
    {
        public static List<string> errorMessages;
        private Socket socket;

        public ExcelReader(Socket sock)
        {
            socket = sock;
        }
        public  List<Student> ReadFromExcel(String filePath)
        {
            errorMessages = new List<string>();
            List<Student> students = new List<Student>();

            //getting all existed branches as a Dictionary of <name, id>
            Dictionary<string, int> branches = new Dictionary<string, int>();
            Request request = new Request(RequestType.GetAllBranches, null);
            byte[] buffer = SerializeDeserializeObject.Serialize(request);
            socket.Send(buffer);
            buffer = new byte[1024];
            int size = socket.Receive(buffer);
            Array.Resize(ref buffer, size);

            foreach(var item in (List<Branch>)SerializeDeserializeObject.Deserialize(buffer)){
                branches.Add(item.Nom, item.Id);
            }

            string con = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";" 
                       + @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                try
                {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            var columns = new {
                                CNE     = dr.GetOrdinal("CNE"),
                                nom     = dr.GetOrdinal("Nom"),
                                prenom  = dr.GetOrdinal("Prenom"),
                                sex     = dr.GetOrdinal("Sex"),
                                address = dr.GetOrdinal("Address"),
                                date_de_naissance = dr.GetOrdinal("date de naissance"),
                                telephone = dr.GetOrdinal("Telephone"),
                                nom_filiere = dr.GetOrdinal("Filiere")
                            };

                        //checking if the branch existed

                        


                            while (dr.Read())
                            {
                                string branchName = dr.GetString(columns.nom_filiere);
                            if (branches.ContainsKey(branchName))
                                students.Add(new Student(0, new Branch(branches[branchName], branchName), dr.GetString(columns.CNE), dr.GetString(columns.nom), dr.GetString(columns.prenom), dr.GetString(columns.sex), dr.GetString(columns.address), dr.GetDateTime(columns.date_de_naissance), dr.GetDouble(columns.telephone).ToString()));
                            else
                                errorMessages.Add("Impossible d'ajouter l'etudiant " + dr.GetString(columns.nom) + " " + dr.GetString(columns.prenom) //message
                                                            + "\nCause: filiere " + dr.GetString(columns.nom_filiere) + " n'existe pas");
                            }

                        }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    connection.Close();
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    connection.Close();
                    throw e;
                }
                finally
                {
                     connection.Close();
                }
            }
            return students;
        }
    }
}
