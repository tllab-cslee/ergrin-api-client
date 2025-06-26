using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.UDPValueInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUDPValue
    {
        string OwnerID { get; }

        string OwnerName { get; }

        string ModelName { get; }

        string SubName { get; }

        string EntityName { get; }

        string AttrName { get; }

        string RelName { get; }

        string ID { get; }

        string Key { get; }

        string Value { get; }

        string Description { get; }
    }
}