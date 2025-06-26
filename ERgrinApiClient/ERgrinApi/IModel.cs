using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.ModelInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IModel
    {
        string ID { get; }

        string LogicalName { get; set; }

        string Description { get; set; }

        int DomainCount { get; }

        IDomain GetDomain(int index);

        int DictionaryCount { get; }

        IDictionary GetDictionary(int index);

        int DiagramCount { get; }

        IDiagram GetDiagram(int index);

        int EntityCount { get; }

        IEntity GetEntity(int index);

        int UDPCount { get; }

        IUDP GetUDP(int index);

        int UDPValueCount { get; }

        IUDPValue GetUDPValue(int index);

        int GetEntityCountInDiagram(string diagramName);

        IEntity GetEntityInDiagram(string diagramName, int index);

        int GetRelationshipCountInDiagram(string digramName);

        IRelationship GetRelationshipInDiagram(string digramName, int index);

        void AddEntity(string logicalName, string physicalName);

        void AddEntity(string logicalName, string physicalName, string diagramName);
    }
}