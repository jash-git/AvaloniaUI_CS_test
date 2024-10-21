using System.Collections.ObjectModel;

namespace AvaloniaMVVM.ViewModels
{
    public class Item
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item { Name = "任務一", IsCompleted = false },
                new Item { Name = "任務二", IsCompleted = true },
                // ... 其他項目
            };
        }
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
    }
}
