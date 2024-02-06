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
            return (n==0)? a[n] : a[n]+sumOfArrayREC(a, n - 1);
        }

        public static int sumOfArraySTACK(int[] a,int n)
        {
            Stack<int> stack =new Stack<int>();
            for(int i = 0;i < n; i++)
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
        static void QuicksortSTACK(int[] array)
        {

        }
        static void Main()
        {
            Console.WriteLine(FibonachiREC(10));
            Console.WriteLine(FibonachiSTACK(10));
            int[] a = { 1, 2, 3, 4, 5 };
            Console.WriteLine(sumOfArrayREC(a, a.Length - 1));
            Console.WriteLine(sumOfArraySTACK(a, a.Length));
            int[] b= { 5,4,65676,34,12,67,9,1,2};
            foreach (int i in b)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            QuickSortREC(b);
            foreach(int i in b)
            {
                Console.Write(i+" ");
            }

        }
        
    }
}