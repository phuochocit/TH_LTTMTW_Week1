using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Student : Person
    {
        //1. Field
        private float averageScore;
        private string faculty;

        //2. Property
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        //3. Constructor
        public Student() : base()
        {

        }

        public Student(string maso, string hoten, float averageScore, string faculty) : base (maso, hoten)
        {
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        //4. Method
        public override void Input()
        {
            base.Input();
            Console.Write("Nhap Diem TB: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhap Khoa: ");
            Faculty = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Khoa: {0} Diem TB: {1}", this.Faculty, this.AverageScore);
        }
    }
}