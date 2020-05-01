using MahApps.Metro.Controls;
using System;
using System.IO;
using System.Windows.Documents;

namespace DarkEditor
{
    public partial class MainWindow : MetroWindow
    {
        private FileStream _fs;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Initialize(string filePath)
        {
            Title = $"DarkEditor - File: {filePath}";

            _fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            using (var reader = new StreamReader(_fs, leaveOpen: true))
                textBox.Text = reader.ReadToEnd();

            textBox.CaretIndex = 0;
            textBox.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            _fs.SetLength(0);
            using (var writer = new StreamWriter(_fs))
                writer.Write(textBox.Text);
            base.OnClosed(e);
        }
    }
}
