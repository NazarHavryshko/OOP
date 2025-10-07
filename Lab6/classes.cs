using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab6
{
    internal class classes
    {
    }

    public class Result
    {
        public string SubjectName { get; set; }
        public string TeacherFullName { get; set; }
        public bool IsExam { get; set; }
        public byte Points { get; set; }

        private bool СheckСorrectSText(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\-'\s]+$") && text.Length > 3;
        }

        private bool СheckСorrectSExam(string text, out bool resalt)
        {
            resalt = false;
            resalt = (text == "1")? true : false;

            return resalt;
        }

        static public bool СheckСorrectPoints(string text, out byte test)
        {
            test = 0;
            return text.Length > 0 && byte.TryParse(text, out test) && test >= 0 && test <= 100;
        }

        public Result(string subjectName, string TeacherFullName, string IsExam, string Points)
        {
            bool Exam;
            byte point;

            if (this.СheckСorrectSText(subjectName) && this.СheckСorrectSText(subjectName) &&
                this.СheckСorrectSExam(IsExam, out Exam) && СheckСorrectPoints(Points, out point)
            )
            {
                this.SubjectName = subjectName;
                this.TeacherFullName = TeacherFullName;
                this.IsExam = Exam;
                this.Points = point;
            }
        }

        public Result(string subjectName, string TeacherFullName, string IsExam)
        {
            bool Exam;
            byte point;

            if (this.СheckСorrectSText(subjectName) && this.СheckСorrectSText(subjectName) &&
                this.СheckСorrectSExam(IsExam, out Exam) 
            )
            {
                this.SubjectName = subjectName;
                this.TeacherFullName = TeacherFullName;
                this.IsExam = Exam;
            }
        }


    }

    public class Student {
        public string FullName { get; set; }
        public string Group { get; set; }
        public byte CourseNumber { get; set; }

        public Result[] Results { get; set; }

        private bool СheckСorrectSName(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\-'\s]+$") && text.Length > 3;
        }

        private bool СheckСorrectSGroup(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\d\-]+$") && text.Length > 3;
        }

        public bool СheckСorrectCourseNumber(string text, out byte test)
        {
            test = 0;
            return text.Length > 0 && byte.TryParse(text, out test) && test >= 0 && test <= 10;
        }

        public int GetAveragePoint()
        {
            int sum = 0;
            for (int i = 0; i < this.Results.Length; i++)
            {
                sum += (int)this.Results[i].Points;
            }
            return sum / this.Results.Length;
        }

        public string GetWorstSubject()
        {
            int worst = 100;
            int worstId = 0;

            for (int i = 0; i < this.Results.Length; i++)
            {
                if ((int)this.Results[i].Points < worst)
                {
                    worst = (int)this.Results[i].Points;
                    worstId = i;
                }
            }
            return this.Results[worstId].SubjectName;
        }

        public Student(string FullName, string Group, string CourseNumber, string SubjectNum)
        {
            int num;
            byte course;

            if (this.СheckСorrectSName(FullName) && this.СheckСorrectSGroup(CourseNumber) &&
                this.СheckСorrectCourseNumber(CourseNumber, out course) && int.TryParse(SubjectNum, out num)
            )
            {
                this.FullName = FullName;
                this.Group = Group;
                this.CourseNumber = course;
                Results = new Result[num];
            }
        }

        public Student(string FullName, string Group, string CourseNumber)
        {
            int num;
            byte course;

            if (this.СheckСorrectSName(FullName) && this.СheckСorrectSGroup(CourseNumber) &&
                this.СheckСorrectCourseNumber(CourseNumber, out course)
            )
            {
                this.FullName = FullName;
                this.Group = Group;
                this.CourseNumber = course;
            }
        }
    }

}
