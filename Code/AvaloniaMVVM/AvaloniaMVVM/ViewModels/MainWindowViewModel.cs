using System.Collections.ObjectModel;

namespace AvaloniaMVVM.ViewModels
{
    public class Item
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public Item(string strName,bool blnCheck) 
        {
            Name = strName;
            IsCompleted = blnCheck;
        }
    }

    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item("項目01",false),
                new Item("項目02",true)
            };
        }
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    }
}
