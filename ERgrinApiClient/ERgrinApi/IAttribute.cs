using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.AttributeInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAttribute
    {
        string ID { get; }

        string LogicalName { get; set; }

        string PhysicalName { get; set; }

        bool Nullable { get; set; }

        bool IsKey { get; set; }

        bool IsForeignKey { get; }

        string DomainName { get; set; }

        string DataType { get; set; }

        string Description { get; set; }
    }
}