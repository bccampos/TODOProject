using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IUserTaskService
    {
        Task<IEnumerable<TodoList>> GetUserTasks(int userId);
        Task<int> CreateUserTask(int userId, string description);
        Task<User> GetUserById(int id);
        Task DeleteUserTask(int userId, int[] userTaskIds);
        Task<User> GetUserByCredentials(string userName, string password);
        Task<int> CreateUser(User user);
    }
}
