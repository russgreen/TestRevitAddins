using CommunityToolkit.Mvvm.ComponentModel;

namespace FromMyTemplate.Models;
internal partial class Model : ObservableObject
{
    [ObservableProperty]
    private string _parameter;
}
