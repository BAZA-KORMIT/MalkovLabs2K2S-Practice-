using System;
using System.Collections;
using System.Collections.Generic;
namespace PROG
{
    public class Solution
    {
        Dictionary<char, int> prio = new Dictionary<char, int>();

        public Node expTree(string s)
        {
            prio.Add('(', 1);
            prio.Add('+', 2);
            prio.Add('-', 2);
            prio.Add('*', 3);
            prio.Add('/', 3);

            Stack<char> ops = new Stack<char>();
            Stack<Node> stack = new Stack<Node>();

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '(')
                {
                    ops.Push(ch);
                }
                else if (char.IsDigit(ch) || char.IsLetter(ch))
                {
                    stack.Push(new Node(ch));
                }
                else if (ch == ')')
                {
                    while (ops.Peek() != '(')
                    {
                        Combine(ops, stack);
                    }
                    ops.Pop();
                }
                else
                {
                    while (ops.Count > 0 && prio[ops.Peek()] >= prio[ch])
                    {
                        Combine(ops, stack);
                    }
                    ops.Push(ch);
                }
            }

            while (stack.Count > 1)
            {
                Combine(ops, stack);
            }

            return stack.Peek();
        }

        private void Combine(Stack<char> ops, Stack<Node> stack)
        {
            Node root = new Node(ops.Pop());
            // right first, then left
            root.right = stack.Pop();
            root.left = stack.Pop();
            stack.Push(root);
        }
    }

    public class Node
    {
        public char val;
        public Node left, right;

        public Node(char val)
        {
            this.val = val;
        }
    }
    public class Programm
    {
        static void Main()
        {
            Solution s = new Solution();
            string input = "y*x+x*2";
            Node result = s.expTree(input);

            Console.WriteLine("Preorder traversal:");
            PrintPreorder(result);
            Console.WriteLine();

            Console.WriteLine("Inorder traversal:");
            PrintInorder(result);
            Console.WriteLine();
        }
        public static void PrintPreorder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.val + " ");
                PrintPreorder(node.left);
                PrintPreorder(node.right);
            }
        }

        public static void PrintInorder(Node node)
        {
            if (node != null)
            {
                PrintInorder(node.left);
                Console.Write(node.val + " ");
                PrintInorder(node.right);
            }
        }

    }
}
