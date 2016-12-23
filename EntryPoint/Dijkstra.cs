using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Dijkstra
    {
        public Graph Graph;
        public Vertex Source;

        public Dijkstra(Graph g, Vertex v)
        {
            this.Graph = g;
            this.Source = v;
        }

        public void Calculate()
        {
            List<Vertex> unvisited = new List<Vertex>();

            foreach (var v in this.Graph.Vertices)
            {
                unvisited.Add(v);
            }
        }
      
    }
}
