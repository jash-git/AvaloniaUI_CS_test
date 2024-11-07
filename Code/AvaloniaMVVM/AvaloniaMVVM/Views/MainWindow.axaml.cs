using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System.Text;
using Avalonia.Media;
using System;
using System.Threading;
using System.Timers;
using AvaloniaMVVM.ViewModels;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using static System.Net.Mime.MediaTypeNames;


namespace AvaloniaMVVM.Views
{
    public partial class MainWindow : Window
    {
        //---
        //ViewModels
        public MainWindowViewModel m_MainWindowViewModel = null;
        //---ViewModels
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
        private bool m_blnMode = true;
        private System.Timers.Timer m_timer;
        private void InitializeTimer()
        {
            /*
             m_timer.Start();
             m_timer.Stop();
            //*/

            //*
            m_timer = new System.Timers.Timer(1000); // 每秒觸發一次
            m_timer.Elapsed += OnTimedEvent;
            m_timer.AutoReset = true;
            m_timer.Start();
            //*/


        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(m_blnMode)
            {
                m_MainWindowViewModel.Items.Insert(0, new Item(DateTime.Now.ToString("HH:mm:ss"), false));
            }
            else
            {
                m_MainWindowViewModel.Items.RemoveAt(0);
            }
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                listbox01.SelectedIndex = (0);
                GreetingTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            });
        }
        //---Timer

        public MainWindow()
        {
            //---
            //從APP
            m_MainWindowViewModel = new MainWindowViewModel();
            DataContext = m_MainWindowViewModel;
            //---
            InitializeComponent();
            FullScreenMode();
            SpecifyScreen();
            ShowScreenResolution();

            //animals.ItemsSource = new string[]{"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" }.OrderBy(x => x);

            img01.PointerPressed += BtnSet_Click;


            InitializeTimer();//InitializeThread();//
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
        private async void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            ResolutionTextBlock.FontWeight = FontWeight.Bold;
            BtnSet.Content = "FontWeight.Bold";
            
            //---
            //程式切換圖片語法
            var uri = new Uri("avares://AvaloniaMVVM/Assets/avalonia-logo.ico", UriKind.RelativeOrAbsolute);
            using (var stream = AssetLoader.Open(uri))
            {
                img01.Source = new Bitmap(stream);
            }
            //---程式切換圖片語法

            m_blnMode = false;//m_timer.Stop();//ThreadStop();//

            //---
            //簡易對話盒
            var messageBox = new Window
            {
                Title = "Message Box",
                Width = 300,
                Height = 200,
                Content = new StackPanel
                {
                    Children =
                    {
                        new TextBlock { Text = "Hello, this is a custom message box!", Margin = new Thickness(10) },
                        new Button { Content = "OK", Margin = new Thickness(10) }
                    }
                }
            };
            await messageBox.ShowDialog(this);
            //---簡易對話盒
        }
    }
}