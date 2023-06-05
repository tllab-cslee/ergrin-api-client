using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.ProjectInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProject
    {
        string Name { get; }

        int ModelCount { get; }
        IModel GetModel(int index);

        void Apply(string filePath);

        void Load(string filepath);
    }
}