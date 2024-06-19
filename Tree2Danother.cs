using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tree2d
{
    internal class Tree2Danother
    {
        public class Node
        {
            public int Value;
            public Node? Left;
            public Node? Right;
                 public Node()
            {
            }
            public Node(int value)
            {
                Value = value;
            }
            public Node CreateTree(int[] arr, int start, int end)
            {
                if (arr[(start + end) / 2] != null)
                {
                    Node a = new(arr[(start + end) / 2]);
                    Console.WriteLine(a.Value);
                    if (start != end) Left = a.CreateTree(arr, start, (start + end) / 2);
                    if (start != end) Right = a.CreateTree(arr, (start + end) / 2 + 1, end);

                    return a;
                }
                return null;
            }
            public Node getLeft()
            {
                return this.Left;
            }
            public void getValue()
            {
                Console.WriteLine(this.Value);
            }
        }
        public Node getRoot()
        {
            return root;
        }
        private Node root;
        public Tree2Danother(int[] arr, int start, int end)
        {
            root = new();
            root = root.CreateTree(arr,start,end);
        }
        public void Display()
        {
            Display(root, 0);
        }
       

        private void Display(Node node, int depth)
        {
            if (node != null)
            {
                Display(node.Right, depth + 1);
                Console.WriteLine($"{new string(' ', depth * 4)}{node.Value}");
                Display(node.Left, depth + 1);
            }
        }

    }
}
