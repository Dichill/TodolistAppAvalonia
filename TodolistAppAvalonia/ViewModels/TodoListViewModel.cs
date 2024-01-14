using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TodolistAppAvalonia.Models;
using MsBox.Avalonia.ViewModels.Commands;
using TodolistAppAvalonia.Services;

namespace TodolistAppAvalonia.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public GlobalViewModel GlobalViewModel { get; } = GlobalViewModel.Instance;
        public TodoListViewModel(IEnumerable<TodoItem>? items)
        {
            var db = new TodoListService();
            ListItems = items != null ? new ObservableCollection<TodoItem>(items) : new ObservableCollection<TodoItem>();
            
            Delete = new RelayCommand((o) =>
            {
                var item = ListItems.FirstOrDefault(i => i.id == (int)o);
                if (item != null)
                {
                    ListItems.Remove(item);
                    db.SaveItems(ListItems);
                }
            });

            DidTodo = new RelayCommand(o =>
            {
                var db = new TodoListService();
                var item = ListItems.FirstOrDefault(i => i.id == (int)o);
                db.SaveItems(ListItems);
            });
        }

        public ObservableCollection<TodoItem>? ListItems { get; set; }
        public RelayCommand Delete { get; set; }
        public RelayCommand DidTodo { get; set; }
    }
}
