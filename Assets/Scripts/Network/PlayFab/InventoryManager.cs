using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class InventoryManager
    {

        public InventoryManager()
        {
            LoadUserInventory();
        }

        public void LoadUserInventory()
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetInventorySuccess, OnFailure);
        }
        
        private void OnGetInventorySuccess(GetUserInventoryResult result)
        {
            PlayFabGetUserInventorySuccessEventArgs args = new PlayFabGetUserInventorySuccessEventArgs();
            args.InventoryItemsList = result.Inventory;
            args.WalletList = result.VirtualCurrency;
            OnPlayFabGetUserInventorySuccess(args);
        }

        private void OnFailure(PlayFabError error)
        {
            var errorMessage = error.GenerateErrorReport();
            Debug.LogError($"PlayFab Inventroy Manager: Something went wrong: {errorMessage}");
        }


        public void OnPlayFabGetUserInventorySuccess(PlayFabGetUserInventorySuccessEventArgs e)
        {
            EventHandler<PlayFabGetUserInventorySuccessEventArgs> handler = PlayFabGetInventorySuccess;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PlayFabGetUserInventorySuccessEventArgs> PlayFabGetInventorySuccess;

    }
}
