using System;
using System.Collections.Generic;
using BleBeagleBone.Enumerators;
using BleBeagleBone.Models;


namespace BleBeagleBone.Interfaces
{
    public interface IBtLeInterface
    {
        BtLeState GetState();

        IEnumerable<BtLeDevice> GetSystemDevices();

        void RefreshSystemDevices();
    }
}
