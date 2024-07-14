using ContainerV8.Commands;
using Nice3point.Revit.Toolkit.External;

namespace ContainerV8;
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

    private void CreateRibbon()
    {
        var panel = Application.CreatePanel("Commands", "ContainerV8");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/ContainerV8;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/ContainerV8;component/Resources/Icons/RibbonIcon32.png");
    }
}