﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class _2DTree
    {
        public Vector2 Value { get; set; }
        public _2DTree Left { get; set; }
        public _2DTree Right { get; set; }


        public void Insert(Vector2 value, bool isVertical = true)
        {
            //Check if Value is null
            if (Value == new Vector2(0, 0))
            {
                Value = value;
            }
            else
            {
                bool left = false;
                _2DTree current = new _2DTree();
                current.Value = value;

                //If vertical is true, check the x value
                if (isVertical)
                {
                    if (value.X < Value.X)
                    {
                        left = true;
                    }
                    else if(value.Y < Value.Y)
                    {
                        left = false;
                    }
                }

                //If left boolean is true, assign current to Left 2DTree,
                //else assign current to Right 2DTree
                if (left)
                {
                    current = Left;
                }
                else if(!left)
                {
                    current = Right;
                }

                //Insert value to 2DTree
                //current.Insert(value, !isVertical);
            }
        }

        public bool Search(Vector2 value, bool isVertical = true)
        {
            //If value equals null, nothing is found
            if (value == null)
            {
                return false;
            }

            //Check if value equals Value
            else if (value == Value)
            {
                return true;
            }

            //If value is not null and is not equal to Value
            //search value
            else
            {
                bool left = false;
                _2DTree current;

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

                //If left boolean is true, assign current to Left 2DTree,
                //else assign current to Right 2DTree
                if (left)
                {
                    current = Left;
                }
                else
                {
                    current = Right;
                }

                //Search for value
                current.Search(value, !isVertical);
            }

            //If nothing found, return false
            return false;
        }


        public List<Vector2> RangeSearch(Vector2 Source, float radius, List<Vector2> Points)
        {
            List<Vector2> buildingsWithinRange = new List<Vector2>();

            //Get outermost points of radius from the source node
            //X and Y coordinates from source node
            float X = Source.X;
            float Y = Source.Y;

            Console.WriteLine("X=" + X);
            Console.WriteLine("Y=" + Y);

            //Limits of the rectangle
            float leftBorder = (X - radius);
            float rightBorder = (X + radius);
            float topBorder = (Y + radius);
            float bottomBorder = (Y - radius);

            Console.WriteLine("Left=" + leftBorder);
            Console.WriteLine("Right=" + rightBorder);
            Console.WriteLine("Top=" + topBorder);
            Console.WriteLine("Bottom=" + bottomBorder);

            //Check which points in the list are within radius of the source
            foreach (var vector in Points)
            {
                //Check if the vector in the list is between the outmost X values
                //(top and bottom are the same X value)
                if (vector.X >= leftBorder && vector.X <= rightBorder)
                {
                    //Check if the vector in the list is between the outmost Y values
                    //(top twoare the same y as the bottom two are the same)
                    if (vector.Y >= bottomBorder && vector.Y <= topBorder)
                    {
                        float distance = Vector2.Distance(vector, Source);

                        if (distance < radius)
                        {
                            Console.WriteLine("Distance=" + Vector2.Distance(vector, Source));
                            Console.WriteLine("Special Building[" + vector.X + ", " + vector.Y + "]");
                            buildingsWithinRange.Add(vector);
                        }
                        
                    }
                }
            }


            return buildingsWithinRange;
        }



    }
}