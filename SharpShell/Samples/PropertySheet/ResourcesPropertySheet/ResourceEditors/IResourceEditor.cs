using ResourcesPropertySheet.Loader;

namespace ResourcesPropertySheet.ResourceEditors
{
    internal interface IResourceEditor
    {
        void Initialise(Win32Resource resource);

        void Release();
    }
}