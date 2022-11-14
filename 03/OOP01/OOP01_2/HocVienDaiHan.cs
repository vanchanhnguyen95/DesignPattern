using System;
using System.Collections.Generic;
using System.Text;

namespace OOP01_2
{
    class HocVienDaiHan : HocVien
    {
        /*Fields*/
        private int _soTinChi;
        private double _donGiaTinChi;

        public HocVienDaiHan(int _soTinChi, double _donGiaTinChi, Nguoi thongTinHocVien, string _maHocVien) : base(thongTinHocVien, _maHocVien)
        {
            this.SoTinChi = _soTinChi;
            this.DonGiaTinChi = _donGiaTinChi;
        }

        ~HocVienDaiHan() { }

        /*Properties*/
        public int SoTinChi { get => _soTinChi; set => _soTinChi = value; }
        public double DonGiaTinChi { get => _donGiaTinChi; set => _donGiaTinChi = value; }

        /*Method-Function*/
        override public double getHocPhi()
        {
            return this.SoTinChi * this.DonGiaTinChi;
        }

        override public string toString()
        {
            return $"Hoc vien dai han: {this.ThongTinHocVien.HoTen} + {this.ThongTinHocVien.NgaySinh.ToString("dd/MM/yyyy")}";
        }
    }
}
