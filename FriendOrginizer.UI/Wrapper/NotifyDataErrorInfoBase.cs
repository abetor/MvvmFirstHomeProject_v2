using FriendOrganizer.UI.ViewModel;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FriendOrginizer.UI.Wrapper{

    public class NotifyDataErrorInfoBase : ViewModelBase, INotifyDataErrorInfo
    {

        private Dictionary<string, List<string>> _errosByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errosByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errosByPropertyName.ContainsKey(propertyName)
                ? _errosByPropertyName[propertyName]
                : null;
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errosByPropertyName.ContainsKey(propertyName))
            {
                _errosByPropertyName[propertyName] = new List<string>();
            }

            if (!_errosByPropertyName[propertyName].Contains(error))
            {
                _errosByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errosByPropertyName.ContainsKey(propertyName))
            {
                _errosByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
