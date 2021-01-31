using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class TodoList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Owner { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
