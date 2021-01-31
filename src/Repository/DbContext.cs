using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DbContext : IDbContext
    {
        public List<User> Users { get; set; }
        public List<Todo> Todo { get; set; }
        public List<TodoList> TodoList { get; set; }

        public DbContext()
        {
            // Singleton call

            Users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "bruno",
                    Email = "bruno@test.ie",
                    Password = "123",
                    Lists = new List<TodoList>()
                }
            };

            TodoList = new List<TodoList>()
            {
                new TodoList()
                {
                   Id = 1,
                   Name = "Task Default",
                   Owner = Users.First(),
                   Date = DateTime.UtcNow,
                   Todos = new List<Todo>()
                }
            };

            Todo = new List<Todo>();
        }

    }
}
