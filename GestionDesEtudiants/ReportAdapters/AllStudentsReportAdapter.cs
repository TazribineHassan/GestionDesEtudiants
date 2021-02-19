using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesEtudiants.ReportAdapters
{
    public class AllStudentsReportAdapter
    {
        public string BranchName { get; set; }
        public List<OneStudentReportAdapter> students { get; set; }
        public string reportDate;
        public AllStudentsReportAdapter(string BranchName, List<Student> students)
        {
            this.BranchName = BranchName;
            this.students = new List<OneStudentReportAdapter>();
            if(students != null)
            {
                foreach (var student in students)
                {
                    this.students.Add(new OneStudentReportAdapter(student));
                }
            }
            reportDate = DateTime.Now.ToShortDateString();
        }

    }
}
