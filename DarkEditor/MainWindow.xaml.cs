using MahApps.Metro.Controls;
using System;
using System.IO;

namespace DarkEditor
{
    public partial class MainWindow : MetroWindow
    {
        private string _path;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Initialize(string filePath)
        {
            _path = filePath;
            Title = $"DarkEditor - File: {_path}";

            using (var stream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            using (var reader = new StreamReader(stream))
                textBox.Text = reader.ReadToEnd();

            textBox.CaretIndex = 0;
            textBox.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            using (var stream = new FileStream(_path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            using (var writer = new StreamWriter(stream))
            {
                stream.SetLength(0);
                writer.Write(textBox.Text);
            }
            base.OnClosed(e);
        }
    }
}
