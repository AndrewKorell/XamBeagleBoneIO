using System;
using System.Collections.Generic;
using System.Text;
using BleBeagleBone.Enumerators;

namespace BleBeagleBone.Models
{
    public class AdvertisingRecordModel
    {
        public AdvertisingRecordModel(AdvertisingRecordType type, byte[] data)
        {
            Type = type;
            Data = data;
        }

        public AdvertisingRecordType Type { get; }

        public byte[] Data { get; }

        public string GetFriendly()
        {
            return Type.ToString() + Data.ToString(); 
        }
    }
}
