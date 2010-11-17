One way to create a custom DataTemplate is to do something like:
	DataTemplate custom = new DataTemplate();
	FrameworkElementFactory controlFactory = new FrameworkElementFactory(typeof(TextArea));
	controlFactory.SetValue(TextArea.Text, "foobar");
	controlFactory.SetValue(...);
	custom.VisualTree = controlFactory;
You can also use DataTemplate.VisualTree.AddChildren(FrameworkElementFactory) to create nested hierarchy and so on..
But basically, the method is extremely cumbersome.

The recommended way to create dynamic elements in for use in WPF is to describe them using XAML itself, but parse and load it dynamically during runtime.
WPF comes with a XamlReader class that provides a Load(...) method to load a XAML resource/stream, and a Parse(...) method to parse and load XAML from a string.
Both of them construct and return an object that matches the root node of the input XAML.

References:
	1. MSDN reference for the FrameworkElementFactory class: http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.aspx
		- This page remarks that the recommended way to programmatically create a template is to load XAML using XamlReader, and points to the class reference..
	2. MSDN reference for XamlReader: http://msdn.microsoft.com/en-us/library/system.windows.markup.xamlreader.aspx
	3. To fix the "cannot find public type named <whatever name>" issue: http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/4e7fbcc8-cdbf-4809-afa7-54f52c02310e
