using System;
using System.Text;

namespace PRST
{
	public class TreeNode
	{
        public string Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            ToStringHelper(this, result, "", "");

            return result.ToString();
        }

        private void ToStringHelper(TreeNode? node, StringBuilder? result, string prefix, string childrenPrefix)
        {
            if (node == null)
                return;

            result?.AppendLine($"{prefix}{node.Value}");

            if (node.Left != null || node.Right != null)
            {
                ToStringHelper(node.Left, result, $"{childrenPrefix}├─ ", $"{childrenPrefix}│  ");
                ToStringHelper(node.Right, result, $"{childrenPrefix}└─ ", $"{childrenPrefix}   ");
            }
        }
    }
}

