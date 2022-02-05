using PlayFab.ClientModels;
using System;
using System.Collections.Generic;

namespace WrongOrbit
{
    internal sealed class PlayFabGetUserInventorySuccessEventArgs : EventArgs
    {
        public List<ItemInstance> InventoryItemsList { get; set; }
        public Dictionary<string, int> WalletList { get; set; }
    }
}
