using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Teacher : Person
    {
        private string diachi;

        public string DiaChi { get => diachi; set => diachi = value; }

        public Teacher() : base()
        {

        }

        public Teacher(string maso, string hoten, string diachi) : base(maso, hoten)
        {
            this.diachi = diachi;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Nhap Dia chi: ");
            diachi = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Dia chi: {0}", this.diachi);
        }
    }
}
