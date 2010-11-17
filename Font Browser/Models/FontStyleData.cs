using System.Windows;
using System.Windows.Media;

namespace CodeMangler.FontBrowser.Models
{
    public class FontStyleData
    {
        string _name;
        FontStyle _fontStyle;
        FontWeight _fontWeight;
        TextDecorationLocation? _textDecoration;
        FontVariants _fontVariant;
        FontCapitals _fontCapitals;
        double _fontSize;

        public FontStyleData(string name, FontStyle fontStyle, FontWeight fontWeight, TextDecorationLocation? textDecoration, FontVariants fontVariant, FontCapitals fontCapitals, double fontSize)
        {
            _name = name;
            _fontStyle = fontStyle;
            _fontWeight = fontWeight;
            _textDecoration = textDecoration;
            _fontVariant = fontVariant;
            _fontCapitals = fontCapitals;
            _fontSize = fontSize;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }

        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set { _fontWeight = value; }
        }

        public TextDecorationLocation? TextDecoration
        {
            get { return _textDecoration; }
            set { _textDecoration = value; }
        }

        public FontVariants FontVariant
        {
            get { return _fontVariant; }
            set { _fontVariant = value; }
        }

        public FontCapitals FontCapitals
        {
            get { return _fontCapitals; }
            set { _fontCapitals = value; }
        }

        public double FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }
    }
}
