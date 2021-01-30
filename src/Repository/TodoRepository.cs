using Repository.Entities;
using Repository.Interfaces;
using System.Linq;

namespace Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDbContext _dbContext;

        public TodoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Todo userTask)
        {
            var maxUserTaskId = _dbContext.Todo.Select(x => x.Id).DefaultIfEmpty(0).Max();

            userTask.Id = maxUserTaskId + 1;

            _dbContext.Todo.Add(userTask);

            return userTask.Id;
        }

        public bool Delete(int id)
        {
            var userTask = Get(id);

            if (userTask == null)
            {
                return false;
            }

            return _dbContext.Todo.Remove(userTask);
        }

        public Todo Get(int id)
        {
            return _dbContext.Todo.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Todo> List()
        {
            return _dbContext.Todo.AsQueryable();
        }
    }
}
