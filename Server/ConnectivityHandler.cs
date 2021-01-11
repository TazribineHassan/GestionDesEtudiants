using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Server
{
    class ConnectivityHandler
    {
        private SqlConnection con;
        public ConnectivityHandler()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source = DESKTOP-566A95N\\ENSASDB; Initial Catalog = StudentManagementDatabase; Integrated Security = true";
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            con.Close();
        }

        
        public int addStudent(Etudiant etudiant)
        {
            string requette = "INSERT INTO [STUDENT] ([IDETUDIANT] ,[IDFILIERE] ,[CNE] ,[NOM] ,[PRENOM]  ,[SEX]  ,[DATENAISSANCE]  ,[ADRESSE]  ,[TELEPHONE]) VALUES (@IDETUDIANT, @IDFILIERE, @CNE, @NOM, @PRENOM, @SEX, @DATENAISSANCE, @ADRESSE, @TELEPHONE)";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@IDETUDIANT", etudiant.id));
            command.Parameters.Add(new SqlParameter("@IDFILIERE", etudiant.filiere.id));
            command.Parameters.Add(new SqlParameter("@CNE", etudiant.CNE));
            command.Parameters.Add(new SqlParameter("@NOM", etudiant.nom));
            command.Parameters.Add(new SqlParameter("@PRENOM", etudiant.prenom));
            command.Parameters.Add(new SqlParameter("@SEX", etudiant.sex));
            command.Parameters.Add(new SqlParameter("@DATENAISSANCE", etudiant.dateNessance.ToString()));
            command.Parameters.Add(new SqlParameter("@ADRESSE", etudiant.adresse));
            command.Parameters.Add(new SqlParameter("@TELEPHONE", etudiant.telephone));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return nbRowsAffected;
        }

        public Etudiant getStudent(string CNE)
        {
            Etudiant result = null;
            string requette = "SELECT [IDETUDIANT], [FILIERE].[IDFILIERE], [NOMFILIERE], [CNE], [NOM], [PRENOM], [SEX], [DATENAISSANCE], [ADRESSE], [TELEPHONE] FROM [STUDENT], [FILIERE] WHERE [STUDENT].IDFILIERE = [FILIERE].IDFILIERE AND CONVERT(NVARCHAR(MAX), [CNE]) = @CNE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@CNE", CNE));
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new Etudiant(reader.GetInt32(0), new Filiere(reader.GetInt32(1), reader.GetString(2)), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(8), reader.GetDateTime(7), reader.GetString(9));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public List<Etudiant> getAllStudents()
        {
            List<Etudiant> result = new List<Etudiant>();
            string requette = "SELECT [IDETUDIANT] ,[FILIERE].[IDFILIERE] ,[NOMFILIERE] ,[CNE] ,[NOM] ,[PRENOM] ,[SEX] ,[DATENAISSANCE] ,[ADRESSE] ,[TELEPHONE] FROM [STUDENT] INNER JOIN [FILIERE] ON [STUDENT].IDFILIERE = [FILIERE].IDFILIERE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //                               [IDETUDIANT]               [IDFILIERE]           [NOMFILIERE]       [CNE]               [NOM]                  [PRENOM]            [SEX]                [ADRESSE]             [DATENAISSANCE]         [TELEPHONE]
                    result.Add(new Etudiant(reader.GetInt32(0), new Filiere(reader.GetInt32(1), reader.GetString(2)), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(8), reader.GetDateTime(7), reader.GetString(9)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public int updateStudent(string CNE, Dictionary<string, string> data)
        {

            string sqlQuery = "UPDATE [STUDENT] SET ";
            int counter = 1;
            foreach (var element in data)
            {
                if (counter == data.Count)
                {
                    sqlQuery += element.Key + " = " + element.Value;
                }
                else
                {
                    sqlQuery += element.Key + " = " + element.Value + ", ";
                }

                counter++;
            }

            sqlQuery += " WHERE CONVERT(NVARCHAR(MAX), [CNE]) = @CNE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = sqlQuery;
            command.Parameters.Add(new SqlParameter("@CNE", CNE));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return nbRowsAffected;
        }

        public Dictionary<string, List<Etudiant>> getStudentsByBranch()
        {
            Dictionary<string, List<Etudiant>> result = new Dictionary<string, List<Etudiant>>();

            string requette = "SELECT [IDETUDIANT] ,[FILIERE].[IDFILIERE] ,[NOMFILIERE] ,[CNE] ,[NOM] ,[PRENOM] ,[SEX] ,[DATENAISSANCE] ,[ADRESSE] ,[TELEPHONE] FROM [STUDENT] INNER JOIN [FILIERE] ON [STUDENT].IDFILIERE = [FILIERE].IDFILIERE";
            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string BranchName = reader.GetString(2);
                    if (!result.Keys.Contains(BranchName))
                        result.Add(BranchName, new List<Etudiant>());

                    //    [NOMFILIERE]                    [IDETUDIANT]                     [IDFILIERE]    [NOMFILIERE]          [CNE]               [NOM]                  [PRENOM]            [SEX]                [ADRESSE]         [DATENAISSANCE]         [TELEPHONE]
                    result[BranchName].Add(new Etudiant(reader.GetInt32(0), new Filiere(reader.GetInt32(1), BranchName), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(8), reader.GetDateTime(7), reader.GetString(9)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public int deleteStudent(string CNE)
        {
            string requette = "DELETE FROM [STUDENT] WHERE CONVERT(NVARCHAR(MAX), [CNE]) = @CNE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@CNE", CNE));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return nbRowsAffected;
        }

        public int addBranch(Filiere filiere)
        {
            string requette = "INSERT INTO [FILIERE] ([IDFILIERE] ,[NOMFILIERE]) VALUES (@IDFILIERE, @NOMFILIERE)";
            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@IDFILIERE", filiere.id));
            command.Parameters.Add(new SqlParameter("@NOMFILIERE", filiere.nom));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            return nbRowsAffected;
        }

        public List<Filiere> getAllBranchs()
        {
            List<Filiere> result = new List<Filiere>();
            string requette = "SELECT [IDFILIERE] ,[NOMFILIERE] FROM [FILIERE]";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Filiere(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public int updateBranch(Filiere filiere)
        {
            string sqlQuery = "UPDATE [FILIERE] SET  [NOMFILIERE] = @NOM WHERE [IDFILIERE] = @ID";
            SqlCommand command = con.CreateCommand();
            command.CommandText = sqlQuery;
            command.Parameters.Add(new SqlParameter("@ID", filiere.id));
            command.Parameters.Add(new SqlParameter("@NOM", filiere.nom));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return nbRowsAffected;
        }

        public int deleteBranch(int ID)
        {
            string requette = "DELETE FROM [FILIERE] WHERE [IDFILIERE] = @ID";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@ID", ID));

            int nbRowsAffected = 0;
            try
            {
                con.Open();
                nbRowsAffected = command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return nbRowsAffected;
        }

        public Dictionary<string, int> getStatistics()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            string sqlQuery = "SELECT CONVERT(NVARCHAR(MAX), [FILIERE].NOMFILIERE), COUNT([IDETUDIANT]) FROM [STUDENT] INNER JOIN [FILIERE] ON [STUDENT].IDFILIERE = [FILIERE].IDFILIERE GROUP BY CONVERT(NVARCHAR(MAX), [FILIERE].NOMFILIERE)";
            SqlCommand command = con.CreateCommand();
            command.CommandText = sqlQuery;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(0), reader.GetInt32(1));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }

    }

    class Etudiant
    {
        public int id { get; }
        public Filiere filiere { get; }
        public string CNE { get; }
        public string nom { get; }
        public string prenom { get; }
        public string sex { get; }
        public string adresse { get; }
        public DateTime dateNessance { get; }
        public string telephone { get; }

        public Etudiant(int id, Filiere filiere, string CNE, string nom, string prenom, string sex, string adresse, DateTime dateNessance, string telephone)
        {
            this.id = id;
            this.filiere = filiere;
            this.CNE = CNE;
            this.nom = nom;
            this.prenom = prenom;
            this.sex = sex;
            this.adresse = adresse;
            this.dateNessance = dateNessance;
            this.telephone = telephone;
        }
    }

    class Filiere
    {
        public int id { get; }
        public string nom { get; }

        public Filiere(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}

