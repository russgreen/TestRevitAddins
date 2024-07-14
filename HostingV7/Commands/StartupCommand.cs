using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Nice3point.Revit.Toolkit.External;

namespace HostingV7.Commands;
/// <summary>
///     External command entry point invoked from the Revit interface
/// </summary>
[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class StartupCommand : ExternalCommand
{
    public override void Execute()
    {
        var td = new TaskDialog("Testing commands work:")
        {
            MainInstruction = "Testing the adding command is executed.",
            CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel
        };

        td.Show();
    }
}