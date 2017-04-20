using Microsoft.Xna.Framework;

namespace EntryPoint
{
    public class Vertex
    {
        public Vector2 Value { get; set; }
        public Vertex Previous { get; set; }

        public Vertex()
        {
            Previous = null;
        }

        public Vertex(Vector2 value)
        {
            this.Value = value;
        }
    }
}
