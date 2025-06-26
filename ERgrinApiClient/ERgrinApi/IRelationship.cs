using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.RelationshipInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IRelationship
    {
        string ID { get; }

        string LogicalName { get; set; }

        string PhysicalName { get; set; }

        string Description { get; set; }

        bool IsLogicalOnly { get; set; }

        bool IsPhysicalOnly { get; set; }

        IEntity SuperEntity { get; }

        IEntity SubEntity { get; }

        int SuperAttributeCount { get; }

        IAttribute GetSuperAttribute(int index);

        int SubAttributeCount { get; }

        IAttribute GetSubAttribute(int index);

        string RelationshipType { get; }

        string Cardinality { get; }

        bool IsNotNull { get; }

        int UDPValueCount { get; }

        IUDPValue GetUDPValue(int index);
    }
}