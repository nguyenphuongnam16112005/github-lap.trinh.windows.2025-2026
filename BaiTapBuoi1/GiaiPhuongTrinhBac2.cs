using System;
using System.Runtime.CompilerServices;

/*Viết phương trình bậc 2
 * Trong đó có sử dụng kế thừa
 * từ lớp giải phương trình bậc 1 (OOP)
*/
namespace BT1
{
    class giaiPhuongTrinhBac1
    {
        public double? giai(double a, double b)
        {
            if (a == 0) return null;
            return -b / a;
        }
    }

    class giaiPhuongTrinhBac2 : giaiPhuongTrinhBac1
    {
        public void giai(double a, double b, double c)
        {
            if (a == 0)
            {
                double? ketQua = base.giai(b, c);
                if (ketQua == null) Console.WriteLine("Vo so nghiem");
                else Console.WriteLine("Mot nghiem " + ketQua);
                return;
            }

            double delta = b * b - 4 * a * c;

            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Hai nghiem " + x1 + " " + x2);
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Mot nghiem " + x);
            }
            else
            {
                Console.WriteLine("Vo nghiem");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("c: ");
            double c = double.Parse(Console.ReadLine());

            giaiPhuongTrinhBac2 pt = new giaiPhuongTrinhBac2();
            pt.giai(a, b, c);
        }
    }
}