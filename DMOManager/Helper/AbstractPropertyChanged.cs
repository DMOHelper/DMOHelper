using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DMOHelper.Helper
{
    /// <summary>
    /// This class contains an implementation of INotifyPropertyChanged and can be derived by other classes.
    /// The OnPropertyChanged is designed to use the CallerMemberName.
    /// </summary>
    public abstract class AbstractPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
