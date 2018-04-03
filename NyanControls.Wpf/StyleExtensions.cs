namespace NyanControls.Wpf
{
    using System;
    using System.Windows;
    using System.Windows.Markup;

    public class ProgressBarStyleExtension : MarkupExtension
    {
        private static readonly ResourceDictionary ResourceDictionary =
            new ResourceDictionary { Source = new Uri("/NyanControls.Wpf;component/ProgressBar.xaml", UriKind.Relative) };

        public override object ProvideValue(IServiceProvider serviceProvider) => ResourceDictionary["NYAN_ProgressBar"];
    }
}
