using Repository.Entities;
using Repository.Interfaces;
using System.Linq;

namespace Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IDbContext _dbContext;

        public TodoListRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(TodoList userTask)
        {
            var maxUserTaskId = _dbContext.TodoList.Select(x => x.Id).DefaultIfEmpty(0).Max();

            userTask.Id = maxUserTaskId + 1;

            _dbContext.TodoList.Add(userTask);

            return userTask.Id;
        }

        public bool Delete(int id)
        {
            var userTask = Get(id);

            if (userTask == null)
            {
                return false;
            }

            return _dbContext.TodoList.Remove(userTask);
        }

        public TodoList Get(int id)
        {
            return _dbContext.TodoList.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TodoList> List()
        {
            return _dbContext.TodoList.AsQueryable();
        }
    }
}
