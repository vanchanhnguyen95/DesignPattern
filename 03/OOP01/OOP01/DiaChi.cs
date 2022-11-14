using System;
using System.Collections.Generic;
using System.Text;

namespace OOP01
{
    class DiaChi
    {
        // Dấu "-" là private
        /*Fields*/
        private string _tenDuong;
        private string _quan;
        private string _thanhPho;

        /*Constructor*/
        DiaChi()
        {

        }

        public DiaChi(string _tenDuong, string _quan, string _thanhPho)
        {
            this._tenDuong = _tenDuong;
            this._quan = _quan;
            this._thanhPho = _thanhPho;
        }

        //Thêm cả hàm hủy
        ~DiaChi() { }

        // Dùng phím tắt Ctrl + R + E: để ra get, set
        public string TenDuong { get => _tenDuong; set => _tenDuong = value; }
        public string Quan { get => _quan; set => _quan = value; }
        public string ThanhPho { get => _thanhPho; set => _thanhPho = value; }

        /*Method - Function*/
        public string toString()
        {
            return $"DiaChi: {this._tenDuong}, {this._quan}, {this._thanhPho}\n";
        }

        // Định nghĩa operator là 1 toán tử
        public static bool operator ==(DiaChi dc1, DiaChi dc2)
        {
            return dc1.TenDuong.Equals(dc2.TenDuong) && dc1.Quan.Equals(dc2.Quan) && dc1.ThanhPho.Equals(dc2.ThanhPho);
        }

        public static bool operator !=(DiaChi dc1, DiaChi dc2)
        {
            return !(dc1==dc2);
        }
    }
}
