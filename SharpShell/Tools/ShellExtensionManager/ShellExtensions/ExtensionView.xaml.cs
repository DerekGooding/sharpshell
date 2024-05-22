using System.Windows.Controls;
using Apex.MVVM;

namespace ShellExtensionManager.ShellExtensions
{
    /// <summary>
    /// Interaction logic for ExtensionView.xaml
    /// </summary>
    [View(typeof(ExtensionViewModel))]
    public partial class ExtensionView : UserControl, IView
    {
        public ExtensionView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
        }

        public void OnDeactivated()
        {
        }
    }
}