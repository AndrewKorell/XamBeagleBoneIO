using System;
using System.Collections.Generic;
using System.Text;
using Plugin.BLE;
using BleBeagleBone.Interfaces;
using BleBeagleBone.Models;
using BleBeagleBone.Enumerators;

namespace BleBeagleBone.Adapter
{
    public class PluginBleAdapter : IBtLeInterface
    {
        static protected List<BtLeDevice> SystemDevices = new List<BtLeDevice>();
 
        public PluginBleAdapter()
        {
            RefreshSystemDevices();
        }
    
        public BtLeState GetState()
        {
            return (BtLeState) CrossBluetoothLE.Current.State;
        }

        public IEnumerable<BtLeDevice> GetSystemDevices()
        {
            return SystemDevices;
        }

        public void RefreshSystemDevices()
        {
            SystemDevices.Clear();

            var adapter = CrossBluetoothLE.Current.Adapter;
            var devices = adapter.GetSystemConnectedOrPairedDevices();

            foreach (var device in devices)
            {
                SystemDevices.Add(new BtLeDevice(device));
            }
        }
    }
}
