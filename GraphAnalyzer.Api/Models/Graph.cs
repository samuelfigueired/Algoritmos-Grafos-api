namespace GraphAnalyzer.Api.Models
{
    public class Graph
    {
        public int Vertices { get; set; }
        public List<Edge> Edges { get; set; } = new();
    }

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }
}
