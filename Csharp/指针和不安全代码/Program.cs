using System;

namespace 指针和不安全代码
{
    class Program
    {
        static void Main(string[] args)
        {
            test1();
        }

        static unsafe void BlueFilter(int[,] bitmap)
        {
            int length = bitmap.Length;
            fixed (int* b = bitmap)
            {
                int* p = b;
                for (int i = 0; i < length; i++)
                {
                    *p++ &= 0xFF;
                }
            }


        }

        static unsafe void test1()
        {
            int* a = stackalloc int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
