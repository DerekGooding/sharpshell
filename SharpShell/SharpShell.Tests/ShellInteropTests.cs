using NUnit.Framework;
using SharpShell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpShell.Tests
{
    [TestFixture]
    public class ShellInteropTests
    {
        [Test]
        public void CanGetKnownFolderPath()
        {
            //  We must be able to get the documents known path without throwing an exception.
            _ = Shell32.SHGetKnownFolderPath(KnownFolders.FOLDERID_Documents, KNOWN_FOLDER_FLAG.KF_NO_FLAGS, IntPtr.Zero, out string path);
            Assert.That(path, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void CanGetAndFreeKnownFolderIdList()
        {
            _ = Shell32.SHGetKnownFolderIDList(KnownFolders.FOLDERID_Cookies, KNOWN_FOLDER_FLAG.KF_NO_FLAGS, IntPtr.Zero, out nint pidl);
            Assert.That(pidl != IntPtr.Zero);
            Assert.DoesNotThrow(() => Shell32.ILFree(pidl));
        }

        [Test]
        public void CanGetDesktopFolderLocationAndPath()
        {
            //  Asserts we can get the desktop folder pidl, get a path for it and free the pidl.
            _ = Shell32.SHGetFolderLocation(IntPtr.Zero, CSIDL.CSIDL_DESKTOP, IntPtr.Zero, 0, out nint pidl);
            var sb = new StringBuilder(260);
            Assert.That(Shell32.SHGetPathFromIDList(pidl, sb));
            Assert.That(sb.ToString(), Is.Not.Null.Or.Empty);
            Assert.DoesNotThrow(() => Shell32.ILFree(pidl));
        }

        [Test]
        public void CanEnumerateDesktopFolders()
        {
            //  Asserts that we can correctly use the IEnumIDList interface.

            //  Get the desktop folder.
            _ = Shell32.SHGetDesktopFolder(out IShellFolder desktopFolder);

            //  Create an enumerator and enumerate up to items.
            desktopFolder.EnumObjects(IntPtr.Zero, SHCONTF.SHCONTF_FOLDERS, out IEnumIDList enumerator);
            const int count = 20;
            IntPtr apidl = Marshal.AllocCoTaskMem(IntPtr.Size * count);
            enumerator.Next((uint)count, apidl, out uint fetched);
            var pidls = new IntPtr[fetched];
            Marshal.Copy(apidl, pidls, 0, (int)fetched);

            //  Assert the we can get the display name of each item.
            foreach (var pidl in pidls)
            {
                desktopFolder.GetDisplayNameOf(pidl, SHGDNF.SHGDN_NORMAL, out STRRET name);
                Assert.That(name.GetStringValue(), Is.Not.Null.Or.Empty);
                Assert.DoesNotThrow(() => Marshal.FreeCoTaskMem(pidl));
            }
        }
    }
}