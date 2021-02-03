using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using NewtonIntegrator.Views;

namespace NewtonIntegrator
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof (FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));
            var mainWindow = new MainWindowViewModel();
            mainWindow.ShowWindow();
        }
    }
}
