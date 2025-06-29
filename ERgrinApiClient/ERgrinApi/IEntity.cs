﻿using System.Runtime.InteropServices;

namespace ERgrin.Api2
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

        bool IsLogicalOnly { get; set; }

        bool IsPhysicalOnly { get; set; }

        int AttributeCount { get; }

        IAttribute GetAttribute(int index);

        int UDPValueCount { get; }

        IUDPValue GetUDPValue(int index);

        void AddAttribute(string logicalName, string physicalName, bool nullable, bool isKey, string domainName, string physicalDataType, string description);
    }
}