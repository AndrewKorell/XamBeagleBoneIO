using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleBeagleBone.Models;

namespace BleBeagleBone.Services
{
    public class ConnectedDeviceStore : IDataStore<BtLeDevice>
    {
        List<BtLeDevice> devices;

        public ConnectedDeviceStore()
        {
            devices = new List<BtLeDevice>();
        }

        public async Task<bool> AddItemAsync(BtLeDevice item)
        {
            devices.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = devices.Where((BtLeDevice arg) => arg.Id == id).FirstOrDefault();
            devices.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<BtLeDevice> GetItemAsync(Guid id)
        {
            return await Task.FromResult(devices.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<BtLeDevice>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(devices);
        }

        public Task<bool> UpdateItemAsync(BtLeDevice item)
        {
            throw new NotImplementedException();
        }
    }
}
