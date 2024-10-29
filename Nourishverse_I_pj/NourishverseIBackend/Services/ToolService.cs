using GameSharedModels;
using UnityGameBackend.MongoDB;
using MongoDB.Driver;

namespace UnityGameBackend.Services
{
    public class ToolService
    {
        private readonly MongoDBContext _dbContext;

        public ToolService(MongoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Tool> GetAllTools()
        {
            return _dbContext.Tools.Find(tool => true).ToList();
        }

        public void AddTool(Tool tool)
        {
            _dbContext.Tools.InsertOne(tool);
        }
    }
}
