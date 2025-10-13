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
        public string SubjectName { get; } = "Невказано";
        public string TeacherFullName { get; } = "Н/Д";
        public bool IsExam { get; } = false;
        public byte Points { get; } = 0; 

        private bool СheckСorrectSText(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ\-'\s\.]+$") && text.Length >= 3;
        }

        private bool СheckСorrectSExam(string text, out bool resalt)
        {
            resalt = (text == "1"); 
            return (text == "1" || text == "2");
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

            if (this.СheckСorrectSText(subjectName) && this.СheckСorrectSText(TeacherFullName) &&
                this.СheckСorrectSExam(IsExam, out Exam) && СheckСorrectPoints(Points, out point)
            )
            {
                this.SubjectName = subjectName;
                this.TeacherFullName = TeacherFullName;
                this.IsExam = Exam;
                this.Points = point;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }
        }

        public Result(string subjectName, string TeacherFullName, string IsExam)
        {
            bool Exam;
            byte point;

            if (this.СheckСorrectSText(subjectName) && this.СheckСorrectSText(TeacherFullName) &&
                this.СheckСorrectSExam(IsExam, out Exam) 
            )
            {
                this.SubjectName = subjectName;
                this.TeacherFullName = TeacherFullName;
                this.IsExam = Exam;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }
        }

        public Result(Result other)
        {
            this.SubjectName = other.SubjectName;
            this.TeacherFullName = other.TeacherFullName;
            this.IsExam = other.IsExam;
            this.Points = other.Points;
        }

        public override string ToString()
        {
            //string examMark = this.IsExam ? "(Екзамен)" : "(Залік)";
            //return $"Предмет: {this.SubjectName} {examMark.PadRight(30)} Викладач: {this.TeacherFullName.PadRight(30)} Оцінка: {this.Points.ToString().PadLeft(3)} балів.";
            string examMark = this.IsExam ? "(Екзамен)" : "(Залік)";
            string subjectAndType = $"{this.SubjectName} {examMark}";

            return String.Format("Предмет: {0,-40} Викладач: {1,-30} Оцінка: {2,3} балів.",
                subjectAndType,
                this.TeacherFullName,
                this.Points
            );
        }
    }

    public class Student {
        public string FullName { get; } = "Невказано";
        public string Group { get; } = "K-00";
        public byte CourseNumber { get;  } = 1;

        public Result[] Results { get; private set; } = new Result[0];

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
            if (this.Results.Length == 0)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < this.Results.Length; i++)
            {
                sum += (int)this.Results[i].Points;
            }
            return (int)(sum / this.Results.Length);
        }

        public string GetWorstSubject()
        {
            if (this.Results.Length == 0)
            {
                return "0";
            }
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

            if (this.СheckСorrectSName(FullName) && this.СheckСorrectSGroup(Group) &&
                this.СheckСorrectCourseNumber(CourseNumber, out course) && int.TryParse(SubjectNum, out num)
            )
            {
                this.FullName = FullName;
                this.Group = Group;
                this.CourseNumber = course;
                Results = new Result[num];
            }
            else {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }
        }

        public Student(string FullName, string Group, string CourseNumber)
        {
            int num;
            byte course;

            if (this.СheckСorrectSName(FullName) && this.СheckСorrectSGroup(Group) &&
                this.СheckСorrectCourseNumber(CourseNumber, out course)
            )
            {
                this.FullName = FullName;
                this.Group = Group;
                this.CourseNumber = course;
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }
        }

        public void AddResults(Result[] result)
        {
            this.Results = result;
        }

        public Student(Student other)
        {
            this.FullName = other.FullName;
            this.Group = other.Group;
            this.CourseNumber = other.CourseNumber;
            this.Results =  other.Results.Select(r => new Result(r)).ToArray();
        }



        public override string ToString()
        {
            return $"Ім'я студента: {this.FullName.PadRight(30)} Група: {this.Group.PadRight(12)} Курс: {this.CourseNumber}";
        }
    }

}
