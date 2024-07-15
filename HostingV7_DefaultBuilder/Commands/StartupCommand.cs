using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;
using HostingV7_DefaultBuilder.Services;

namespace HostingV7_DefaultBuilder.Commands;
/// <summary>
///     External command entry point invoked from the Revit interface
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    private ILogger<StartupCommand> _logger;
    private IServiceDemo _serviceDemo;

    public override void Execute()
    {
        _logger = Host.GetService<ILogger<StartupCommand>>();
        _serviceDemo = Host.GetService<IServiceDemo>();

        _serviceDemo.DoSomething();
        _logger.LogInformation("Executing the StartupCommand");
    }
}