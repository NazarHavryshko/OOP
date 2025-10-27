using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    internal class Students
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

    public class Student
    {
        public string FullName { get; } = "Невказано";
        public string Group { get; } = "K-00";
        public byte CourseNumber { get; } = 1;
        public int TuitionFee { get; } = 0;

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
        public static bool СheckPosibleIntNumber(string input_text, out int x)
        {
            x = -1;

            if (int.TryParse(input_text, out x) && x > 0)
            {
                return true;
            }
            return false;
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

        public Student(string fullName, string group, string courseNumber, string subjectNum, int price)
        {
            int num;
            byte course;

            if (this.СheckСorrectSName(fullName) && this.СheckСorrectSGroup(group) &&
                this.СheckСorrectCourseNumber(courseNumber, out course) && СheckPosibleIntNumber(subjectNum, out num) &&
                price > 0
            )
            {
                this.FullName = fullName;
                this.Group = group;
                this.CourseNumber = course;
                this.TuitionFee = price;

                Results = new Result[num];
            }
            else
            {
                throw new ArgumentException("Один або більше параметрів для створення Result є некоректними.");
            }
        }

        public Student(string fullName, string group, string courseNumber)
        {
            byte course;

            if (this.СheckСorrectSName(fullName) && this.СheckСorrectSGroup(group) &&
                this.СheckСorrectCourseNumber(courseNumber, out course)
            )
            {
                this.FullName = fullName;
                this.Group = group;
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
            this.Results = other.Results.Select(r => new Result(r)).ToArray();
        }



        public override string ToString()
        {
            return $"Ім'я студента: {this.FullName.PadRight(30)} Група: {this.Group.PadRight(12)} Курс: {this.CourseNumber}";
        }
    }
}
