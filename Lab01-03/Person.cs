using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Person
    {
        protected string maso;
        protected string hoten;

        public string MaSo { get => maso; set => maso = value; }
        public string HoTen { get => hoten; set => hoten = value; }

        public Person()
        {

        }

        public Person(string maso, string hoten)
        {
            this.maso = maso;
            this.hoten = hoten;
        }

        public virtual void Input()
        {
            Console.Write("Nhap Ma so: ");
            maso = Console.ReadLine();
            Console.Write("Nhap Ho ten: ");
            hoten = Console.ReadLine();
        }

        public virtual void Show()
        {
            Console.WriteLine("Ma so: {0} Ho ten: {1}", this.maso, this.hoten);
        }
    }
}
