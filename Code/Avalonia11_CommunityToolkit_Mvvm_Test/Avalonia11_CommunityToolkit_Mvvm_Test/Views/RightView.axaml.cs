using Avalonia.Controls;
using Avalonia11_CommunityToolkit_Mvvm_Test.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia11_CommunityToolkit_Mvvm_Test.Views;

public partial class RightView : UserControl
{
    public void ListenEvent()
    {
        WeakReferenceMessenger.Default.Register<UpdateTextMessage>(this, (r, msg) =>
        {
            int Count = ((MainWindowViewModels)(Parent.DataContext)).IntCounter;
            // 加工訊息
            switch (msg.Value)
            {
                case "Fun_Code00":
                    RightShow.Text= $"接收左側按鈕按下次數:{Count}";
                    break;
                default:
                    msg = new UpdateTextMessage("Right View Received Unknown Code");
                    break;

            }
        });
    }
    public RightView()
    {
        InitializeComponent();
        ListenEvent();
    }
}