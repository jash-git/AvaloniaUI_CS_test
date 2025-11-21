using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia11_CommunityToolkit_Mvvm_Test.ViewModels;

//---
//建立訊息類型（Message class）
public class UpdateTextMessage : ValueChangedMessage<string>
{
    public UpdateTextMessage(string value) : base(value) { }
}
//---建立訊息類型（Message class）

public class MainWindowViewModels : ViewModelBase
{
    private int m_intCounter;
    public int IntCounter
    {
        get => m_intCounter;
        set => SetProperty(ref m_intCounter, value);
    }

    public IRelayCommand SendCommand { get; }

    public MainWindowViewModels()
    {
    }
}