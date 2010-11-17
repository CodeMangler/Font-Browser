using System.Windows;
using CodeMangler.FontBrowser.Models;

namespace CodeMangler.FontBrowser
{
    public partial class FontStyleDialog : Window
    {
        private FontStyleData _selectedFontStyle;

        public FontStyleDialog()
        {
            InitializeComponent();
        }

        public FontStyleData SelectedFontStyle
        {
            get { return _selectedFontStyle; }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            _selectedFontStyle = styleControl.FontStyleData;
            DialogResult = true;
        }
    }
}
