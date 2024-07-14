using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
//using Microsoft.Extensions.Logging;
using Serilog;
using Nice3point.Revit.Toolkit.External;

namespace HostingV7.Commands;
/// <summary>
///     External command entry point invoked from the Revit interface
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    private readonly ILogger _logger = Host.GetService<ILogger>();

    public override void Execute()
    {
        _logger.Information("Executing the StartupCommand");

        var td = new TaskDialog("Testing commands work:")
        {
            MainInstruction = "Testing the adding command is executed.",
            CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel
        };

        td.Show();
    }
}