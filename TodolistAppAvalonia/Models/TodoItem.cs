using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodolistAppAvalonia.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public string Description { get; set; } = String.Empty;
        public bool isChecked { get; set; }
    }
}
