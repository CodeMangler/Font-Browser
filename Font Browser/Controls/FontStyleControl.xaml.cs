using CodeMangler.FontBrowser.Models;
using System.Windows.Controls;
using System.Windows;
using System;

namespace CodeMangler.FontBrowser.Controls
{
	public partial class FontStyleControl : UserControl
	{
        private double[] STANDARD_FONT_SIZES = { 8, 9, 10, 10.5, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        
        private FontStyleData _fontStyleData;

		public FontStyleControl() : this(new FontStyleData(string.Empty, FontStyles.Normal, FontWeights.Regular, null, FontVariants.Normal, FontCapitals.Normal, 14))
		{
		}

        public FontStyleControl(FontStyleData fontStyleData)
        {
            this.InitializeComponent();
            _fontStyleData = fontStyleData;

            bindFontSizes();
            populateControls();
        }

        public FontStyleData FontStyleData
        {
            get { return _fontStyleData; }
        }

        private void bindFontSizes()
        {
            cmbFontSize.ItemsSource = STANDARD_FONT_SIZES;
        }

        private void populateControls()
        {
            txtStyleName.Text = _fontStyleData.Name;
            cmbFontSize.SelectedValue = _fontStyleData.FontSize;
            
            chkBold.IsChecked = _fontStyleData.FontWeight == FontWeights.Bold;

            chkItalic.IsChecked = _fontStyleData.FontStyle == FontStyles.Italic;

            chkUnderline.IsChecked = _fontStyleData.TextDecoration == TextDecorationLocation.Underline;
            chkBaseline.IsChecked = _fontStyleData.TextDecoration == TextDecorationLocation.Baseline;
            chkStrikethrough.IsChecked = _fontStyleData.TextDecoration == TextDecorationLocation.Strikethrough;
            chkOverline.IsChecked = _fontStyleData.TextDecoration == TextDecorationLocation.OverLine;

            chkSuperscript.IsChecked = _fontStyleData.FontVariant == FontVariants.Superscript;
            chkSubscript.IsChecked = _fontStyleData.FontVariant == FontVariants.Subscript;
        }

        private void txtStyleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _fontStyleData.Name = txtStyleName.Text;
        }

        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _fontStyleData.FontSize = cmbFontSize.SelectedValue != null ? Convert.ToDouble(cmbFontSize.SelectedValue) : 14;
        }

        private void weightChanged(object sender, RoutedEventArgs e)
        {
            _fontStyleData.FontWeight = (chkBold.IsChecked == true) ? FontWeights.Bold : FontWeights.Normal; // == true ? required since IsChecked is bool? and not just bool
        }

        private void styleChanged(object sender, RoutedEventArgs e)
        {
            _fontStyleData.FontStyle = (chkItalic.IsChecked == true) ? FontStyles.Italic : FontStyles.Normal;
        }

        private void decorationChanged(object sender, RoutedEventArgs e)
        {
            deselectOtherDecorationCheckboxes(sender as CheckBox);

            _fontStyleData.TextDecoration = null; // No decoration
            if (chkBaseline.IsChecked == true)
                _fontStyleData.TextDecoration = TextDecorationLocation.Baseline;
            if (chkOverline.IsChecked == true)
                _fontStyleData.TextDecoration = TextDecorationLocation.OverLine;
            if (chkStrikethrough.IsChecked == true)
                _fontStyleData.TextDecoration = TextDecorationLocation.Strikethrough;
            if (chkUnderline.IsChecked == true)
                _fontStyleData.TextDecoration = TextDecorationLocation.Underline;
        }

        private void deselectOtherDecorationCheckboxes(CheckBox checkBox)
        {
            if (checkBox == null || checkBox.IsChecked == false) // If no checkbox or if the event was for deselection, ignore it..
                return;

            // Deselect all checkboxes except the one that originated this event..
            if (checkBox != chkBaseline)
                chkBaseline.IsChecked = false;
            if (checkBox != chkOverline)
                chkOverline.IsChecked = false;
            if (checkBox != chkStrikethrough)
                chkStrikethrough.IsChecked = false;
            if (checkBox != chkUnderline)
                chkUnderline.IsChecked = false;
        }

        private void variantChanged(object sender, RoutedEventArgs e)
        {
            deselectOtherVariantCheckboxes(sender as CheckBox);

            _fontStyleData.FontVariant = FontVariants.Normal; // Start by resetting, and set value according to selection later..

            if (chkSuperscript.IsChecked == true)
                _fontStyleData.FontVariant = FontVariants.Superscript;
            if (chkSubscript.IsChecked == true)
                _fontStyleData.FontVariant = FontVariants.Subscript;
        }

        private void deselectOtherVariantCheckboxes(CheckBox checkBox)
        {
            if (checkBox == null || checkBox.IsChecked == false) // If no checkbox or if the event was for deselection, ignore it..
                return;

            if (checkBox != chkSuperscript)
                chkSuperscript.IsChecked = false;
            if (checkBox != chkSubscript)
                chkSubscript.IsChecked = false;
        }
	}
}