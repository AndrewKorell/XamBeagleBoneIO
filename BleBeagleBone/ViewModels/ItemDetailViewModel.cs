using System;

using BleBeagleBone.Models;

namespace BleBeagleBone.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public BtLeDevice Item { get; set; }
        public ItemDetailViewModel(BtLeDevice item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
