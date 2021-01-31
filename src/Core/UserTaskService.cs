using Core.Interface;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserTaskService : IUserTaskService
    {
        protected readonly ITodoListRepository _userTaskRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly ITodoRepository _todoRepository;

        public UserTaskService(ITodoListRepository userTaskRepository, IUserRepository userRepository, ITodoRepository todoRepository)
        {
            _userTaskRepository = userTaskRepository;
            _userRepository = userRepository;
            _todoRepository = todoRepository;
        }

        public async Task<int> CreateUserTask(int userId, string description)
        {
            var user = await GetUserById(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var newTaskId = _userTaskRepository.Create(new TodoList()
            {
                Name = description,
                Date = DateTime.UtcNow,
                Owner = user
            });

            return newTaskId;
        }

        public Task<IEnumerable<TodoList>> GetUserTasks(int userId)
        {
            return Task.FromResult(_userTaskRepository.List().Where(userTask => userTask.Owner.Id == userId).AsEnumerable());
        }

        public Task<User> GetUserById(int id)
        {
            return Task.FromResult(_userRepository.Get(id));
        }

        public Task DeleteUserTask(int userId, int[] userTaskIds)
        {
            var userTasksQuery = _userTaskRepository.List()
                //  Filtering our query by user id to make sure those tasks really belong to them
                .Where(x => x.Owner.Id == userId && userTaskIds.Contains(x.Id));

            foreach (var userTask in userTasksQuery.ToList())
            {
                _userTaskRepository.Delete(userTask.Id);
            }

            return Task.FromResult(true);
        }

        public Task<User> GetUserByCredentials(string userName, string password)
        {
            var user = _userRepository.List().SingleOrDefault(x => x.Email == userName && x.Password == password);

            return Task.FromResult(user);
        }

        public Task<int> CreateUser(User user)
        {
            return Task.FromResult(_userRepository.Create(user));
        }

        //public Task<IEnumerable<Todo>> GetTodoTasks(int userId)
        //{
        //    return Task.FromResult(_todoRepository.List().Where(userTask => userTask..Id == userId).AsEnumerable());
        //}

    }
}
