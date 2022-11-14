using System;

namespace OOP01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Câu b

            //HocVien hocVien = new HocVienNganHan(13, 2000000
            //    , new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "Quan 1", "Sai Gon", new DateTime(1999, 9, 29)), "19211TT4280");

            HocVien hocVien = input();

            HocVienDaiHan hocVienDaiHan = new HocVienDaiHan(14,2000000
                , new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "Quan 1", "Sai Gon", new DateTime(1999,9,29)), "19211TT4280");
            HocVienNganHan hocVienNganHan = new HocVienNganHan(15, 2000000 
                , new Nguoi("Vu Minh Chuan", "Nguyen Cu Trinh", "Quan 1", "Sai Gon", new DateTime(1999, 9, 29)), "19211TT4280");

            Console.WriteLine($"HocVien-getHocPhi(): {hocVien.getHocPhi()}");
            Console.WriteLine($"HocVienDaiHan-getHocPhi(): {hocVienDaiHan.getHocPhi()}");
            Console.WriteLine($"HocVienNganHan-getHocPhi(): {hocVienNganHan.getHocPhi()}");
            Console.WriteLine($"HocVien-toString(): {hocVien.toString()}");
            Console.WriteLine($"HocVienDaiHan-toString(): {hocVienDaiHan.toString()}");
            Console.WriteLine($"HocVienNganHan-toString(): {hocVienNganHan.toString()}");
        }

        static HocVien input()
        {
            HocVien hocVien;
            Nguoi thongTinHocVien;
            string _maHocVien = string.Empty;
            //string _hoTen;
            //DiaChi _diaChi;
            //string _tenDuong;
            //string _quan;
            //string _thanhPho;
            //DateTime _ngaySinh;

            char key;
            Console.WriteLine("A. Nhap so -> Hoc Vien Dai Han.\nB. Nhap chu -> Hoc Vien Ngan Han ");
            key = Console.ReadKey(true).KeyChar;

            thongTinHocVien = nhapThongTinHocVien(ref _maHocVien);

            if (key == char.ToUpper(key))
            {
                int _soTinChi;
                double _donGiaTinChi;
                //thongTinHocVien = nhapThongTinHocVien(ref _maHocVien);

                Console.Write("Nhap ma hoc vien: ");
                _maHocVien = Console.ReadLine();

                do
                {
                    Console.WriteLine("Nhap so tin chi: ");
                } while (!int.TryParse(Console.ReadLine(), out _soTinChi));

                do
                {
                    Console.WriteLine("Nhap don gia tin chi: ");
                } while (!double.TryParse(Console.ReadLine(), out _donGiaTinChi));

                hocVien = new HocVienDaiHan(_soTinChi,_donGiaTinChi,thongTinHocVien, _maHocVien);
            } 
            else
            {
                int _soKhoaHoc;
                double _giaTien1KhoaHoc;
                //thongTinHocVien = nhapThongTinHocVien(ref _maHocVien);

                do
                {
                    Console.WriteLine("Nhap so khoa hoc: ");
                } while (!int.TryParse(Console.ReadLine(), out _soKhoaHoc));

                do
                {
                    Console.WriteLine("Nhap gia tien 1 khoa hoc: ");
                } while (!double.TryParse(Console.ReadLine(), out _giaTien1KhoaHoc));

                hocVien = new HocVienNganHan(_soKhoaHoc, _giaTien1KhoaHoc, thongTinHocVien, _maHocVien);
            }    

            return hocVien;
        }

        static Nguoi nhapThongTinHocVien(ref string _maHocVien)
        {
            string _hoTen;
            string _tenDuong;
            string _quan;
            string _thanhPho;
            //DateTime _ngaySinh;
            int _ngay;
            int _thang;
            int _nam;
            Nguoi nguoi;

            Console.WriteLine("---------Nhap thong tin hoc vien---------");
            Console.Write("Nhap ma hoc vien: ");
            _maHocVien = Console.ReadLine();

            Console.Write("Nhap ho ten hoc vien: ");
            _hoTen = Console.ReadLine();

            Console.Write("Nhap ten duong dia chi: ");
            _tenDuong = Console.ReadLine();

            Console.Write("Nhap quan  dia chi: ");
            _quan = Console.ReadLine();

            Console.Write("Nhap thanh pho dia chi: ");
            _thanhPho = Console.ReadLine();

            do
            {
                Console.WriteLine("Nhap ngay sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out _ngay));

            do
            {
                Console.WriteLine("Nhap thang sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out _thang));

            do
            {
                Console.WriteLine("Nhap nam sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out _nam));

            nguoi = new Nguoi(_hoTen, _tenDuong, _quan, _thanhPho, new DateTime(_nam, _thang, _ngay));
            return nguoi;
        }
    }
}
