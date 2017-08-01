using YAGLi.Interfaces;

namespace YAGLi.Tests.Utils
{
    public class Edge<TVertex> : IModelAnEdge<TVertex>
    {
        public Edge(TVertex end1, TVertex end2)
        {
            End1 = end1;
            End2 = end2;
        }

        public TVertex End1 { get; }

        public TVertex End2 { get; }

        public override string ToString()
        {
            return $"{{ {End1}, {End2} }}";
        }
    }
}
