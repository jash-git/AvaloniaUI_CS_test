using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using Avalonia.VisualTree;
using Avalonia_Infinite_ayout_loop_detected.ViewModels;
using System;
using System.Threading;
using System.Timers;

namespace Avalonia_Infinite_ayout_loop_detected.Views;

public partial class MainView : UserControl
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
        Dispatcher.UIThread.Post(() =>
        {//Post 則不保證執行順序，適用於不需要順序的場景。
            if (m_blnMode)
            {
                ((MainViewModel)DataContext).Items.Insert(0, new Item(DateTime.Now.ToString("HH:mm:ss"), false));
            }
            else
            {
                if (((MainViewModel)DataContext).Items.Count > 0)
                {
                    ((MainViewModel)DataContext).Items.RemoveAt(0);
                }
            }
        });
        Dispatcher.UIThread.InvokeAsync(() =>
        {//InvokeAsync 保證在事件循環中的順序執行
            listbox01.SelectedIndex = (0);
            GreetingTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        });
    }
    //---Timer
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        img01.PointerPressed += BtnSet_Click;
        InitializeTimer();//InitializeThread();//
    }
    private async void BtnSet_Click(object sender, RoutedEventArgs e)
    {
        ResolutionTextBlock.FontWeight = Avalonia.Media.FontWeight.Bold;
        BtnSet.Content = "FontWeight.Bold";

        //---
        //程式切換圖片語法
        var imageUri = new Uri($"avares://Avalonia_Infinite-ayout-loop-detected/Assets/avalonia-logo.ico");
        using (var stream = AssetLoader.Open(imageUri))
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
        var parentWindow = this.FindAncestorOfType<Window>();
        await messageBox.ShowDialog(parentWindow);
        //---簡易對話盒

        MyPopup.IsOpen = true;
    }
    private void ClosePopup_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = false;
    }
}
