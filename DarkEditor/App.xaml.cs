using System;
using System.IO;
using System.Windows;

namespace DarkEditor
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length != 1)
            {
                MessageBox.Show("Filepath argument missing!", "Error", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
                Environment.Exit(1);
            }

            var filePath = e.Args[0];
            if(!File.Exists(filePath))
            {
                MessageBox.Show($"File: {filePath} doesn't exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
                Environment.Exit(1);
            }

            MainWindow wnd = new MainWindow();
            wnd.Initialize(filePath);
            wnd.Show();
        }
    }
}
