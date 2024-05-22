using ServerManager.ShellDebugger;
using SharpShell.Interop;
using SharpShell.SharpThumbnailHandler;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServerManager.TestShell
{
    public partial class ShellThumbnailHost : UserControl
    {
        public ShellThumbnailHost()
        {
            InitializeComponent();
        }

        public void SetThumbnailHandler(SharpThumbnailHandler testThumbnailHandler)
        {
            sharpThumbnailHandler = testThumbnailHandler;
        }

        public void SetPreviewItem(ShellItem shellItem)
        {
            //  Create a stream for the item.
            using var managedStream = new FileStream(shellItem.Path, FileMode.Open, FileAccess.Read);
            var stream = new StreamWrapper(managedStream);
            sharpThumbnailHandler.Initialize(stream, 0);
            ((IThumbnailProvider)sharpThumbnailHandler).GetThumbnail((uint)pictureBox1.Width, out nint bitmapHandle, out WTS_ALPHATYPE alphaType);
            pictureBox1.Image = Image.FromHbitmap(bitmapHandle);
            /*
            var bitmap = (Bitmap) sharpThumbnailHandler.GetType().GetMethod("GetThumbnailImage", BindingFlags.Instance | BindingFlags.NonPublic)
                                                       .Invoke(sharpThumbnailHandler, new object[] { (uint)pictureBox1.Width });

            var hbmp = bitmap.GetHbitmap();
            var converted = Image.FromHbitmap(hbmp);
            pictureBox1.Image = converted;*/
        }

        private SharpThumbnailHandler sharpThumbnailHandler;
    }
}