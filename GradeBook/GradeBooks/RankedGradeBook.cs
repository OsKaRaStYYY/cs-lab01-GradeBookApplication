using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }


            base.CalculateStatistics();
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int StudentProcent = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> Grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            int index = Grades.IndexOf(averageGrade);
            if (index < StudentProcent)
            {
                return 'A';
            }
            else if (index < StudentProcent * 2)
            {
                return 'B';

            }
            else if (index < StudentProcent * 3)
            {
                return 'C';

            }
            else if (index < StudentProcent * 4)
            {

                return 'D';
            }
            else 
            {
                return 'F';
            }
        }


        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }  
    
}
