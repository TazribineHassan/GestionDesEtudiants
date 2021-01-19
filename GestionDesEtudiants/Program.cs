using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionDesEtudiants
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            /*try
            {
                var stus = ExcelReader.ReadFromExcel("D:/temp/test.xls");
                Console.WriteLine("|CNE\t\t|"
                                  + "Nom\t|"
                                  + "Prenom\t|"
                                  + "Sex\t\t|"
                                  + "Adress\t\t\t|"
                                  + "date de naissance\t|"
                                  + "Telephone\t|"
                                  + "Filiere"
                                  );
                foreach (var stu in stus)
                {
                    Console.WriteLine("|" + stu.CNE
                                      + "\t|" + stu.Nom
                                      + "\t|" + stu.Prenom
                                      + "\t|" + stu.Sex
                                      + "\t|" + stu.Adresse
                                      + "\t|" + stu.DateNessance
                                      + "\t|" + stu.Telephone
                                      + "\t|" + stu.Branch.Nom
                                      );
                }
            }catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message + " " + e.StackTrace);
            }
            Console.Read();*/
        }
    }

}
