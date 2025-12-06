using Microsoft.AspNetCore.Mvc;
using GraphAnalyzer.Api.Models;
using GraphAnalyzer.Api.Services;

namespace GraphAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GraphController : ControllerBase
    {
        private readonly GraphService _service;

        public GraphController(GraphService service)
        {
            _service = service;
        }

        [HttpPost("bfs")]
        public IActionResult BFS([FromBody] Graph graph, int start = 0)
        {
            return Ok(_service.BFS(graph, start));
        }

        [HttpPost("dfs")]
        public IActionResult DFS([FromBody] Graph graph, int start = 0)
        {
            return Ok(_service.DFS(graph, start));
        }

        [HttpPost("dijkstra")]
        public IActionResult Dijkstra([FromBody] Graph graph, int start)
        {
            return Ok(_service.Dijkstra(graph, start));
        }

        [HttpPost("prim")]
        public IActionResult Prim([FromBody] Graph graph)
        {
            return Ok(_service.Prim(graph));
        }
    }
}
