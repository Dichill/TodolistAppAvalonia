using ReactiveUI;
using System.Collections.Generic;
using System.Reactive.Linq;
using TodolistAppAvalonia.Models;
using TodolistAppAvalonia.Services;
using System;
using System.Reactive;
using MsBox.Avalonia.ViewModels.Commands;
using System.Linq;
using System.Reflection.Metadata;
using System.Collections.ObjectModel;

namespace TodolistAppAvalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        private ObservableCollection<string> _pdfPages;
        public MainWindowViewModel()
        {
            var db = new TodoListService();
            Content = List = new TodoListViewModel(db.GetItems());
        }

        public ObservableCollection<string> PdfPages
        {
            get => _pdfPages;
            private set => this.RaiseAndSetIfChanged(ref _pdfPages, value);
        }
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        public TodoListViewModel List { get; }

        public void AddItem()
        {
            var vm = new AddItemViewModel();
            var db = new TodoListService();

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1).Subscribe(model =>
                {
                    if (model != null)
                    {
                        if (List.ListItems.Count >= 0) model.id = (List.ListItems.Count - 1) + 1;
                        else model.id = 0;
                        List.ListItems.Add(model);
                    }

                    Content = List;
                    if (model == null) return;
                    if (List.ListItems != null)
                        db.SaveItems(List.ListItems);
                });

            Content = vm;
        }

        public void EditItem(object o)
        {
            var vm = new EditItemViewModel(o?.ToString() ?? "");

            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (string)null))
                .Take(1).Subscribe(i =>
                {
                    if (i != null)
                    {
                        // Logic goes here
                        var item = List.ListItems.FirstOrDefault(i => i.Description == o?.ToString());
                        if (item != null)
                        {
                            item.Description = vm.Description;
                        }
                    }

                    Content = List;
                });

            Content = vm;
        }
    }
}