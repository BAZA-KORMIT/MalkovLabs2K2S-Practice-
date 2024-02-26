using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
namespace PROG
{
    public class Solution
    {
        public enum OperationType
        {
            Binary,
            Logical,
            LogicalDouble,
            Unary
        }
        private readonly IDictionary<string, Expression> _operations = new Dictionary<string, Expression>
    {
        // Binary
        {"+", new BinaryExpression(1, (a, b) => a + b, OperationType.Binary)},
        {"-", new BinaryExpression(1, (a, b) => a - b, OperationType.Binary)},
        {"*", new BinaryExpression(2, (a, b) => a * b, OperationType.Binary)},
        {"/", new BinaryExpression(2, (a, b) => a / b, OperationType.Binary)},
        {"**", new BinaryExpression(3, Math.Pow, OperationType.Binary)},
        
        // Unary
        { "sin", new UnaryExpression(4, Math.Sin, OperationType.Unary) },
        { "cos", new UnaryExpression(4, Math.Cos, OperationType.Unary) },
        { "tan", new UnaryExpression(4, Math.Tan, OperationType.Unary) },
        { "cot", new UnaryExpression(4, (a) => 1 / Math.Tan(a), OperationType.Unary) },
        { "sinh", new UnaryExpression(4, Math.Sinh, OperationType.Unary) },
        { "cosh", new UnaryExpression(4, Math.Cosh, OperationType.Unary) },
        { "tanh", new UnaryExpression(4, Math.Tanh, OperationType.Unary) },
        { "e", new UnaryExpression(4, Math.Exp, OperationType.Unary) },
        { "log", new UnaryExpression(4, Math.Log, OperationType.Unary) },
        
        // Logical
        { "<", new LogicalExpression<double>(0, (a, b) => a < b, OperationType.LogicalDouble) },
        { "<=", new LogicalExpression<double>(0, (a, b) => a <= b, OperationType.LogicalDouble) },
        { ">", new LogicalExpression<double>(0, (a, b) => a > b, OperationType.LogicalDouble) },
        { ">=", new LogicalExpression<double>(0, (a, b) => a >= b, OperationType.LogicalDouble) },
        { "&&", new LogicalExpression<bool>(0, (a, b) => a && b, OperationType.Logical) },
        { "||", new LogicalExpression<bool>(0, (a, b) => a || b, OperationType.Logical) },
        { "&", new LogicalExpression<bool>(0,(a, b) => a & b, OperationType.Logical) },
        { "|", new LogicalExpression<bool>(0, (a, b) => a | b, OperationType.Logical) },
    };
        public string ConvertToPostfix(string infixExpression)
        {
            var output = new List<string>();
            var stack = new Stack<string>();
            infixExpression = infixExpression.Replace('.', ',');

            foreach (var token in Regex.Split(infixExpression, @"(\s+|\b)"))
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    continue;
                }

                if (_operations.TryGetValue(token, out var operation))
                {
                    while (stack.Count > 0 && _operations.ContainsKey(stack.Peek()) && _operations[stack.Peek()].Priority >= operation.Priority)
                    {
                        output.Add(stack.Pop());
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    string top;
                    while ((top = stack.Pop()) != "(")
                    {
                        output.Add(top);
                    }
                }
                else
                {
                    output.Add(token);
                }
            }

            while (stack.Count > 0)
            {
                output.Add(stack.Pop());
            }

            var result = output[0];
            for (var i = 1; i < output.Count; i++)
            {
                result += output[i] == "," ? output[i] :
                    output[i - 1] == "," ?
                        i == output.Count ? output[i] + " " :
                            output[i] :
                        i == output.Count ? " " + output[i] + " " :
                        " " + output[i];
            }

            return result;
        }
        public string BuildTree(string infix)
        {
            var postfix = ConvertToPostfix(infix);
            return BuildExpressionTree(postfix).ToString();
        }

        private ExpressionNode BuildExpressionTree(string postfixExpression)
        {
            var stack = new Stack<ExpressionNode>();

            foreach (var token in postfixExpression.Split(' '))
            {
                if (_operations.ContainsKey(token))
                {
                    var operationNode = new ExpressionNode(token);
                    operationNode.Right = stack.Pop();
                    if (stack.Count != 0)
                    {
                        operationNode.Left = stack.Pop();
                    }
                    stack.Push(operationNode);
                }
                else
                {
                    stack.Push(new ExpressionNode(token));
                }
            }

            return stack.Pop();
        }
    }
    public class Programm
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Введите выражение");
                var s = new Solution();
                var str = Console.ReadLine();
                var RPN = s.ConvertToPostfix(str);
                Console.WriteLine("Обратная польская(постфиксная) запись:");
                Console.WriteLine(RPN);
                Console.WriteLine("Представление выражения в виде графа:");
                var graph = s.BuildTree(str);
                Console.WriteLine(graph);
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка");
            }
        }

    }
}
