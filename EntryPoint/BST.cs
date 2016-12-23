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
        public int Value { get; set; }
        public BST Left { get; set; }
        public BST Right { get; set; }

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


        public BST Insert(BST tree, int value)
        {
            //Check if tree is empty
            if (tree == null)
            {
                Insert(tree, value);
            }

            //If value lower than current value
            if (value < tree.Value)
            {
                //Go left
                if (tree.Left == null)
                {
                    BST newTree = new BST();
                    newTree.Value = value;
                    tree.Left = newTree;

                    return newTree;
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
                    BST newTree = new BST();
                    newTree.Value = value;
                    tree.Right = newTree;

                    return newTree;
                }
                else
                {
                    tree.Right.Insert(tree, value);
                }
            }

            return tree;

        }



    }
}
