using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Set<T>(ref T field, T newValue = default(T), [CallerMemberName]string propertyName = null)
        {
            if (field != null)
            {
                if (!field.Equals(newValue))
                {
                    field = newValue;
                    OnPropertyChanged(propertyName);
                }
            }
            else
            {
                if (newValue != null)
                {
                    field = newValue;
                    OnPropertyChanged(propertyName);
                }
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
