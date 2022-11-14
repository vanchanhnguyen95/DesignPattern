using System;

namespace OOP01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Nguoi nguoi1 = new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "1", "Sai Gon", new DateTime(1999,9,29));
            Nguoi nguoi2 = new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "1", "Sai Gon", new DateTime(1999,9,29));
            Nguoi nguoi3 = new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "1", "Sai Gon", new DateTime(1999,9,29));
            Nguoi nguoi4 = new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "1", "Sai Gon", new DateTime(1999,9,29));

            DiaChi dc1 = new DiaChi("Nguyen Cu Trinh", "1", "Sai Gon");
            DiaChi dc2 = new DiaChi("Nguyen Cu Trinh", "1", "Sai Gon");
            DiaChi dc3 = new DiaChi("Nguyen Cu Trinh", "2", "Sai Gon");

           
            Console.WriteLine(dc1==dc2);
            Console.WriteLine(dc1==dc3);
            Console.WriteLine($"Nguoi 1 tao email: {nguoi1.taoEmail()}");
            Console.WriteLine($"Nguoi1-toString {nguoi1.toString()}");
            Console.WriteLine($"DiaChi1-toString {dc1.toString()}");
            Console.WriteLine($"Nguoi - So nguoi: {Nguoi.SoNguoi}");
            Console.WriteLine($"DiaChi - operator == (dc1 == dc2): {dc1 == dc2}");
            Console.WriteLine($"DiaChi - operator != (dc1 != dc2): {dc1 != dc2}");
            Console.WriteLine($"Nguoi1 - taoEmail(): {nguoi1.taoEmail()}");
        }
    }
}
