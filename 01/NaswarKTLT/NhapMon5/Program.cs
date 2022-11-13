using System;

namespace NhapMon5
{
    /*
     Nhập môn 5
      Viết chương trình nhập vào chỉ số cũ, chỉ số mới và tính tiền điện trả định mức, tiền trả vượt định mức,
      tổng tiền phải trả biết:
      - Định mức sử dụng điện cho mỗi hộ là 50 KW
      - Nếu phần vượt định mức <= 50 KW thì tính giá 1500đ/KW
      - Nếu 50 KW <= phần vượt định ức <= 100KW thì tính giá 1800đ/KW
      - Nếu phần vượt định mức >100KW thì tính giá 2500đ/KW
      - Chỉ số mới và chỉ số cũ được nhập vào từ bàn phím
      - Mức điện tiêu thụ = Chỉ số mới - chỉ số cũ (KW)
      - Phần vượt định mức = Mức điện tiêu thụ -

      ****
      *Mẹo làm: nhìn xem có những biến nào, hằng nào
      *
      *Biến: chiSoMoi, chiSoCu, tienDienTraDinhMuc, tienDienTraVuotDinhMuc, tongTienPhaiTra
      *Hằng:  50KW: 1000,
      *        100KW:  1500,
      *        150KW:  1800
      *        orther: 2500

     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh tien dien!");

            int chiSoMoi;
            int chiSoCu;
            int mucDienTieuThu;
            int mucDienTieuThuVuotDinhMuc;
            double tienDienTraDinhMuc;
            double tienDienTraVuotDinhMuc;
            double tongTienDienPhaiTra;

            const int _50kw = 1000;
            const int _100kw = 1500;
            const int _150kw = 1800;
            const int _other_kw = 2500;

            do
            {
                Console.WriteLine("Nhap chi so cu: ");
            } while (!int.TryParse(Console.ReadLine(),out chiSoCu));

            do
            {
                Console.WriteLine("Nhap chi so moi: ");
            } while (!int.TryParse(Console.ReadLine(), out chiSoMoi) || chiSoCu > chiSoMoi);

            // Tính mức điện tiêu thụ = chỉ số mới - chỉ số cũ
            mucDienTieuThu = chiSoMoi - chiSoCu;

            // Tính tiền trả định mức cho mức 50KW
            if(mucDienTieuThu <= 50)
            {
                tienDienTraDinhMuc = mucDienTieuThu * _50kw;
                tienDienTraVuotDinhMuc = 0;
                //tongTienDienPhaiTra = tienDienTraDinhMuc + tienDienTraVuotDinhMuc;
            } else if(mucDienTieuThu <= 100)
            {
                tienDienTraDinhMuc = 50 * _50kw;
                mucDienTieuThuVuotDinhMuc = mucDienTieuThu - 50;
                tienDienTraVuotDinhMuc = mucDienTieuThuVuotDinhMuc * _100kw;
                //tongTienDienPhaiTra = tienDienTraDinhMuc + tienDienTraVuotDinhMuc;
            }
            else if (mucDienTieuThu <= 150)
            {
                tienDienTraDinhMuc = 50 * _50kw;
                tienDienTraVuotDinhMuc = 50 * _100kw;
                mucDienTieuThuVuotDinhMuc = mucDienTieuThu - 100;
                tienDienTraVuotDinhMuc += mucDienTieuThuVuotDinhMuc * _150kw;
                //tongTienDienPhaiTra = tienDienTraDinhMuc + tienDienTraVuotDinhMuc;
            }
            else
            {
                tienDienTraDinhMuc = 50 * _50kw;
                tienDienTraVuotDinhMuc = 50 * _100kw + 50 * _150kw;
                mucDienTieuThuVuotDinhMuc = mucDienTieuThu - 150;
                tienDienTraVuotDinhMuc += mucDienTieuThuVuotDinhMuc * _other_kw;
                //tongTienDienPhaiTra = tienDienTraDinhMuc + tienDienTraVuotDinhMuc;
            }
            tongTienDienPhaiTra = tienDienTraDinhMuc + tienDienTraVuotDinhMuc;

            //Console.WriteLine($"{chiSoCu} - {chiSoMoi} - {mucDienTieuThu}");
            Console.WriteLine($"Tien tra dinh muc: {tienDienTraDinhMuc}");
            Console.WriteLine($"Tien tra uot dinh muc: {tienDienTraVuotDinhMuc}");
            Console.WriteLine($"Tong tien phai tra: {tongTienDienPhaiTra}");

            // 57 - 78 
            // 20 - 90
            // 55 - 165
            // 68 263
        }
    }
}
