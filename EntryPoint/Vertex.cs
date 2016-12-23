using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Vertex
    {
        public string Name;
        public float X;
        public float Y;
        public bool Visited;

        public Vertex(string name, float x, float y, bool visited)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Visited = visited;
        }
    }
}
