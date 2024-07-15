using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit;
using Nice3point.Revit.Toolkit.External;
using System;
using System.Runtime.InteropServices;

namespace FromMyTemplate.Commands;

[Transaction(TransactionMode.Manual)]
public class Command : ExternalCommand
{
    private ILogger<Command> _logger; // = Host.GetService<ILogger<Command>>();

    public override void Execute()
    {
        _logger = Host.GetService<ILogger<Command>>();

        _logger.LogDebug("Command called");

        App.RevitDocument = Context.UiDocument.Document;

        var mainWindowView = new Views.MainView();
        mainWindowView.ShowDialog();
    }


}
