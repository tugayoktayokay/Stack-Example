using System;

namespace Implement_3_Stacks_Single_Array
{
    class Program
    {
        public class StackArray
        {
            public int[] arr;
            public int[] top;
            public int[] next;
            public int nArray;
            public int kStack;
            public int free;

            public StackArray(int n)
            {
                kStack = 3;
                nArray = n;
                arr = new int[n];
                top = new int[kStack];
                next = new int[n];

                for (int i = 0; i < kStack; i++)
                {
                    top[i] = -1;
                }
                free = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    next[i] = i + 1;
                }
                next[n - 1] = -1;
            }
            public virtual bool Full
            {
                get
                {
                    return (free == -1);
                }
            }
            public virtual void Push(int item, int sn)
            {
                if (Full)
                {
                    Console.WriteLine("Stack Dolu");
                    return;
                }
                int i = free;
                free = next[i];
                next[i] = top[sn];
                top[sn] = i;
                arr[i] = item;
            }
            public virtual int Pop(int sn)
            {
                if (İsEmpty(sn))
                {
                    Console.WriteLine("Stack Boş!");
                    return int.MaxValue;
                }

                int i = top[sn];

                top[sn] = next[i];

                next[i] = free;
                free = i;

                return arr[i];
            }
 
            public virtual bool İsEmpty(int sn)
            {
                return (top[sn] == -1);
            }

        }
        public static void Main()
        {
            StackArray ks = new StackArray(1);

            ks.Push(15, 2);

            ks.Push(17, 1);
          
            ks.Push(7, 0);

            Console.WriteLine("Diziye Başarı ile Yerleştirilen Stack Sayısı " + ks.top.Length);

            Console.ReadLine();
        }
    }
}