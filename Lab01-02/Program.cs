using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi danh sach sinh vien");
                Console.WriteLine("3. Hien thi danh sach sinh vien thuoc khoa CNTT");
                Console.WriteLine("4. Hien thi danh sach sinh vien co diem tb >= 5");
                Console.WriteLine("5. Hien thi danh sach sinh vien sap xep tang dan theo diem tb");
                Console.WriteLine("6. Hien thi danh sach sinh vien thuoc khoa CNTT va co diem tb >= 5");
                Console.WriteLine("7. Hien thi danh sach sinh vien co diem tb cao nhat va thuoc khoa CNTT");
                Console.WriteLine("8. Xep hang thanh tich cua sinh vien");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverangeScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHigestAverangeScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        Rank(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Tuy chon khong hop le. Vui long chon lai");
                        break;
                }
                Console.ReadLine();
            }
        }

        // Case 8
        static void Rank(List<Student> studentList)
        {
            Console.WriteLine("=== Xep hang sinh vien");
            var students = studentList.GroupBy(s =>
            {
                if (s.AverageScore >= 9) return "Xuat sac";
                else if (s.AverageScore >= 8) return "Gioi";
                else if (s.AverageScore >= 7) return "Kha";
                else if (s.AverageScore >= 5) return "Trung Binh";
                else if (s.AverageScore >= 4) return "Yeu";
                else return "Kem";
            }).Select(g => new
            {
                Grade = g.Key,
                Count = g.Count()
            });
            Console.WriteLine("=== So luong sinh vien theo tung loai ===");
            foreach (var group in students)
                Console.WriteLine($"{group.Grade}: {group.Count} sinh vien");
        }

        // Case 7
        static void DisplayStudentsWithHigestAverangeScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien co diem trung binh cao nhat va thuoc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (students.Any())
            {
                var maxAverange = students.Max(s => s.AverageScore);
                var topStudents = students.Where(s => s.AverageScore == maxAverange).ToList();
                DisplayStudentList(topStudents);
            }
            else
            {
                Console.WriteLine("Khong co sinh vien nao");
            }
        }

        // Case 6
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("=== Danh sach sinh vien co diem tb >= {0} va thuoc khoa {1}", minDTB, faculty);
            var students = studentList.Where(s => s.AverageScore >= minDTB && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // Case 5
        static void SortStudentsByAverangeScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sach sinh vien duoc sap xep theo diem tb tang dan ===");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }

        // Case 4
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("=== Danh sach sinh vien co diem TB >= {0}", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB).ToList();
            DisplayStudentList(students);
        }

        // Case 3
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien thuoc khoa {0}", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // Case 2
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sach chi tiet thong tin sinh vien ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        // Case 1
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhap thong tin sinh vien ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");
        }
    }
}           