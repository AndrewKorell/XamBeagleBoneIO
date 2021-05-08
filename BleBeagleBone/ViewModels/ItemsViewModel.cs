using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Contracts; //todo: I should 
using Xamarin.Forms;

using BleBeagleBone.Models;
using BleBeagleBone.Views;
using BleBeagleBone.Services;

namespace BleBeagleBone.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<BtLeDevice> Devices { get; set; }
        public Command LoadItemsCommand { get; set; }

        public IDataStore<BtLeDevice> DataStore => DependencyService.Get<IDataStore<BtLeDevice>>() ?? new ConnectedDeviceStore();

        public ItemsViewModel()
        {
            Title = "Browse";
            Devices = new ObservableCollection<BtLeDevice>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<MainPage, BtLeDevice>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as BtLeDevice;
                Devices.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Devices.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Devices.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}