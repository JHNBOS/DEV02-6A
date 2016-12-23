using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Path
    {
        public Vector2 VertexA;
        public Vector2 VertexB;
        public float Weight;

        public Path(Vector2 VertexA, Vector2 VertexB, float weight)
        {
            this.VertexA = VertexA;
            this.VertexB = VertexB;
            this.Weight = weight;
        }
    }
}
