using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.ProjectInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProject
    {
        string Name { get; }

        int DBKind { get; }

        int ModelCount { get; }

        IModel GetModel(int index);

        void Apply(string filePath);

        void Load(string filepath);

        void Create();

        void SetIPCId(string ipcId);

        void SendIPCMessage(string msgId, string arg);
    }
}