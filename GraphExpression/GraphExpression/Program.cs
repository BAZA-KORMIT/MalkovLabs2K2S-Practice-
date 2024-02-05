namespace PROG
{
    class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    class GraphExpression
    {
        public Node Root { get; set; }

        public GraphExpression(string expression)
        {
            Root = ParseExpression(expression);
        }

        private Node ParseExpression(string expression)
        {
            string[] tokens = expression.Split(' ');
            Stack<Node> stack = new Stack<Node>();

            foreach (string token in tokens)
            {
                if (token == "+" || token == "*" || token == "/")
                {
                    Node newNode = new Node(token);
                    newNode.Right = stack.Pop();
                    newNode.Left = stack.Pop();
                    stack.Push(newNode);
                }
                else
                {
                    stack.Push(new Node(token));
                }
            }

            return stack.Pop();
        }
    }
    class Programm
    {       
            static void Main()
            {
                string expression = "a + b * c";
                GraphExpression graphExpression = new GraphExpression(expression);

                PrintGraph(graphExpression.Root);
            }

            static void PrintGraph(Node node, int depth = 0)
            {
                if (node == null) return;

                PrintGraph(node.Right, depth + 1);
                Console.WriteLine(new string(' ', depth * 4) + node.Value);
                PrintGraph(node.Left, depth + 1);
            }
    }

}
