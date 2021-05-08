using System;
using System.Collections.Generic;
using System.Text;

namespace BleBeagleBone.Enumerators
{
    public enum AdvertisingRecordType
    {
        Flags = 1,
        UuidsIncomple16Bit = 2,
        UuidsComplete16Bit = 3,
        UuidsIncomplete32Bit = 4,
        UuidCom32Bit = 5,
        UuidsIncomplete128Bit = 6,
        UuidsComplete128Bit = 7,
        ShortLocalName = 8,
        CompleteLocalName = 9,
        TxPowerLevel = 10,
        Deviceclass = 13,
        SimplePairingHash = 14,
        SimplePairingRandomizer = 15,
        DeviceId = 16,
        SecurityManager = 17,
        SlaveConnectionInterval = 18,
        SsUuids16Bit = 20,
        SsUuids128Bit = 21,
        ServiceData = 22,
        PublicTargetAddress = 23,
        RandomTargetAddress = 24,
        Appearance = 25,
        DeviceAddress = 27,
        LeRole = 28,
        PairingHash = 29,
        PairingRandomizer = 30,
        SsUuids32Bit = 31,
        ServiceDataUuid32Bit = 32,
        ServiceData128Bit = 33,
        SecureConnectionsConfirmationValue = 34,
        SecureConnectionsRandomValue = 35,
        Information3DData = 61,
        IsConnectable = 170,
        ManufacturerSpecificData = 255
    }
}
