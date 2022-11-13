using System;

namespace NhapMon4
{
    class Program
    {
        // swith: đơn giản là nó lấy biến này làm case chính và đem đi so sánh
        // Dùng swith-case tốt hơn if-else chỗ nào
        /*
         1.nhìn nó tường minh hơn
         2.swith-case thường dùng những trường hợp biết dữ liệu
         3.else tương đường default
         4.khi nào sử dụng if else, swith-case
          if-else: sử dụng mọi trường hợp, swith-case: tốt nhất biết trước kết quả
         */
        static void Main(string[] args)
        {
            Console.WriteLine("swith-case");
            int i = 0;
            switch (i)
            {
                case 0:
                case 1:
                    Console.WriteLine(i++);
                    Console.WriteLine(++i);
                    break;
                case 2:
                case 3:
                    Console.WriteLine(i--);
                    Console.WriteLine(--i);
                    break;
                default:
                    Console.WriteLine(10);
                    break;
            }
            // 0 2

        }
    }
}
