using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DemoClassLibrary.Services;

namespace DemoClassLibrary.ViewModels;

public class ClassLibViewModel (IClassLibService service) : INotifyPropertyChanged
{
    public ICommand GetGuidCommand => new Command(GetNewGuid);

    private string? _guidValue = null;

    public string? GuidValue
    {
        get => _guidValue;
        set
        {
            _guidValue = value;
            OnPropertyChanged();
        }
    }

    private void GetNewGuid()
    {
        var guid = service.GetNewGuid();
        GuidValue = guid;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}