using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
    public class Node
    {
        public Vector2 Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
            Left = null;
            Right = null;
        }

        public Node(Vector2 Value)
        {
            this.Value = Value;
            Left = null;
            Right = null;
        }

        //METHOD TO INSERT Value
        public void Insert(Vector2 value, bool isVertical = true)
        {
            //Check if value is null
            if (Value == null)
            {
                Value = value;
            }
            else
            {
                bool left = false;
                Node current = new Node(value);

                //If vertical is true, check the x value
                //Else, check the y value
                if (isVertical)
                {
                    if (value.X < Value.X)
                    {
                        left = true;
                    }
                    else if (value.Y < Value.Y)
                    {
                        left = false;
                    }
                }

                //Go Left
                if (left)
                {
                    if (Left == null)
                    {
                        Left = current;
                    }
                    else
                    {
                        Left.Insert(current.Value);
                    }
                }
                //Go Right
                else if (!left)
                {
                    if (Right == null)
                    {
                        Right = current;
                    }
                    else
                    {
                        Right.Insert(current.Value);
                    }
                }

            }
        }

        public bool Search(Node node, bool isVertical = true)
        {
            //If value equals null, nothing is found
            if (node == null)
            {
                return false;
            }
            //Check if value equals Value
            else if (node.Value == Value)
            {
                return true;
            }
            //If value is not null and is not equal to Value
            //search value
            else
            {
                bool left = false;

                if (isVertical)
                {
                    if (node.Value.X < Value.X)
                    {
                        left = true;
                    }
                    else if (node.Value.Y < Value.Y)
                    {
                        left = false;
                    }
                }

                //Go Left
                if (left)
                {
                    return Search(Left);
                }
                //Go Right
                else
                {
                    return Search(Right);
                }

            }
        }

        public List<Vector2> RangeSearch(Node Source, float radius, List<Vector2> Points)
        {
            List<Vector2> buildingsWithinRange = new List<Vector2>();

            if (Value == null)
            {
                return buildingsWithinRange;
            }

            //Get outermost points of radius from the source node
            //X and Y coordinates from source node
            float X = Source.Value.X;
            float Y = Source.Value.Y;

            //Limits of the rectangle
            float leftBorder = (X - radius);
            float rightBorder = (X + radius);
            float topBorder = (Y + radius);
            float bottomBorder = (Y - radius);

            //Sort list by x value
            Points.OrderBy(p => p.X);

            //Check which points in the list are within radius of the source
            foreach (var vector in Points)
            {
                //Check if the vector in the list is between the outmost XY values
                if ((vector.X >= leftBorder && vector.X <= rightBorder)
                    && (vector.Y >= bottomBorder && vector.Y <= topBorder))
                {

                    float distance = Vector2.Distance(vector, Source.Value);

                    //Euclidean check
                    if (distance <= radius)
                    {
                        buildingsWithinRange.Add(vector);
                    }
                }
            }

            return buildingsWithinRange;
        }



    }
}
