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

namespace TodolistAppAvalonia.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(IEnumerable<TodoItem> items) {
            ListItems = new ObservableCollection<TodoItem>(items);

            Delete = new RelayCommand((o) =>
            {
                ListItems.RemoveAt((int)o);
            });
        }

        public ObservableCollection<TodoItem> ListItems { get; set; }

        public RelayCommand Delete { get; set; }
    }
}
