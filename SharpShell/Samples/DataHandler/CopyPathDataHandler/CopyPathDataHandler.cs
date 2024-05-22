using SharpShell.Attributes;
using SharpShell.SharpDataHandler;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CopyPathDataHandler
{
    [ComVisible(true)]
    [DisplayName("Copy Path Data Handler")]
    [COMServerAssociation(AssociationType.Directory)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class CopyPathDataHandler : SharpDataHandler
    {
        /// <summary>
        /// Gets the data for the selected item. The selected item's path is stored in the SelectedItemPath property.
        /// </summary>
        /// <returns>
        /// The data for the selected item, or null if there is none.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override DataObject GetData()
        {
            //  Create a data object.
            var dataObject = new DataObject();

            //  Set the path as the data.
            dataObject.SetData(DataFormats.UnicodeText, SelectedItemPath);

            //  Return the data object.
            return dataObject;
        }
    }
}