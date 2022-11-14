using System;
using System.Collections.Generic;
using System.Text;

namespace OOP01_2
{
    abstract class HocVien
    {
        /*Fields*/
        private Nguoi thongTinHocVien;
        private string _maHocVien;

        //public HocVien() { }

        /*Constructor*/
        public HocVien(Nguoi thongTinHocVien, string _maHocVien) {
            this.thongTinHocVien = thongTinHocVien;
            this._maHocVien = _maHocVien;
        }

        ~HocVien() { }

        /*Properties*/
        public string MaHocVien { get => _maHocVien; set => _maHocVien = value; }
        protected Nguoi ThongTinHocVien { get => thongTinHocVien; set => thongTinHocVien = value; }

        /*Method-Function*/
        virtual public double getHocPhi()
        {
            return 0;
        }

        virtual public string toString()
        {
            return $"Hoc vien: {this.ThongTinHocVien.HoTen} + {this.ThongTinHocVien.NgaySinh.ToString("dd/MM/yyyy")} + {this.getHocPhi()}";
        }
    }
}
