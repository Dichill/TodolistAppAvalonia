using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using TodolistAppAvalonia.Models;

namespace TodolistAppAvalonia.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        string description = string.Empty;

        public AddItemViewModel()
        {
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            //new TodoItem { Description = Description },
            //    okEnabled)
            Ok = ReactiveCommand.Create(() => new TodoItem { Description = Description });
            Cancel = ReactiveCommand.Create(() => { });
        }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        public ReactiveCommand<Unit, TodoItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
