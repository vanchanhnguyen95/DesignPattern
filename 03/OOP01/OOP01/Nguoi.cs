using System;
using System.Collections.Generic;
using System.Text;

namespace OOP01
{
    class Nguoi
    {
        /*Fields*/
        private string _hoTen;
        private DiaChi _diaChi;
        private static int _soNguoi= 0;//Khi có 1 biến static thì mặc định cho nó 1 số nào đó khởi tạo
        // Khi tạo 1 field mà nó là static thì không bao giờ đưa nó vào constructor
        private DateTime _ngaySinh;

        /*Constructor*/
        Nguoi() { }

        public Nguoi(string _hoTen, string _tenDuong, string _quan, string _thanhPho, DateTime _ngaySinh)
        {
            this._hoTen = _hoTen;
            this.DiaChi = new DiaChi(_tenDuong, _quan, _thanhPho);
            this._ngaySinh = _ngaySinh;
            _soNguoi++;
        }

        ~Nguoi() { }

        /*Properties*/
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        internal DiaChi DiaChi { get => _diaChi; set => _diaChi = value; }
        public static int SoNguoi { get => _soNguoi; set => _soNguoi = value; }
        //public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }

        /*Method - Function*/
        public string toString()
        {
            return $"NgayThangNam: {this._ngaySinh.Day}/{this._ngaySinh.Month}/{this._ngaySinh.Year}\n" +
                $"Nguoi: {this._hoTen} + {this._diaChi.toString()}";
        }

        public string taoEmail()
        {
            string tenEmail = this._hoTen.Replace(' ', '\0');
            return tenEmail+"@gmail.com";
        }


    }
}
