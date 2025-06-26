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

        bool IsAutoIncrement { get; set; }

        bool IsKey { get; set; }

        bool IsForeignKey { get; }

        string DBOwner { get; set; }

        string DomainName { get; set; }

        string LogicalDataType { get; }

        string PhysicalDataType { get; set; }

        string Description { get; set; }

        bool IsLogicalOnly { get; set; }

        bool IsPhysicalOnly { get; set; }

        bool IsHideInLogical { get; }

        bool IsHideInPhysical { get; }

        string DefaultValueName { get; }

        string DefaultValue { get; }

        int Order { get; }

        int UDPValueCount { get; }

        IUDPValue GetUDPValue(int index);

        void Remove();
    }
}