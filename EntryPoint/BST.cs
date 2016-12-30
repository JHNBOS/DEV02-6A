using EntryPoint;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class BST
    {
        public int Value;
        public BST Left;
        public BST Right;

        public BST(int value)
        {
            Value = value;
        }

        public bool Search(BST tree, int value)
        {
            //If tree equals null, tree not found
            if (tree == null)
            {
                return false;
            }

            //If tree.value equals to value, tree found
            else if (tree.Value == value)
            {
                return true;
            }

            //If tree.value is bigger than value, search in the left tree for the value
            if (tree.Value > value)
            {
                return Search(tree.Left, value);
            }

            //If tree.value is smaller than value, search in the right tree for the value
            else if (tree.Value < value)
            {
                return Search(tree.Right, value);
            }

            //If nothing found, return false;
            return false;
        }


        public void Insert(BST tree, int value)
        {
            //Check if tree is empty
            if (tree == null)
            {
                tree = new BST(value);
            }

            //If value lower than current value
            if (value < tree.Value)
            {
                //Go left
                if (tree.Left == null)
                {
                    BST newTree = new BST(value);
                    tree.Left = newTree;
                }
                else
                {
                    tree.Left.Insert(tree, value);
                }
            }

            //If value equal or higher than current value
            if (value > tree.Value)
            {
                //Go right
                if (tree.Right == null)
                {
                    BST newTree = new BST(value);
                    tree.Right = newTree;
                }
                else
                {
                    tree.Right.Insert(tree, value);
                }
            }

        }


        public void PrintPreOrder(BST tree)
        {
            if (tree != null)
            {
                Console.WriteLine(tree.Value + ", ");
                PrintPreOrder(tree.Left);
                PrintPreOrder(tree.Right);
            }
        }

    }
}
