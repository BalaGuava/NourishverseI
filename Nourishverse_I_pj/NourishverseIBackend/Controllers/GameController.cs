using GameSharedModels;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly MongoDBContext _dbContext;

    public GameController(MongoDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("tools")]
    public ActionResult<List<Tool>> GetTools()
    {
        var tools = _dbContext.Tools.Find(t => true).ToList();
        return Ok(tools);
    }

    [HttpPost("tools")]
    public IActionResult CreateTool([FromBody] Tool tool)
    {
        _dbContext.Tools.InsertOne(tool);
        return CreatedAtAction(nameof(GetTools), new { name = tool.Name }, tool);
    }
}
