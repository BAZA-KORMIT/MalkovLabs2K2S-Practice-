using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG.Solution;

namespace PROG;

abstract class Expression
{
    public int Priority;
    public OperationType Type;

    public Expression(
        int priority,
        OperationType type)
    {
        Priority = priority;
        Type = type;
    }
}

class BinaryExpression : Expression
{
    public Func<double, double, double>? Method;

    public BinaryExpression(int priority,
        Func<double, double, double>? binaryMethod,
        OperationType type
        ) : base(priority, type)
    {
        Priority = priority;
        Type = type;
        Method = binaryMethod;
    }
}

class UnaryExpression : Expression
{
    public Func<double, double>? Method;

    public UnaryExpression(int priority,
        Func<double, double>? unaryMethod,
        OperationType type
    ) : base(priority, type)
    {
        Priority = priority;
        Type = type;
        Method = unaryMethod;
    }
}

class LogicalExpression<T> : Expression
{
    public Func<T, T, bool>? Method;

    public LogicalExpression(int priority,
        Func<T, T, bool>? logicalMethod,
        OperationType type
    ) : base(priority, type)
    {
        Priority = priority;
        Type = type;
        Method = logicalMethod;
    }
}
