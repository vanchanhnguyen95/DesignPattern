using System;

namespace SoHoanHao
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Số hoàn thiên (hoàn hảo): là một số nguyên dương mà tổng các ước nguyên dương chính thức của nó bằng chính nó
            /*Ý tưởng: */

            // CÁCH 1: CHƯA TỐI ƯU
            //int n;
            //int tongUoc = 0;
            //string danhsachUocSo = string.Empty;

            //Console.WriteLine("===Chuong trinh kiem tra so hoan hao===");
            ////
            //do
            //{
            //    Console.WriteLine(" Nhap so n de kiem tra la so hoan hao");
            //} while (!int.TryParse(Console.ReadLine(), out n));


            //for(int i = 1; i < n; i++)
            //{
            //    if(n % i == 0)
            //    {
            //        tongUoc += i;
            //        danhsachUocSo += i.ToString() + " ";
            //    }    
            //}

            //if (tongUoc == n)
            //{
            //    Console.WriteLine($"{n} la so hoan hao");
            //    Console.WriteLine($"{danhsachUocSo.Trim()} la danh sach cac uoc so");
            //} 
            //else
            //{
            //    Console.WriteLine($"{n} khong la so hoan hao");
            //}

            //Console.WriteLine("Bam phim bat ki de ket thuc chuong trinh");

            // CÁCH 2: TỐI ƯU
            /*
             * Tối ưu vòng lặp for cho chạy dến n/2, vì ước >= (n/2) + 1 thì sẽ ko có
             khởi tạo sum=1, cho i chạy từ 2 vì số nào cũng chia hết cho 1, giảm được số vòng lặp
             */
            int n;
            int sum = 1;
            string danhsachUocSo = string.Empty;

            Console.WriteLine("===Chuong trinh kiem tra so hoan hao===");
            //
            do
            {
                Console.WriteLine(" Nhap so n de kiem tra la so hoan hao");
            } while (!int.TryParse(Console.ReadLine(), out n));


            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    danhsachUocSo += i.ToString() + " ";
                }
            }

            if (sum == n)
            {
                Console.WriteLine($"{n} la so hoan hao");
                Console.WriteLine($"{danhsachUocSo.Trim()} la danh sach cac uoc so");
            }
            else
            {
                Console.WriteLine($"{n} khong la so hoan hao");
            }

            Console.WriteLine("Bam phim bat ki de ket thuc chuong trinh");
        }
    }
}
