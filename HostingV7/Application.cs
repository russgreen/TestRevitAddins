using HostingV7.Commands;
using Nice3point.Revit.Toolkit.External;

namespace HostingV7;
/// <summary>
///     Application entry point
/// </summary>
[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        Host.Start();
        CreateRibbon();
    }

    public override void OnShutdown()
    {
        Host.Stop();
    }

    private void CreateRibbon()
    {
        var panel = Application.CreatePanel("Commands", "HostingV7");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/HostingV7;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/HostingV7;component/Resources/Icons/RibbonIcon32.png");
    }
}