using System.Collections.Generic;
using System.Drawing.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Markup;
using CodeMangler.FontBrowser.Models;

namespace CodeMangler.FontBrowser
{
    public partial class MainWindow : Window
    {
        List<FontListViewItem> _fontListItems = new List<FontListViewItem>();
        List<FontStyleData> _styleColumns = new List<FontStyleData>();
        List<FontFamily> _allFonts = new List<FontFamily>();
        private const string DATA_TEMPLATE_TEMPLATE = @"<DataTemplate 
                                                            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                                            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                                                            xmlns:fb=""http://CodeMangler.FontBrowser/Models""
                                                            DataType=""{{x:Type fb:FontListViewItem}}"">
                                                            <TextBlock Text=""{{Binding Text}}"" FontFamily=""{{Binding FontFamilyName}}"" FontWeight=""{0}"" FontStyle=""{1}"" FontSize=""{2}"" TextDecorations=""{3}"" />
                                                        </DataTemplate>";

        public MainWindow()
        {
            InitializeComponent();
            initializeFontList();

            populateSampleStyles();
            BindFontList();
        }

        private void populateSampleStyles()
        {
            _styleColumns.Add(new FontStyleData("Normal", FontStyles.Normal, FontWeights.Normal, null, FontVariants.Normal, FontCapitals.Normal, 14));
            _styleColumns.Add(new FontStyleData("Bold", FontStyles.Normal, FontWeights.Bold, null, FontVariants.Normal, FontCapitals.Normal, 14));
            _styleColumns.Add(new FontStyleData("Italic", FontStyles.Italic, FontWeights.Normal, null, FontVariants.Normal, FontCapitals.Normal, 14));
        }

        private void initializeFontList()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (System.Drawing.FontFamily fontFamily in installedFonts.Families)
                _allFonts.Add(new FontFamily(fontFamily.Name));
        }

        private void BindFontList()
        {
            lstFonts.Items.Clear();
            AddStyleColumns(lstFonts);
            
            foreach (FontFamily fontFamily in _allFonts)
                lstFonts.Items.Add(new FontListViewItem(fontFamily, txtSample.Text));
        }

        private void AddStyleColumns(ListView lstFonts)
        {
            GridView gridView = lstFonts.View as GridView;

            removeAllExceptFirstColumn(gridView);

            foreach (FontStyleData fontStyle in _styleColumns)
                AddStyleColumn(fontStyle, gridView);
        }

        private void removeAllExceptFirstColumn(GridView gridView)
        {
            for (int i = gridView.Columns.Count - 1; i > 0; i--)
                gridView.Columns.RemoveAt(i);
        }

        private void AddStyleColumn(FontStyleData fontStyle, GridView gridView)
        {
            DataTemplate dataTemplate = (DataTemplate) XamlReader.Parse(string.Format(DATA_TEMPLATE_TEMPLATE, fontStyle.FontWeight, fontStyle.FontStyle, fontStyle.FontSize, fontStyle.TextDecoration));
            GridViewColumn column = new GridViewColumn() { Header = fontStyle.Name };
            column.CellTemplate = dataTemplate;
            gridView.Columns.Add(column);
        }

        private void txtSample_LostFocus(object sender, RoutedEventArgs e)
        {
            BindFontList();
        }

        private void CreateNewStyle(object sender, ExecutedRoutedEventArgs e)
        {
            FontStyleDialog fontStyleDialog = new FontStyleDialog();
            if (fontStyleDialog.ShowDialog().GetValueOrDefault())
            {
                _styleColumns.Add(fontStyleDialog.SelectedFontStyle);
                BindFontList();
            }
        }
    }
}
