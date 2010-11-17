using System.Windows;
using System.Windows.Media;

namespace CodeMangler.FontBrowser.Models
{
    public class FontListViewItem
    {
        FontFamily _fontFamily;
        string _text;

        public FontListViewItem()
        {
        }

        public FontListViewItem(FontFamily font, string text)
        {
            _fontFamily = font;

            if (string.IsNullOrEmpty(text))
                _text = font.Source;
            else
                _text = text;
        }

        public string Text
        {
            get { return _text; }
        }

        public  FontFamily FontFamily
        {
            get { return _fontFamily; }
        }

        public string FontFamilyName
        {
            get { return _fontFamily.Source; }
        }
    }
}
