using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System.Text;

namespace Avalonia_Infinite_ayout_loop_detected.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        FullScreenMode();
        SpecifyScreen();
        ShowScreenResolution();
    }
    private void FullScreenMode()
    {
        this.WindowState = WindowState.FullScreen;//WindowState.Maximized;
        //隱藏工具列
        this.ExtendClientAreaToDecorationsHint = true;
        this.ExtendClientAreaTitleBarHeightHint = -1;
        //---隱藏工具列
        this.SystemDecorations = SystemDecorations.None;
    }
    private void SpecifyScreen(int intIndx = 1)
    {
        if ((intIndx - 1) < 0)
            return;

        // 獲取所有螢幕
        var allScreens = Screens.All;

        // 選擇第二個螢幕 (若有)
        if (allScreens.Count > (intIndx - 1))
        {
            var targetScreen = allScreens[(intIndx - 1)];
            Position = new PixelPoint(targetScreen.WorkingArea.X, targetScreen.WorkingArea.Y);
        }
    }
    private void ShowScreenResolution()
    {
        StringBuilder resolutionInfo = new StringBuilder();

        /*
        var screens = Screens.Primary.WorkingArea;
        var screenWidth = screens.Width;
        var screenHeight = screens.Height;
        resolutionInfo.AppendLine($"Primary Screen: {screenWidth} x {screenHeight}");
        */

        int i = 0;
        foreach (var screen in Screens.All)
        {
            i++;
            resolutionInfo.AppendLine($"Screen {i}: {screen.Bounds.Width} x {screen.Bounds.Height}");
        }

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            m_MainView.ResolutionTextBlock.Text = resolutionInfo.ToString();
        });
    }
}
