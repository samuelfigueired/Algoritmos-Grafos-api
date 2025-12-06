using GraphAnalyzer.Api.Models;

namespace GraphAnalyzer.Api.Services
{
    public class GraphService
    {
        // Constrói lista de adjacência a partir da lista de arestas enviada pelo usuário
        private List<List<(int to, int weight)>> BuildAdjacencyList(Graph graph)
        {
            var adj = new List<List<(int, int)>>();

            for (int i = 0; i < graph.Vertices; i++)
                adj.Add(new List<(int, int)>());

            foreach (var edge in graph.Edges)
            {
                adj[edge.From].Add((edge.To, edge.Weight));
                adj[edge.To].Add((edge.From, edge.Weight)); // grafo NÃO direcionado
            }

            return adj;
        }

        // BFS
        public List<int> BFS(Graph graph, int start)
        {
            var adj = BuildAdjacencyList(graph);
            var visited = new bool[graph.Vertices];
            var queue = new Queue<int>();
            var result = new List<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                result.Add(u);

                foreach (var (v, _) in adj[u])
                {
                    if (!visited[v])
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }

            return result;
        }

        // DFS
        public List<int> DFS(Graph graph, int start)
        {
            var adj = BuildAdjacencyList(graph);
            var visited = new bool[graph.Vertices];
            var result = new List<int>();

            void Explore(int u)
            {
                visited[u] = true;
                result.Add(u);

                foreach (var (v, _) in adj[u])
                {
                    if (!visited[v])
                        Explore(v);
                }
            }

            Explore(start);
            return result;
        }

        // DIJKSTRA
        public int[] Dijkstra(Graph graph, int start)
        {
            var adj = BuildAdjacencyList(graph);
            int n = graph.Vertices;

            var dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
            dist[start] = 0;

            var pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();

                foreach (var (v, weight) in adj[u])
                {
                    int newDist = dist[u] + weight;

                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        pq.Enqueue(v, newDist);
                    }
                }
            }

            return dist;
        }

        // PRIM (Árvore Geradora Mínima)
        public List<(int from, int to, int weight)> Prim(Graph graph)
        {
            var adj = BuildAdjacencyList(graph);
            int n = graph.Vertices;

            var visited = new bool[n];
            var mst = new List<(int, int, int)>();

            var pq = new PriorityQueue<(int from, int to, int weight), int>();

            visited[0] = true;

            foreach (var (v, w) in adj[0])
                pq.Enqueue((0, v, w), w);

            while (pq.Count > 0)
            {
                var (u, v, weight) = pq.Dequeue();

                if (visited[v]) continue;

                visited[v] = true;
                mst.Add((u, v, weight));

                foreach (var (nx, w) in adj[v])
                {
                    if (!visited[nx])
                        pq.Enqueue((v, nx, w), w);
                }
            }

            return mst;
        }
    }
}
