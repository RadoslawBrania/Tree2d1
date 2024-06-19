// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using tree2d;
using static tree2d.Tree2Danother;
//RangeTree tree = new RangeTree();
//tree.Insert(10);
//tree.Insert(5);
//tree.Insert(15);
//tree.Insert(3);
//tree.Insert(7);
//tree.Insert(12);
//tree.Insert(17);

//Console.WriteLine("Displaying the range tree:");
//tree.Display();
//Console.WriteLine();

//int min = 5;
//int max = 15;
//Console.WriteLine($"Values in range [{min}, {max}]:");
//var result = tree.SearchRange(min, max);
//foreach (var value in result)
//{
//    Console.Write(value + " ");
//}
//Console.WriteLine(Math.Ceiling((double)(1+2) / 2));

public class Point(int x, int y)
{
    public int X=x; public int Y=y;

}

public class TreeNode
{
    public Point Value;
    public TreeNode Left;
    public TreeNode Right;
    public Tree1D Top;
    public TreeNode(int x, int y)
    {
        Value = new(x,y);
        Left = null;
        Right = null;
    }
}

public class Tree1D
{
   
    public TreeNode Root { get; private set; }
    public TreeNode Root2 { get; private set; }

    public Tree1D(Point[] arr, bool mode)
    {
        if (mode == true)
        {
            Root = BuildTree(0, arr.Length-1,arr);
        }
        else Root = BuildTop(0, arr.Length-1, arr );     }

    private TreeNode BuildTree(int start, int end, Point[] _arr)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        TreeNode node = new TreeNode(_arr[mid].X, _arr[mid].Y);

        node.Left = BuildTree(start, mid - 1,_arr);
        node.Right = BuildTree(mid + 1, end,_arr);
        node.Top = new(Tree1D.Rearray(start, end, _arr), false);
        return node;
    }
    private static Point[] Rearray(int start, int end, Point[] _arr)
    {
        Point[] arr = [];
        for(int i = start; i < end; i++)
        {
            arr.Append(_arr[i]);
        }
        arr.OrderBy (x => x.Y);
        return arr;
    }
    private TreeNode? BuildTop(int start, int end, Point[] _arr)
    {
        if (start > end)
            return null;
        int mid = (start + end) / 2;
        TreeNode node = new(_arr[mid].X, _arr[mid].Y)
        {
            Left = BuildTree(start, mid - 1, _arr),
            Right = BuildTree(mid + 1, end, _arr)
        };
        return node;
    }
    // rln - just went right/left/none 0/1/2
    private void SearchRange1X(Point min, Point max, TreeNode node, Point[] retarr, int rln = 2)
    {
        if (max.X > node.Value.X) SearchRange1X(min, max, node.Left, retarr, 1);
        else if (min.X < node.Value.X) SearchRange1X(min,max,node.Right, retarr, 0);
        else
        {
            if (rln == 0) { 
                AddSubtree(retarr, node.Left);
                SearchRange1X(min, max, node.Right, retarr, 0);
            }
            else if (rln == 1)
            {
                AddSubtree(retarr, node.Right);
                SearchRange1X(min, max, node.Left, retarr, 1);
            };
        }
    }
    private void AddSubtree(Point[] retarr, TreeNode node)
    {
        if (node != null) {
            retarr.Append(node.Value);
            AddSubtree(retarr, node.Left);
            AddSubtree(retarr, node.Right);
        }
    }
    public void Display(int i = 0)
    {
       if (i==0) Display(Root, 0);
       else Display(Root2,0);
    }

    public void DisplaySubtree()
    {

    }

    private void Display(TreeNode node, int depth)
    {
        if (node != null)
        {
            Display(node.Right, depth + 1);
            Console.WriteLine($"{new string(' ', depth * 4)}{node.Value.X},{node.Value.Y}");
            Display(node.Left, depth + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point[] arr = { new(1, 2), new(3, 4),new(5, 6), new(7, 8), new(9,10) ,new(12,11) };
        Tree1D tree = new Tree1D(arr,true); 

        // Testowanie drzewa
        tree.Display(1);
    }

    static void Traverse(TreeNode node)
    {
        if (node == null)
            return;

        Console.WriteLine(node.Value);
        Traverse(node.Left);
        Traverse(node.Right);
    }
}