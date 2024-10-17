using Avalonia.Controls;

namespace AvaloniaMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            //���äu��C
            this.ExtendClientAreaToDecorationsHint = true;
            this.ExtendClientAreaTitleBarHeightHint = -1;
            //---���äu��C
            this.SystemDecorations = SystemDecorations.None;
        }
    }
}