using System;

namespace EntryPoint
{
    public class Tree
    {
        public Node Root { get; set; }

        public Tree()
        {
            Root = null;
        }

        //Print root value first, then print the left tree and then right tree
        public void PrintPreOrder(Node node)
        {
            if (Root != null)
            {
                Console.WriteLine(Root.Value + ", ");
                PrintPreOrder(Root.Left);
                PrintPreOrder(Root.Right);
            }
        }
    }
}
