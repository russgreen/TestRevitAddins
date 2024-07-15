using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using FromMyTemplate.Commands;
using Microsoft.Extensions.Logging;
using Nice3point.Revit.Toolkit.External;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace FromMyTemplate;
public class App : ExternalApplication
{
    // get the absolute path of this assembly
    public static readonly string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

    // class instance
    public static App ThisApp;

    public static UIControlledApplication CachedUiCtrApp;
    public static UIApplication CachedUiApp;
    public static ControlledApplication CtrApp;
    public static Autodesk.Revit.DB.Document RevitDocument;

    private AppDocEvents _appEvents;
    private ILogger<App> _logger;

    public override void OnStartup()
    {
        ThisApp = this;
        CachedUiCtrApp = Application;
        CtrApp = Application.ControlledApplication;

        Host.StartHost();

        _logger = Host.GetService<ILogger<App>>();

        var panel = RibbonPanel(CachedUiCtrApp);

        AddAppDocEvents();

    }

    public Result OnShutdown(UIControlledApplication application)
    {
        RemoveAppDocEvents();

        Host.StopHost();
        Serilog.Log.CloseAndFlush();

        return Result.Succeeded;
    }

    #region Event Handling
    private void AddAppDocEvents()
    {
        _appEvents = new AppDocEvents();
        _appEvents.EnableEvents();
    }
    private void RemoveAppDocEvents()
    {
        _appEvents.DisableEvents();
    }


    #endregion

    #region Ribbon Panel

    private RibbonPanel RibbonPanel(UIControlledApplication application)
    {

        RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel("FromMyTemplate_Panel");
        panel.Title = "FromMyTemplate";

        PushButton button = (PushButton)panel.AddItem(
            new PushButtonData(
                "Command",
                "Command",
                Assembly.GetExecutingAssembly().Location,
                $"{nameof(FromMyTemplate)}.{nameof(Commands)}.{nameof(Command)}"));
        button.ToolTip = "Execute the FromMyTemplate command";
        button.LargeImage = PngImageSource("FromMyTemplate.Resources.FromMyTemplate_Button.png");

        return panel;
    }

    private System.Windows.Media.ImageSource PngImageSource(string embeddedPath)
    {
        var stream = GetType().Assembly.GetManifestResourceStream(embeddedPath);
        System.Windows.Media.ImageSource imageSource;
        try
        {
            imageSource = BitmapFrame.Create(stream);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading image from embedded resource");
            imageSource = null;
        }

        return imageSource;
    }
    #endregion
}
