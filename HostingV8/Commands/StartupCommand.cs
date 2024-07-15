using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using HostingV8.Services;
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;

namespace HostingV8.Commands;
/// <summary>
///     External command entry point invoked from the Revit interface
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    private ILogger<StartupCommand> _logger; // = Host.GetService<ILogger<StartupCommand>>();
    private IServiceDemo _serviceDemo; // = Host.GetService<IServiceDemo>();

    public override void Execute()
    {
        _logger = Host.GetService<ILogger<StartupCommand>>();
        _serviceDemo = Host.GetService<IServiceDemo>();

        _serviceDemo.DoSomething();
        _logger.LogInformation("Executing the StartupCommand");
    }
}