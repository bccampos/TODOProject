using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public TodoList List { get; set; }

        public long Position { get; set; }

        public DateTime Date { get; set; }


    }
}
