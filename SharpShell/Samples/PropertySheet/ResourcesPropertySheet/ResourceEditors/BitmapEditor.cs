using ResourcesPropertySheet.Loader;
using System.Windows.Forms;

namespace ResourcesPropertySheet.ResourceEditors
{
    internal partial class BitmapEditor : UserControl, IResourceEditor
    {
        public BitmapEditor()
        {
            InitializeComponent();
        }

        public void Initialise(Win32Resource resource)
        {
            //  Create a byte stream from the data.
            this.pictureBoxPreview.Image = resource.BitmapData;
        }

        public void Release()
        {
            this.pictureBoxPreview.Image = null;
        }
    }
}