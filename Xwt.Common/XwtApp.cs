namespace Xwt.Common
{
    public class XwtApp
    {
        public static void Run(ToolkitType toolkitType)
        {
            Application.Initialize(toolkitType);

            var mainWindow = new MainWindow();

            Application.Run();
            Application.Dispose();
        }
    }
}
