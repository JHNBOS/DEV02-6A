using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Graph
    {
        public Dictionary<Vector2, Dictionary<Vector2, int>> Vertices;

        private Graph()
        {
            Vertices = new Dictionary<Vector2, Dictionary<Vector2, int>>();
        }

        public Graph(List<Tuple<Vector2, Vector2>> roads, Vector2 startPoint, Vector2 endPoint)
        {
            //Add start vertex
            AddVertex(startPoint);

            for (int i = 0; i < roads.Count; i++)
            {
                Vector2 firstVertex = roads[i].Item1;
                Vector2 secondVertex = roads[i].Item2;
                AddVertex(firstVertex);
                AddVertex(secondVertex);
            }
            
            //Add end vertex
            AddVertex(endPoint);

            //Add road
            for (int i = 0; i < roads.Count(); i++)
            {
                Vector2 firstVertex = roads[i].Item1;
                Vector2 secondVertex = roads[i].Item2;
                int distance = (int) Vector2.Distance(firstVertex, secondVertex);

                AddRoad(firstVertex, secondVertex, distance);
            }
        }

        public void AddVertex(Vector2 Vertex)
        {
            //If vertex is not yet in the list, then add it
            if (!Vertices.ContainsKey(Vertex))
            {
                Dictionary<Vector2, int> emptyroads = new Dictionary<Vector2, int>();
                Vertices[Vertex] = emptyroads;
            }
        }

        public void AddRoad(Vector2 roadPoint1, Vector2 roadPoint2, int length)
        {
            if (!Vertices[roadPoint1].ContainsKey(roadPoint2))
            {
                Vertices[roadPoint1].Add(roadPoint2, length);
            }
            if (!Vertices[roadPoint2].ContainsKey(roadPoint1))
            {
                Vertices[roadPoint2].Add(roadPoint1, length);
            }
        }

        public List<Tuple<Vector2, Vector2>> ShortestPath(Vector2 startPoint, Vector2 endPoint)
        {
            Dictionary<Vector2, Vector2> previous = new Dictionary<Vector2, Vector2>();
            Dictionary<Vector2, int> distances = new Dictionary<Vector2, int>();
            List<Vector2> vertexList = new List<Vector2>();

            List<Tuple<Vector2, Vector2>> path = null;

            foreach (var v in Vertices)
            {
                //Set distance start vertex to 0 
                if (v.Key == startPoint)
                    distances[v.Key] = 0;
                else
                    distances[v.Key] = int.MaxValue;
                vertexList.Add(v.Key);
            }

            while (vertexList.Any())
            {
                //Sort the list
                vertexList.Sort((x, y) => distances[x] - distances[y]);
                var smallest = vertexList[0];

                vertexList.Remove(smallest);

                if (smallest == endPoint)
                {
                    path = new List<Tuple<Vector2, Vector2>>();

                    while (previous.ContainsKey(smallest))
                    {
                        var pair = new Tuple<Vector2, Vector2>(smallest, previous[smallest]);
                        path.Add(pair);
                        smallest = previous[smallest];
                    }

                    path.Reverse();
                    break;
                }

                if (distances[smallest] == int.MaxValue) { break; }

                foreach (var neighbour in Vertices[smallest])
                {
                    var totalDistance = distances[smallest] + neighbour.Value;

                    if (totalDistance < distances[neighbour.Key])
                    {
                        distances[neighbour.Key] = totalDistance;
                        previous[neighbour.Key] = smallest;
                    }
                }
            }
            return path;
        }



    }
}