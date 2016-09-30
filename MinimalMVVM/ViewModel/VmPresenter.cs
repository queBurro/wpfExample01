using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class VmPresenter : ObservableObject //inherits from ObservableObject so that we've got an implementation of RaisePropertyChangedEvent. 
    {
        private string _someText;
        public string SomeText //public property which is bound to- get and settable
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");//it's been changed so alw
            }
        }

        private readonly ObservableCollection<string> _history = new ObservableCollection<string>(); //field
        public IEnumerable<string> ObservableProperty_History //property - public/get-only, can't bind to fields?
        {
            get { return _history; }
        }

        private readonly TextConverter _textConverter = new TextConverter(s => s.ToUpper());
        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText))
                return;

            AddToHistory(_textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
