using BleBeagleBone.Enumerators;
using BleBeagleBone.Models;
using BleBeagleBone.Interfaces;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts; //todo: I should change this to my own model 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BleBeagleBone.Adapter
{
    public class PluginBleDeviceAdapter : IBtLeDeviceInterface
    {
        protected IDevice Device;

        public PluginBleDeviceAdapter(IDevice device)
        {
            Device = device;
        }

        public Guid GetGuid() { return Device.Id; }

        public int Rssi() { return Device.Rssi; }

        public object GetNativeDevice() { return Device.NativeDevice; }

        //enum BtLeDeviceState is a One-to-One copy of Plugin.Ble device state 
        public BtLeDeviceState GetDeviceState() { return (BtLeDeviceState)Device.State; }

        public IEnumerable<AdvertisingRecordModel> GetAdvertisementRecords()
        {
            var records = Device.AdvertisementRecords;
            AdvertisingRecordModel[] adaptedArray = new AdvertisingRecordModel[records.Count];
            for(int i = 0; i < records.Count; i++)
            {
                adaptedArray[i] = new AdvertisingRecordModel((AdvertisingRecordType) records[i].Type, records[i].Data);
            }
            return adaptedArray;
        }

        public bool UpdateConnectionInterval(BtBleConnectInterval interval)
        {
            return Device.UpdateConnectionInterval((Plugin.BLE.Abstractions.ConnectionInterval)interval);
        }

        public async Task<IReadOnlyList<IService>> GetServicesAsync()
        {
            IReadOnlyList<IService> a = await Device.GetServicesAsync();

            return a;
        }
        
    }
}
