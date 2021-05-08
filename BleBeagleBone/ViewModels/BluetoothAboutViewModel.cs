using System.Windows.Input;
using Xamarin.Forms;
using BleBeagleBone.Adapter;
using System;

namespace BleBeagleBone.ViewModels
{
    public class BluetoothAboutViewModel : BaseViewModel
    {
        private PluginBleAdapter bt;
        public ICommand RefreshBle { get; }

        public ICommand StartScan { get; }

        public ICommand StopScan { get; }

        public BluetoothAboutViewModel()
        {
            Title = "Bluetooth About";

            RefreshBle = new Command(() => UpdateBleState());
            StartScan = new Command(() => StartDeviceScan());
            StopScan = new Command(() => StopDeviceScan());

            bt = new PluginBleAdapter(); 
       
        }

        private void ScanTimeoutElapsed(object sender, EventArgs e)
        {

        }

        //private void BleStateChanged(object sender, BluetoothStateChangedArgs e)
        //{
        //    UpdateBleState();
        //}

        private void UpdateBleState()
        {
            State = bt.GetState().ToString();
        }

        string state = string.Empty;
        public string State 
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

        private void StartDeviceScan()
        {
            IsBusy = true;
            //_adapter.StartScanningForDevicesAsync();
        }

        private void StopDeviceScan()
        {
            //_adapter.StopScanningForDevicesAsync();
            IsBusy = false;
        }

    }
}
