using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Windows.Input;

namespace FromMyTemplate.ViewModels;
internal partial class MainViewModel : BaseViewModel
{
    public string WindowTitle { get; private set; }

    [ObservableProperty]
    private bool _isCommandEnabled = true;

    private ILogger<MainViewModel> _logger = Host.GetService<ILogger<MainViewModel>>();

    public MainViewModel()
    {
        var informationVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        WindowTitle = $"FromMyTemplate {informationVersion} ({App.RevitDocument.Title})";

        _logger.LogDebug("MainViewModel");
        _logger.LogDebug(App.RevitDocument.PathName);
        _logger.LogDebug(Nice3point.Revit.Toolkit.Context.Document.PathName);
    }

    [RelayCommand]
    private void Run()
    {
        //DO STUFF HERE
        _logger.LogDebug("Command called");
        IsCommandEnabled = false;
    }
}
