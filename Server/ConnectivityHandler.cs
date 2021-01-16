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

        
        public int addStudent(Student student)
        {
            string requette = "INSERT INTO [STUDENT] ([IDFILIERE] ,[CNE] ,[NOM] ,[PRENOM]  ,[SEX]  ,[DATENAISSANCE]  ,[ADRESSE]  ,[TELEPHONE]) VALUES (@IDFILIERE, @CNE, @NOM, @PRENOM, @SEX, @DATENAISSANCE, @ADRESSE, @TELEPHONE)";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            //command.Parameters.Add(new SqlParameter("@IDETUDIANT", student.Id));
            command.Parameters.Add(new SqlParameter("@IDFILIERE", student.Branch.Id));
            command.Parameters.Add(new SqlParameter("@CNE", student.CNE));
            command.Parameters.Add(new SqlParameter("@NOM", student.Nom));
            command.Parameters.Add(new SqlParameter("@PRENOM", student.Prenom));
            command.Parameters.Add(new SqlParameter("@SEX", student.Sex));
            command.Parameters.Add(new SqlParameter("@DATENAISSANCE", student.DateNessance));
            command.Parameters.Add(new SqlParameter("@ADRESSE", student.Adresse));
            command.Parameters.Add(new SqlParameter("@TELEPHONE", student.Telephone));

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

        public Student getStudent(string CNE)
        {
            Student result = null;
            string requette = "SELECT [IDETUDIANT], [FILIERE].[IDFILIERE], [NOMFILIERE], [CNE], [NOM], [PRENOM], [SEX], [DATENAISSANCE], [ADRESSE], [TELEPHONE] FROM [STUDENT], [FILIERE] WHERE [STUDENT].IDFILIERE = [FILIERE].IDFILIERE AND CONVERT(NVARCHAR(MAX), [CNE]) = @CNE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            command.Parameters.Add(new SqlParameter("@CNE", CNE));
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                var columns = new {
                    studentId = reader.GetOrdinal("IDETUDIANT"),
                    idFiliere = reader.GetOrdinal("IDFILIERE"),
                    nomFiliere = reader.GetOrdinal("NOMFILIERE"),
                    CNE = reader.GetOrdinal("CNE"),
                    nom = reader.GetOrdinal("NOM"),
                    prenom = reader.GetOrdinal("PRENOM"),
                    sex = reader.GetOrdinal("SEX"),
                    dateDeNaissance = reader.GetOrdinal("DATENAISSANCE"),
                    adresse = reader.GetOrdinal("ADRESSE"),
                    telephone = reader.GetOrdinal("TELEPHONE")
                };

                if (reader.Read())
                {
                    result = new Student(reader.GetInt32(columns.studentId), new Branch(reader.GetInt32(columns.idFiliere), reader.GetString(columns.nomFiliere)), reader.GetString(columns.CNE), reader.GetString(columns.nom), reader.GetString(columns.prenom), reader.GetString(columns.sex), reader.GetString(columns.adresse), reader.GetDateTime(columns.dateDeNaissance), reader.GetString(columns.telephone));
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
        public List<Student> getAllStudents()
        {
            List<Student> result = new List<Student>();
            string requette = "SELECT [IDETUDIANT] ,[FILIERE].[IDFILIERE] ,[NOMFILIERE] ,[CNE] ,[NOM] ,[PRENOM] ,[SEX] ,[DATENAISSANCE] ,[ADRESSE] ,[TELEPHONE] FROM [STUDENT] INNER JOIN [FILIERE] ON [STUDENT].IDFILIERE = [FILIERE].IDFILIERE";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                var columns = new
                {
                    studentId = reader.GetOrdinal("IDETUDIANT"),
                    idFiliere = reader.GetOrdinal("IDFILIERE"),
                    nomFiliere = reader.GetOrdinal("NOMFILIERE"),
                    CNE = reader.GetOrdinal("CNE"),
                    nom = reader.GetOrdinal("NOM"),
                    prenom = reader.GetOrdinal("PRENOM"),
                    sex = reader.GetOrdinal("SEX"),
                    dateDeNaissance = reader.GetOrdinal("DATENAISSANCE"),
                    adresse = reader.GetOrdinal("ADRESSE"),
                    telephone = reader.GetOrdinal("TELEPHONE")
                };

                while (reader.Read())
                {
                    result.Add(new Student(reader.GetInt32(columns.studentId), new Branch(reader.GetInt32(columns.idFiliere), reader.GetString(columns.nomFiliere)), reader.GetString(columns.CNE), reader.GetString(columns.nom), reader.GetString(columns.prenom), reader.GetString(columns.sex), reader.GetString(columns.adresse), reader.GetDateTime(columns.dateDeNaissance), reader.GetString(columns.telephone)));
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

        public int updateStudent(Student student)
        {

            string sqlQuery = "UPDATE [STUDENT] SET [IDFILIERE] = @IDFILIERE,[CNE] = @CNE, [NOM] = @NOM, [PRENOM] = @PRENOM,[SEX] =   @SEX, [DATENAISSANCE] =  @DATENAISSANCE,[ADRESSE] =  @ADRESSE,[TELEPHONE]  = @TELEPHONE"
                            + " WHERE [IDETUDIANT] = @ID";

            SqlCommand command = con.CreateCommand();
            command.CommandText = sqlQuery;
            command.Parameters.Add(new SqlParameter("@ID", student.Id));
            command.Parameters.Add(new SqlParameter("@IDFILIERE", student.Branch.Id));
            command.Parameters.Add(new SqlParameter("@CNE", student.CNE));
            command.Parameters.Add(new SqlParameter("@NOM", student.Nom));
            command.Parameters.Add(new SqlParameter("@PRENOM", student.Prenom));
            command.Parameters.Add(new SqlParameter("@SEX", student.Sex));
            command.Parameters.Add(new SqlParameter("@DATENAISSANCE", student.DateNessance));
            command.Parameters.Add(new SqlParameter("@ADRESSE", student.Adresse));
            command.Parameters.Add(new SqlParameter("@TELEPHONE", student.Telephone));

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

        public Dictionary<string, List<Student>> getStudentsByBranch()
        {
            Dictionary<string, List<Student>> result = new Dictionary<string, List<Student>>();

            string requette = "SELECT [IDETUDIANT] ,[FILIERE].[IDFILIERE] ,[NOMFILIERE] ,[CNE] ,[NOM] ,[PRENOM] ,[SEX] ,[DATENAISSANCE] ,[ADRESSE] ,[TELEPHONE] FROM [STUDENT] INNER JOIN [FILIERE] ON [STUDENT].IDFILIERE = [FILIERE].IDFILIERE";
            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                var columns = new
                {
                    studentId = reader.GetOrdinal("IDETUDIANT"),
                    idFiliere = reader.GetOrdinal("IDFILIERE"),
                    nomFiliere = reader.GetOrdinal("NOMFILIERE"),
                    CNE = reader.GetOrdinal("CNE"),
                    nom = reader.GetOrdinal("NOM"),
                    prenom = reader.GetOrdinal("PRENOM"),
                    sex = reader.GetOrdinal("SEX"),
                    dateDeNaissance = reader.GetOrdinal("DATENAISSANCE"),
                    adresse = reader.GetOrdinal("ADRESSE"),
                    telephone = reader.GetOrdinal("TELEPHONE")
                };

                while (reader.Read())
                {
                    string BranchName = reader.GetString(columns.nomFiliere);
                    if (!result.Keys.Contains(BranchName))
                        result.Add(BranchName, new List<Student>());

                    result[BranchName].Add(new Student(reader.GetInt32(columns.studentId), new Branch(reader.GetInt32(columns.idFiliere), BranchName), reader.GetString(columns.CNE), reader.GetString(columns.nom), reader.GetString(columns.prenom), reader.GetString(columns.sex), reader.GetString(columns.adresse), reader.GetDateTime(columns.dateDeNaissance), reader.GetString(columns.telephone)));
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

        public int addBranch(Branch branch)
        {
            string requette = "INSERT INTO [FILIERE] ([NOMFILIERE]) VALUES (@NOMFILIERE)";
            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            /*command.Parameters.Add(new SqlParameter("@IDFILIERE", branch.Id));*/
            command.Parameters.Add(new SqlParameter("@NOMFILIERE", branch.Nom));

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

        public List<Branch> getAllBranchs()
        {
            List<Branch> result = new List<Branch>();
            string requette = "SELECT [IDFILIERE] ,[NOMFILIERE] FROM [FILIERE]";

            SqlCommand command = con.CreateCommand();
            command.CommandText = requette;
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                var columns = new
                {
                    idFiliere = reader.GetOrdinal("IDFILIERE"),
                    nomFiliere = reader.GetOrdinal("NOMFILIERE")
                };

                while (reader.Read())
                {
                    result.Add(new Branch(reader.GetInt32(columns.idFiliere), reader.GetString(columns.nomFiliere)));
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

        public int updateBranch(Branch branch)
        {
            string sqlQuery = "UPDATE [FILIERE] SET  [NOMFILIERE] = @NOM WHERE [IDFILIERE] = @ID";
            SqlCommand command = con.CreateCommand();
            command.CommandText = sqlQuery;
            command.Parameters.Add(new SqlParameter("@ID", branch.Id));
            command.Parameters.Add(new SqlParameter("@NOM", branch.Nom));

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

}

