using System.Windows.Input;

namespace CodeMangler.FontBrowser
{
    public static class Commands
    {
        public static readonly RoutedUICommand NewStyle = new RoutedUICommand("New Style", "NewStyle", typeof(MainWindow));
        public static readonly RoutedUICommand EditStyle = new RoutedUICommand("Edit Style", "EditStyle", typeof(MainWindow));
        public static readonly RoutedUICommand RemoveStyle = new RoutedUICommand("Remove Style", "RemoveStyle", typeof(MainWindow));
    }
}
