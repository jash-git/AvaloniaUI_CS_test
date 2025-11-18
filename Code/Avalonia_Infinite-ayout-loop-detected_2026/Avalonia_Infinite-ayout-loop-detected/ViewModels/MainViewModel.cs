using System.Collections.ObjectModel;

namespace Avalonia_Infinite_ayout_loop_detected.ViewModels;

public class Item
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
    public Item(string strName, bool blnCheck)
    {
        Name = strName;
        IsCompleted = blnCheck;
    }
}

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<Item> Items { get; }
    public MainViewModel()
    {
        Items = new ObservableCollection<Item>
            {
                new Item("項目01",false),
                new Item("項目02",true)
            };
    }
    public string Greeting => "Welcome to Avalonia!";
}
