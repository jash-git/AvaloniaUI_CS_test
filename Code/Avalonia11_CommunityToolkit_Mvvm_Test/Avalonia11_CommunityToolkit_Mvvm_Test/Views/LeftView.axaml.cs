using Avalonia.Controls;
using Avalonia11_CommunityToolkit_Mvvm_Test.ViewModels;
using CommunityToolkit.Mvvm.Messaging;   // ← 必須加這一行！

namespace Avalonia11_CommunityToolkit_Mvvm_Test.Views;

public partial class LeftView : UserControl
{
    public LeftView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int Count = (((MainWindowViewModels)(Parent.DataContext)).IntCounter++);
        LeftShow.Text = $"Left Button Clicked : {Count}";
        WeakReferenceMessenger.Default.Send(new UpdateTextMessage("Fun_Code00"));//發送訊息
    }
}