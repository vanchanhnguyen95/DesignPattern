using System;

namespace NhapMon3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine("i++, ++i");
            Console.WriteLine("i++: sau khi xong hàm gọi nó thì mới cộng thêm 1 đơn vị");
            Console.WriteLine("++i: công thêm 1 đơn vị ngay tại lúc đó luôn");
            if (i == 0)
            {
                Console.WriteLine(++i);
            } else if(i == 1)
            {
                Console.WriteLine(i++);
            }
            else if (i == 2)
            {
                Console.WriteLine(--i);
            }
            else
            {
                Console.WriteLine(i--);
            }
            int j = 0, k = 0;
            int a = 10 + j++;
            int b = 10 + ++k;
            Console.WriteLine("int a = 10 + j++; = {0}", a);
            Console.WriteLine(" int b = 10 + ++k; = {0}", b);
            //0
        }
    }
}
