using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Dijkstra
    {
        public Graph Graph;

        public Dijkstra(Graph graph)
        {
            this.Graph = graph;
        }

        public List<Vertex> CalculateShortestPath(Vertex toEdge)
        {
            List<Vertex> Vertices = new List<Vertex>();

            while (toEdge.Previous != null)
            {
                Vertices.Insert(0, toEdge);
                toEdge = toEdge.Previous;
            }

            Vertices.Insert(0, toEdge);

            return Vertices;
        }

    }
}
