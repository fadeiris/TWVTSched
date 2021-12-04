using Microsoft.Extensions.DependencyInjection;

namespace TWVTSched;

static class Program
{
    // �ѦҡGhttps://docs.microsoft.com/zh-tw/archive/msdn-magazine/2019/may/net-core-3-0-create-a-centralized-pull-request-hub-with-winforms-in-net-core-3-0
    private static IServiceProvider? ServiceProvider { get; set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        ConfigureServices();

        Application.Run((MainForm)ServiceProvider?.GetService(typeof(MainForm))!);
    }

    private static void ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddHttpClient();
        services.AddSingleton<MainForm>();

        ServiceProvider = services.BuildServiceProvider();
    }
}