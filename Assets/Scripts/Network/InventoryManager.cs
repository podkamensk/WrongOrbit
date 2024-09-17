using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class InventoryManager
    {
        private readonly Dictionary<string, ItemInstance> _userInventory;
        private readonly Dictionary<string, int> _userWallet;
        public InventoryManager()
        {
            _userInventory = new Dictionary<string, ItemInstance>();
            _userWallet = new Dictionary<string, int>();
        }

        public void LoadUserInventory()
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetInventorySuccess, OnFailure);
            Debug.Log("Loading user inventory and wallet");
        }
        
        private void OnGetInventorySuccess(GetUserInventoryResult result)
        {
            HandleInventory(result.Inventory);
            HandleWallet(result.VirtualCurrency);
            Debug.Log($"User inventory was loaded successfully with {result.Inventory.Count} items!");
            Debug.Log($"User wallet was loaded successfully with {result.VirtualCurrency.Count} currency types!");
        }

        private void OnFailure(PlayFabError error)
        {
            var errorMessage = error.GenerateErrorReport();
            Debug.LogError($"Something went wrong: {errorMessage}");
        }

        private void HandleInventory(List<ItemInstance> inventory)
        {
            foreach (var item in inventory)
            {
                _userInventory.Add(item.ItemId, item);
                Debug.Log($"User inventory {item.ItemId} was added successfully!");
            }
        }

        private void HandleWallet(Dictionary<string, int> wallet)
        {
            foreach (var currency in wallet)
            {
                _userWallet.Add(currency.Key, currency.Value);
            }
            Debug.Log($"User walet was added successfully!");
        }
    }
}