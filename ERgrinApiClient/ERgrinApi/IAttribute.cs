using System.Runtime.InteropServices;

namespace ERgrin.Api
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

        string DomainName { get; set; }

        string DataType { get; set; }

        string Description { get; set; }
    }
}
