using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace GestionDesEtudiants
{
    public class ExcelReader
    {
        public static List<Student> ReadFromExcel(String filePath)
        {
            List<Student> students = new List<Student>();

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

                            while (dr.Read())
                            {
                                students.Add(new Student(0, new Branch(2, dr.GetString(columns.nom_filiere)), dr.GetString(columns.CNE), dr.GetString(columns.nom), dr.GetString(columns.prenom), dr.GetString(columns.sex), dr.GetString(columns.address), dr.GetDateTime(columns.date_de_naissance), dr.GetDouble(columns.telephone).ToString()));
                            }

                        }
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
