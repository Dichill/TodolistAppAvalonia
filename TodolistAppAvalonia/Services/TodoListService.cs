using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistAppAvalonia.Models;

namespace TodolistAppAvalonia.Services
{
    public class TodoListService
    {
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { id = 0, Description = "Walk the Dog" },
            new TodoItem { id = 1, Description = "Park the Car" },
            new TodoItem { id = 2, Description = "Hello World", isChecked = true }
        };
    }
}
