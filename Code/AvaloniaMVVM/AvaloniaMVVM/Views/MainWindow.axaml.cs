using Avalonia.Controls;

namespace AvaloniaMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            //隱藏工具列
            this.ExtendClientAreaToDecorationsHint = true;
            this.ExtendClientAreaTitleBarHeightHint = -1;
            //---隱藏工具列
            this.SystemDecorations = SystemDecorations.None;
        }
    }
}