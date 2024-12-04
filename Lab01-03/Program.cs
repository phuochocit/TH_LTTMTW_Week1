using Lab01_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Them giao vien");
                Console.WriteLine("3. Xuat danh sach sinh vien");
                Console.WriteLine("4. Xuat danh sach giao vien");
                Console.WriteLine("5. So luong sinh vien va giao vien");
                Console.WriteLine("6. Xuat danh sach sinh vien thuoc khoa CNTT");
                Console.WriteLine("7. Xuat danh sach giao vien co dia chi o Quan 9");
                Console.WriteLine("8. Xuat danh sach sinh vien co diem trung binh cao nhat va thuoc khoa CNTT");
                Console.WriteLine("9. Xep hang thanh tich cua sinh vien");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        AddTeacher(teacherList);
                        break;
                    case "3":
                        DisplayStudentList(studentList);
                        break;
                    case "4":
                        DisplayTeacherList(teacherList);
                        break;
                    case "5":
                        DisplayAllListStudentsAndTeachers(studentList, teacherList);
                        break;
                    case "6":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "7":
                        DisplayTeachersByAddress(teacherList, "Quan 9");
                        break;
                    case "8":
                        DisplayStudentsWithHigestAverangeScoreByFaculty(studentList, "CNTT");
                        break;
                    case "9":
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

        // Case 1:
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhap thong tin sinh vien ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        // Case 2:
        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Nhap thong tin giao vien ===");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Them giao vien thanh cong!");
        }

        // Case 3:
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sach chi tiet thong tin sinh vien ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        // Case 4:
        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Danh sach chi tiet thong tin giao vien ===");
            foreach (Teacher teacher in teacherList)
            {
                teacher.Show();
            }
        }

        // Case 5:
        static void DisplayAllListStudentsAndTeachers(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine("=== So luong ===");
            Console.WriteLine("So luong sinh vien: {0}", studentList.Count);
            Console.WriteLine("So luong giao vien: {0}", teacherList.Count);
        }

        // Case 6:
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien thuoc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        // Case 7:
        static void DisplayTeachersByAddress(List<Teacher> teacherList, string address)
        {
            Console.WriteLine("=== Danh sach giao vien thuoc {0} ===", address);
            var teachers = teacherList.Where(s => s.DiaChi.Equals(address, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayTeacherList(teachers);
        }
        // Case 8:
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

        // Case 9:
        static void Rank(List<Student> studentList)
        {
            Console.WriteLine("=== Xep hang sinh vien ===");
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
    }
}
