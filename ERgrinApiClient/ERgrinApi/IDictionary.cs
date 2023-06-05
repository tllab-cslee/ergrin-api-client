using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.DictionaryInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDictionary
    {
        string LogicalName { get; set; }

        string PhysicalName { get; set; }

        string Domain { get; set; }

        string Description { get; set; }
    }
}