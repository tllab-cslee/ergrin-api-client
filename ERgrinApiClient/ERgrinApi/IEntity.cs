using System.Runtime.InteropServices;

namespace ERgrin.Api
{
    [ComVisible(true)]
    [Guid(ApiGuids.EntityInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEntity
    {
        string ID { get; }

        string LogicalName { get; set; }

        string PhysicalName { get; set; }

        string Description { get; set; }

        int AttributeCount { get; }
        IAttribute GetAttribute(int index);
    }
}