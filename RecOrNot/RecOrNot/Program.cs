using System;

namespace P
{
    class Prog
    {
        public static int FibonachiREC(int n)
        {
            return (n < 2) ? n : FibonachiREC(n - 1) + FibonachiREC(n - 2);
        }
        public static int FibonachiSTACK(int n)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 1; i < n; i++)
            {
                int first = stack.Pop();
                int second = stack.Pop();
                stack.Push(first);
                stack.Push(first + second);
            }
            return stack.Pop();
        }

        public static int sumOfArrayREC(int[] a, int n)
        {
            return (n == 0) ? a[n] : a[n] + sumOfArrayREC(a, n - 1);
        }

        public static int sumOfArraySTACK(int[] a, int n)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (i == 0) stack.Push(a[i]);
                else
                    stack.Push(stack.Peek() + a[i]);
            }
            return stack.Pop();
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    (array[pivot], array[i]) = (array[i], array[pivot]);
                }
            }
            pivot++;
            (array[pivot], array[maxIndex]) = (array[maxIndex], array[pivot]);
            return pivot;
        }

        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }
            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSortREC(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        public static void QuickSortSTACK(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(left);
            stack.Push(right);

            while (stack.Count > 0)
            {
                right = stack.Pop();
                left = stack.Pop();

                int pivotIndex = PartitionSTACK(arr, left, right);

                if (pivotIndex - 1 > left)
                {
                    stack.Push(left);
                    stack.Push(pivotIndex - 1);
                }

                if (pivotIndex + 1 < right)
                {
                    stack.Push(pivotIndex + 1);
                    stack.Push(right);
                }
            }
        }

        private static int PartitionSTACK(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);

            return i + 1;
        }
        static void Main()
        {
            Console.WriteLine(FibonachiREC(10));
            Console.WriteLine(FibonachiSTACK(10));
            int[] a = { 1, 2, 3, 4, 5 };
            Console.WriteLine(sumOfArrayREC(a, a.Length - 1));
            Console.WriteLine(sumOfArraySTACK(a, a.Length));
            int[] b = { 5, 4, 65676, 34, 12, 67, 9, 1, 2 };
            foreach (int i in b)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            QuickSortREC(b);
            foreach (int i in b)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            int[] cb = { 5, 4, 65676, 34, 12, 67, 9, 1, 2 };
            foreach (int i in cb)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            QuickSortSTACK(cb, 0, cb.Length - 1);
            foreach (int i in cb)
            {
                Console.Write(i + " ");
            }

        }
    }
}