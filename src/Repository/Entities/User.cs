﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        private IEnumerable<TodoList> lists = new HashSet<TodoList>();

        public virtual IEnumerable<TodoList> Lists { get { return lists; } set { lists = value; } }

    }
}
