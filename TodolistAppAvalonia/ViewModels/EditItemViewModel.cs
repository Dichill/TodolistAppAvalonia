using Avalonia;
using MsBox.Avalonia.ViewModels.Commands;
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
    public class EditItemViewModel : ViewModelBase
    {
        string description;
        string prev_description;
        public EditItemViewModel(string old_description)
        {
            PrevDescription = old_description;

            Ok = ReactiveCommand.Create(() => Description);
            Cancel = ReactiveCommand.Create(() => { });
        }

        public ReactiveCommand<Unit, String> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }
        public string PrevDescription
        {
            get => prev_description;
            set => this.RaiseAndSetIfChanged(ref prev_description, value);
        }
    }
}
