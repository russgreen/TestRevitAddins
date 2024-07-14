using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;

namespace HostingV8_DefaultBuilder.Commands;
/// <summary>
///     External command entry point invoked from the Revit interface
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    private readonly ILogger<StartupCommand> _logger = Host.GetService<ILogger<StartupCommand>>();

    public override void Execute()
    {
        _logger.LogInformation("Executing the StartupCommand");

        var td = new TaskDialog("Testing commands work:")
        {
            MainInstruction = "Testing the adding command is executed.",
            CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel
        };

        td.Show();
    }
}