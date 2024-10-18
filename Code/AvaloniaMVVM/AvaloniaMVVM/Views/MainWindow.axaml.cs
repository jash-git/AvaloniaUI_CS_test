using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System.Text;
using Avalonia.Media;
using System;
using System.Threading;
using System.Timers;


namespace AvaloniaMVVM.Views
{
    public partial class MainWindow : Window
    {
        //---
        //Thread
        private Thread m_timerThread;
        private bool m_running;
        private void InitializeThread()
        {
            m_running = true;
            m_timerThread = new Thread(ThreadFunction);
            m_timerThread.Start();
        }
        private void ThreadStop()
        {
            m_running = false;
            m_timerThread?.Join();
        }

        private void ThreadFunction()
        {
            while (m_running)
            {
                Thread.Sleep(2000);
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    GreetingTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
                });
            }
        }
        //---Thread

        //---
        //Timer
        private System.Timers.Timer m_timer;
        private void InitializeTimer()
        {
            /*
             m_timer.Start();
             m_timer.Stop();
            */
            m_timer = new System.Timers.Timer(2000); // 每秒觸發一次
            m_timer.Elapsed += OnTimedEvent;
            m_timer.AutoReset = true;
            m_timer.Start();
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                GreetingTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            });
        }
        //---Timer

        public MainWindow()
        {
            InitializeComponent();
            FullScreenMode();
            SpecifyScreen();
            ShowScreenResolution();
            InitializeThread();//InitializeTimer();
        }
        private void SpecifyScreen(int intIndx=1)
        {
            if ((intIndx - 1) < 0)
                return;

            // 獲取所有螢幕
            var allScreens = Screens.All;

            // 選擇第二個螢幕 (若有)
            if (allScreens.Count > (intIndx-1))
            {
                var targetScreen = allScreens[(intIndx - 1)];
                Position = new PixelPoint(targetScreen.WorkingArea.X, targetScreen.WorkingArea.Y);
            }
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
                ResolutionTextBlock.Text = resolutionInfo.ToString();
            });
        }
        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            ResolutionTextBlock.FontWeight = FontWeight.Bold;
            BtnSet.Content = "FontWeight.Bold";
            ThreadStop();//m_timer.Stop();
        }
    }
}