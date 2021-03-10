using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArsenalAnalyzer
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            if (Source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source, assembly);

            return imageSource;
        }
    }
}
