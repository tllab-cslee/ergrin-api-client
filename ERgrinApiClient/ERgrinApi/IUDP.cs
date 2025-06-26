using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.UDPInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUDP
    {
        string Name { get; }

        string Category { get; }

        string UDPType { get; }

        string DefaultValue { get; }

        string Description { get; }

        int UDPValueCount { get; }

        IUDPValue GetUDPValue(int index);
    }
}