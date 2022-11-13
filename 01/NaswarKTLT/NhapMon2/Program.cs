using System;

namespace NhapMon2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 01
            //bool check = !true;
            //int n = 10;
            //Console.WriteLine("n=: ", n);
            //if (!check)
            //{
            //    n = n >= 10 ? 5 : 3;
            //}
            //n += n;
            //Console.WriteLine("n=: {0}", n);
            //10
            #endregion

            #region 02
            //bool check = !true;
            //int n = 10;
            //Console.WriteLine("n=: ", n);
            //if (!check)
            //{
            //    n = n >= 10 ? 2 : 3;
            //}
            //n += n;// n = n+ n
            //Console.WriteLine("n=: {0}", n);
            //4

            #endregion

            #region 03
            //bool check = !true;
            //int n = 10;
            //Console.WriteLine("n=: ", n);
            //if (!check)
            //{
            //    //n = n >= 10 ? 2 : 3;
            //    if(n >= 10)
            //    {
            //        n = 2;
            //    }else
            //    {
            //        n = 3;
            //    }    
            //}
            //else
            //{
            //    n = 1;
            //}    
            //n += n;// n = n+ n
            //Console.WriteLine("n=: {0}", n);
            //4
            #endregion

            #region 04
            //bool check = !true;
            //double n = 10;
            //n *= Math.PI;
            //if (!check)
            //{
            //    if (n <= 2)
            //    {
            //        n = 2;
            //    }
            //    else
            //    {
            //        n = 3;
            //    }
            //}
            //else if(!check && n < Math.PI)
            //{
            //    n = Math.PI;
            //}    
            //else
            //{
            //    n = 1;
            //}
            //n += n;// n = n+ n
            //Console.WriteLine("n=: {0}", n);
            //6
            #endregion

            #region 05
            bool check = !true;
            double n = 10;
            n *= Math.PI;
            if (check)
            {
                if (n <= 2)
                {
                    n = 2;
                }
                else
                {
                    n = 3;
                }
            }
            else if (!check && n < Math.PI)
            {
                n = Math.PI;
            }
            else
            {
                n = 1;
            }
            n += n;// n = n+ n
            Console.WriteLine("n=: {0}", n);
            //2
            #endregion
        }
    }
}
