using System;
using System.Collections.Generic;
using System.Text;

namespace OOP01_2
{
    class HocVienNganHan : HocVien
    {
        /*Fields*/
        private int _soKhoaHoc;
        private double _giaTien1KhoaHoc;

        public HocVienNganHan(int _soKhoaHoc, double _giaTien1KhoaHoc, Nguoi thongTinHocVien, string _maHocVien) : base(thongTinHocVien, _maHocVien)
        {
            this.SoKhoaHoc = _soKhoaHoc;
            this.GiaTien1KhoaHoc = _giaTien1KhoaHoc;
        }

        ~HocVienNganHan() { }

        /*Properties*/
        public int SoKhoaHoc { get => _soKhoaHoc; set => _soKhoaHoc = value; }
        public double GiaTien1KhoaHoc { get => _giaTien1KhoaHoc; set => _giaTien1KhoaHoc = value; }

        /*Method-Function*/
        override public double getHocPhi()
        {
            return this.SoKhoaHoc * this.GiaTien1KhoaHoc;
        }

        override public string toString()
        {
            return $"Hoc vien ngan han: {this.ThongTinHocVien.HoTen} + {this.ThongTinHocVien.NgaySinh.ToString("dd/MM/yyyy")}";
        }
    }
}
