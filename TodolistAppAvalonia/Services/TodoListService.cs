using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodolistAppAvalonia.Models;

namespace TodolistAppAvalonia.Services
{
    public class TodoListService
    {
        public IEnumerable<TodoItem>? GetItems()
        {
            try
            {
                Console.WriteLine("Items read from items.json");

                return (IEnumerable<TodoItem>)ReadItemsFromJson();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("An error occured: " + ex.ToString());
                return null!;
            }
        }

        public Task SaveItems(IEnumerable<TodoItem> items)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);

            // Save JSON to a file
            File.WriteAllText("items.json", json);

            Console.WriteLine("Items saved to items.json");
            
            return Task.CompletedTask;
            ;
        }
        
        static List<TodoItem> ReadItemsFromJson()
        {
            // Read JSON from file
            string json = File.ReadAllText("items.json");

            // Deserialize JSON to a list of items
            List<TodoItem> items = JsonConvert.DeserializeObject<List<TodoItem>>(json);

            return items;
        }
    }
}
