using System;

namespace NhapMon2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1
            //int i;
            //do
            //{
            //    Console.Write("nhap i:");
            //} while (!int.TryParse(Console.ReadLine(), out i));// Nó luôn luôn là số mới cho nhập,
            //// Nhập mà nhập khác kiểu số, nhập chữ => trả về False=> !False là True => Vòng lặp tiếp tục
            ///
            */

            /*2
            int i;
            while(!int.TryParse(Console.ReadLine(),out i))
            {
                Console.Write("nhap i: ");
            }
            // Đầu tiên:
            - Nếu ta nhập số thì, trà về True, !True là False, sẽ ko chạy vòng lặp while, sẽ ko hiện dòng "nhap i"
            */

            /*3*: ko dừng lại: ví 2 số lẻ nhân với nhau luôn ra 1 số lẻ */
            int i = 1;
            while(i % 2 != 0)
            {
                i *= 3;
                Console.WriteLine(i);
            }    
        }
    }
}
