using ContainerV7.Commands;
using Nice3point.Revit.Toolkit.External;

namespace ContainerV7;
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
        var panel = Application.CreatePanel("Commands", "ContainerV7");

        panel.AddPushButton<StartupCommand>("Execute")
            .SetImage("/ContainerV7;component/Resources/Icons/RibbonIcon16.png")
            .SetLargeImage("/ContainerV7;component/Resources/Icons/RibbonIcon32.png");
    }
}