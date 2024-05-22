using ResourcesPropertySheet.Loader;
using System.Drawing;
using System.Windows.Forms;

namespace ResourcesPropertySheet.ResourceEditors
{
    internal partial class IconEditor : UserControl, IResourceEditor
    {
        private Icon iconData;

        public IconEditor()
        {
            InitializeComponent();
        }

        public void Initialise(Win32Resource resource)
        {
            //  Create a byte stream from the data.
            iconData = resource.IconData;
        }

        public void Release()
        {
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(iconData, 0, 0);
        }
    }
}