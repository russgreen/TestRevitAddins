using HostingV7_DefaultBuilder.Commands;
using Nice3point.Revit.Toolkit.External;

namespace HostingV7_DefaultBuilder;
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
        var panel = Application.CreatePanel("Commands", "HostingV7_DefaultBuilder");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/HostingV7_DefaultBuilder;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/HostingV7_DefaultBuilder;component/Resources/Icons/RibbonIcon32.png");
    }
}