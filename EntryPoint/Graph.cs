using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Graph
    {
        public List<Vertex> Vertices;
        public List<Path> Paths;

        public Graph(List<Vertex> Vertices, List<Path> Paths)
        {
            this.Vertices = Vertices;
            this.Paths = Paths;
        }



    }
}
