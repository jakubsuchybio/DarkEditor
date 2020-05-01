using System.Windows;

namespace DarkEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();

            if (e.Args.Length == 1)
                wnd.Initialize(e.Args[0]);

            wnd.Show();
        }
    }
}
