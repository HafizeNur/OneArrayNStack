using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneArrayNStack
{
    class Program
    {
        public class MyStack
        {
            private int[] myArray;
            private int[] top;
            private int[] next;
            private int free;

            public MyStack(int stackNumber, int stackSize)
            {

                myArray = new int[stackSize];
                top = new int[stackNumber];
                next = new int[stackSize];

                for (int i = 0; i < stackNumber; i++)
                {
                    top[i] = -1;
                }
                free = 0;
                for (int i = 0; i < stackSize - 1; i++)
                {
                    next[i] = i + 1;
                }
                next[stackSize - 1] = -1;
            }
            public virtual bool Full
            {
                get
                {
                    return (free == -1);
                }
            }
            public virtual void push(int item, int sn)
            {
                if (Full)
                {
                    Console.WriteLine("Stack dolu");
                    return;
                }

                int i = free;

                free = next[i];

                next[i] = top[sn];
                top[sn] = i;

                myArray[i] = item;
            }
            public virtual int pop(int sn)
            {
                if (isEmpty(sn))
                {
                    Console.WriteLine("Stack bos");
                    return int.MaxValue;
                }

                int i = top[sn];

                top[sn] = next[i];

                next[i] = free;
                free = i;

                return myArray[i];
            }

            public virtual bool isEmpty(int sn)
            {
                return (top[sn] == -1);
            }

        }

        static void Main(string[] args)
        {
            MyStack stack = new MyStack(3, 20);
            stack.push(10, 0);
            stack.push(8, 1);
            stack.push(5, 2);

            Console.WriteLine("Popped element from stack 2 is " + stack.pop(2));
            Console.WriteLine("Popped element from stack 1 is " + stack.pop(1));
            Console.WriteLine("Popped element from stack 0 is " + stack.pop(0));
            Console.ReadKey();
        }
    }
}
