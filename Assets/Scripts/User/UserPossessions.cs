using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UserPossessions
    {

        private Dictionary<string, int> _userInventory;
        private Dictionary<string, int> _userWallet;

        public Dictionary<string, int> UserInventory { get => _userInventory; }
        public Dictionary<string, int> UserWallet { get => _userWallet; }

        public UserPossessions()
        {

        }

        public void CreateInventory(Dictionary<string, int> inventory)
        {
            if (_userInventory == null)
            {
                _userInventory = new Dictionary<string, int>();
            }
            _userInventory = inventory;
            Debug.Log($"The USER: User Inventory Data Received: {_userInventory.Count}");
        }

        public void CreateInventory()
        {
            CreateInventory(new Dictionary<string, int>());
        }

        public void CreateWallet(Dictionary<string, int> wallet)
        {
            if (_userWallet == null)
            {
                _userWallet = new Dictionary<string, int>();
            }
            _userWallet = wallet;
            Debug.Log($"The USER: User Wallet Data Received: {_userWallet.Count}");
        }

        public void CreateWallet()
        {
            CreateWallet(new Dictionary<string, int>());
        }

    }
}

