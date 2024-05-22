using SharpShell.ServerRegistration;
using System.Collections.ObjectModel;
using Apex.MVVM;

namespace ShellExtensionManager.ShellExtensions
{
    [ViewModel]
    public class ExtensionViewModel : ViewModel
    {
        /// <summary>
        /// The NotifyingProperty for the DisplayName property.
        /// </summary>
        private readonly NotifyingProperty DisplayNameProperty =
          new("DisplayName", typeof(string), default(string));

        /// <summary>
        /// Gets or sets DisplayName.
        /// </summary>
        /// <value>The value of DisplayName.</value>
        public string DisplayName
        {
            get => (string)GetValue(DisplayNameProperty);
            set => SetValue(DisplayNameProperty, value);
        }

        /// <summary>
        /// The NotifyingProperty for the ShellExtensionType property.
        /// </summary>
        private readonly NotifyingProperty ShellExtensionTypeProperty =
          new("ShellExtensionType", typeof(ShellExtensionType), default(ShellExtensionType));

        /// <summary>
        /// Gets or sets ShellExtensionType.
        /// </summary>
        /// <value>The value of ShellExtensionType.</value>
        public ShellExtensionType ShellExtensionType
        {
            get => (ShellExtensionType)GetValue(ShellExtensionTypeProperty);
            set => SetValue(ShellExtensionTypeProperty, value);
        }

        /// <summary>
        /// Gets the ClassRegistrations observable collection.
        /// </summary>
        /// <value>The ClassRegistrations observable collection.</value>
        public ObservableCollection<ClassRegistration> ClassRegistrations { get; } = [];
    }
}