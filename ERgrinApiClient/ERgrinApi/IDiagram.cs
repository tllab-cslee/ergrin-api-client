using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.DiagramInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDiagram
    {
        string ID { get; }

        string Name { get; set; }

        string Description { get; set; }
    }
}