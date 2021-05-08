using BleBeagleBone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE;
using System.Diagnostics;
using BleBeagleBone.Adapter;
using BleBeagleBone.Services;

namespace BleBeagleBone.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);

            GetSystemDevices();
        }

        public void GetSystemDevices()
        {
            var ble = new PluginBleAdapter();
            var devices = ble.GetSystemDevices();

            foreach(var device in devices)
            {
                MessagingCenter.Send<MainPage, BtLeDevice>(this, "AddItem", device);
            }
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Bluetooth:
                        MenuPages.Add(id, new NavigationPage(new BluetoothAboutPage()));
                        break;
                } //todo: Menupages should be defined along with the MenuItemType enum 
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}