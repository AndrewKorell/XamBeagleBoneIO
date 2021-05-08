using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts; //todo: I should change this to my own model  
using BleBeagleBone.Interfaces;
using BleBeagleBone.ViewModels;


namespace BleBeagleBone.Models
{

    public class BtLeDevice : BaseViewModel
    {
        public BtLeDevice(string name)
        {
            Id = new Guid();
            Name = name;
        }

        public BtLeDevice(IDevice device)
        {
            Id = device.Id;
            Name = device.Name;
            Rssi = device.Rssi;
            NativeDevice = device.NativeDevice;
            State = device.State.ToString();
            AdvertisementRecords = device.AdvertisementRecords;
            Device = device;

            _advertisement = Device?.AdvertisementRecords;

            UpdateServicesAsync();
        }

        private async void UpdateServicesAsync()
        {
            if(Device != null)
                _services = await Device.GetServicesAsync();
        }

        private IList<AdvertisementRecord> _advertisement;
        private IReadOnlyList<IService> _services;

        public Guid Id { get; }

        public string Name { get; }

        public int Rssi { get; }

        public object NativeDevice { get; }

        string state = "unknown";
        public string State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

        public IList<AdvertisementRecord> AdvertisementRecords { get; }

        public IDevice Device { get;  }

        public void UpdateState()
        {
            State = Device.State.ToString();
        }
    }
}
