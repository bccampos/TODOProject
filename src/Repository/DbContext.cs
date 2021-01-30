using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository
{
    public class DbContext : IDbContext
    {
        public List<User> Users { get; set; }
        public List<Todo> Todo { get; set; }
        public List<TodoList> TodoList { get; set; }

        public DbContext()
        {
            if (Users == null)
            {
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
            }

            Todo = new List<Todo>();
            TodoList = new List<TodoList>();
        }

    }
}
