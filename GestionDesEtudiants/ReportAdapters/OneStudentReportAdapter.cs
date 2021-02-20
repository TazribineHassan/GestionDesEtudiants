using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesEtudiants.ReportAdapters
{
    public class OneStudentReportAdapter
    {
        public string CNE { get; set; }
        public string NomFiliere { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string DateNaissance { get; set; }
        public string Telephone { get; set; }
        public OneStudentReportAdapter(Student student)
        {
            this.CNE = student.CNE;
            this.NomFiliere = student.Branch.Nom;
            this.Nom = student.Nom;
            this.Prenom = student.Prenom;
            this.Sex = student.Sex;
            this.Address = student.Adresse;
            this.DateNaissance = student.DateNessance.ToShortDateString();
            this.Telephone = student.Telephone;
        }
    }


}
