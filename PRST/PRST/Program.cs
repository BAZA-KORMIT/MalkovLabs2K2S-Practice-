using System;
using System.Linq;

namespace PRST;

class Program
{
    public static int[] sequence = { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
    static void Main()
    {
       
        Console.WriteLine(Build(SortedArrayToPRST(sequence,0,sequence.Length-1)));
    }

    // Algorithm for converting to an ideal search tree (eng for git)
    public static TreeNode SortedArrayToPRST(int[] sequence, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        TreeNode tree = new(sequence[mid].ToString())
        {
            Left = SortedArrayToPRST(sequence, start, mid - 1),
            Right = SortedArrayToPRST(sequence, mid + 1, end)
        };

        return tree;
    }
    public static string Build(TreeNode tree)
    {
        return SortedArrayToPRST(sequence,0,sequence.Length-1).ToString();
    }
}