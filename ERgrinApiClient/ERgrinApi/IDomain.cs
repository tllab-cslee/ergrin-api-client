﻿using System.Runtime.InteropServices;

namespace ERgrin.Api2
{
    [ComVisible(true)]
    [Guid(ApiGuids.DomainInterface)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDomain
    {
        string Name { get; set; }

        string ParentName { get; set; }

        string DataType { get; set; }

        //string DefaultValue { get; set; }

        string Description { get; set; }
    }
}