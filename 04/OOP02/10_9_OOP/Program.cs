using System;
using System.Collections.Generic;

namespace _10_9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Sinh Vien Trung Cap");
            //SinhVienTrungCap sinhVienTrungCap = new SinhVienTrungCap("19211TT4280","Vu Minh Chuan", "TC19TT9","CNTT", new DateTime(1999,9,29), 199000);
            //Console.WriteLine($"SinhVienTrungCap - toString() {sinhVienTrungCap.toString()}");
            //Console.WriteLine($"SinhVienTrungCap - tinhHocPhi(): {sinhVienTrungCap.tinhHocPhi()}");
            //Console.WriteLine("");

            //Console.WriteLine("Sinh Vien Cao Dang");
            //SinhVienCaoDang sinhVienCaoDang = new SinhVienCaoDang("19211TT4280", "Vu Minh Chuan", "CD19TT9", "CNTT", new DateTime(1999, 9, 29), 2,3);
            //Console.WriteLine($"SinhVienCaoDang - toString() {sinhVienCaoDang.toString()}");
            //Console.WriteLine($"SinhVienCaoDang - tinhHocPhi(): {sinhVienCaoDang.tinhHocPhi()}");

            //ISinhVien sinhVienCaoDang = TienIchSinhVien.nhapSinhVienCaoDang();
            //Console.WriteLine($"SinhVienCaoDang - toString() {sinhVienCaoDang.toString()}");
            //Console.WriteLine($"SinhVienCaoDang - tinhHocPhi(): {sinhVienCaoDang.tinhHocPhi()}");

            //TienIchSinhVien.nhapListSinhVien();


            TienIchSinhVien sinhVien = new TienIchSinhVien();
            

            char key = '\0';
            // Nhấp như bấm escape thì ngưng, không nhập nữa
            do
            {
                Console.Clear();
                Console.WriteLine("Menu: \n" +
                 "1. Nhap sinh vien\n" +
                 "2. Xem danh sach sinh vien\n" +
                 "3. Hien thi so luong cac sinh vien\n" +
                 "4. Tim kiem cac sinh vien\n" +
                 "ESC. Thoat"
                 );

                do
                {
                    key = Console.ReadKey().KeyChar;
                    //Console.WriteLine();
                } while (!key.Equals((char)ConsoleKey.Escape)
                    && !key.Equals((char)ConsoleKey.NumPad1)
                    && !key.Equals((char)ConsoleKey.D1)
                    && !key.Equals((char)ConsoleKey.NumPad2)
                    && !key.Equals((char)ConsoleKey.D2)
                     && !key.Equals((char)ConsoleKey.NumPad3)
                    && !key.Equals((char)ConsoleKey.D3)
                     && !key.Equals((char)ConsoleKey.NumPad4)
                    && !key.Equals((char)ConsoleKey.D4)
                    );

                switch (key)
                {
                    case (char)ConsoleKey.NumPad1:
                    case (char)ConsoleKey.D1:
                        Console.Clear();
                        sinhVien.nhapListSinhVien();
                        break;
                    case (char)ConsoleKey.NumPad2:
                    case (char)ConsoleKey.D2:
                        Console.Clear();
                        sinhVien.hienThiListSinhVien();
                        Console.ReadKey();
                        break;
                    case (char)ConsoleKey.NumPad3:
                    case (char)ConsoleKey.D3:
                        Console.Clear();
                        sinhVien.hienThiSoLuongCacSinhVien();
                        Console.ReadKey();
                        break;
                    case (char)ConsoleKey.NumPad4:
                    case (char)ConsoleKey.D4:
                        Console.Clear();
                        sinhVien.find();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }    
               

            } while (!key.Equals((char)ConsoleKey.Escape));

            //sinhVien.nhapListSinhVien();
            //sinhVien.hienThiListSinhVien();
            //sinhVien.hienThiSoLuongCacSinhVien();
            //sinhVien.find();
        }
    }
}
