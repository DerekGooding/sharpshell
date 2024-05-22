using SharpShell.Pidl;
using SharpShell.SharpNamespaceExtension;
using System.Drawing;

namespace GitHubNamespaceExtension
{
    public class GitHubBranch : IShellNamespaceItem
    {
        public GitHubBranch()
        {
        }

        public string Name { get; set; }

        public ShellId GetShellId()
        {
            return ShellId.FromString(Name);
        }

        public string GetDisplayName(DisplayNameContext displayNameContext)
        {
            return Name;
        }

        public AttributeFlags GetAttributes()
        {
            return AttributeFlags.IsReadOnly;
        }

        public Icon GetIcon()
        {
            return null;
        }
    }
}