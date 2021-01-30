using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDbContext
    {
        List<User> Users { get; set; }
        List<Todo> Todo { get; set; }
        List<TodoList> TodoList { get; set; }
    }
}
