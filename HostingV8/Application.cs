using HostingV8.Commands;
using HostingV8.Services;
using Nice3point.Revit.Toolkit.External;

namespace HostingV8;
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

        var demoService = Host.GetService<IServiceDemo>();
        demoService.DoSomething();
    }

    public override void OnShutdown()
    {
        Host.Stop();
    }

    private void CreateRibbon()
    {
        var panel = Application.CreatePanel("Commands", "HostingV8");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/HostingV8;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/HostingV8;component/Resources/Icons/RibbonIcon32.png");
    }
}