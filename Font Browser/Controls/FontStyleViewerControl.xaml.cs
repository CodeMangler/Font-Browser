using System.Windows.Controls;
using CodeMangler.FontBrowser.Models;

namespace CodeMangler.FontBrowser.Controls
{
    /// <summary>
    /// Interaction logic for FontStyleViewerControl.xaml
    /// </summary>
    public partial class FontStyleViewerControl : UserControl
    {
        public FontStyleViewerControl()
        {
            InitializeComponent();
        }

        public FontListViewItem FontListViewItem
        {
            set
            {
                var fontListViewItem = value;
                if(fontListViewItem != null)
                {
                    fontName.Text = fontListViewItem.FontFamilyName;
                    fontSample.Text = fontListViewItem.Text;
                    fontSample.FontFamily = fontListViewItem.FontFamily;
                }
            }
        }

        public FontStyleData FontStyleData
        {
            set
            {
                var fontStyleData = value;
                if (fontStyleData != null)
                {
                    fontSample.FontWeight = fontStyleData.FontWeight;
                    fontSample.FontStyle = fontStyleData.FontStyle;
                    fontSample.FontSize = fontStyleData.FontSize;
                }
            }
        }
    }
}
