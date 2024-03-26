using System;
using System.Linq;

namespace PRST;

class Program
{
    public static int[] sequence = { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
    static void Main()
    {
        int height=GetHeight();
        Console.WriteLine(Build(SortedArrayToPRST(sequence,0,sequence.Length-1)));
        Console.WriteLine($"Высота: {height}");
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

    public static int GetHeight()
    {
        return GetHeightHelper(SortedArrayToPRST(sequence, 0, sequence.Length - 1));
    }

    private static int GetHeightHelper(TreeNode? node)
    {
        if (node == null)
            return 0;

        int leftHeight = GetHeightHelper(node.Left);
        int rightHeight = GetHeightHelper(node.Right);

        return 1 + Math.Max(leftHeight, rightHeight);
    }

}