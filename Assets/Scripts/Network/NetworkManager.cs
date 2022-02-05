using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WrongOrbit
{

    internal sealed class NetworkManager
    {
        private GameBuildSettings _gameBuildSettings;
        private NetworkSettings _networkSettings;
        private PlayFabManager _playFabManager;
        private PhotonManager _photonManager;

        private TheUser _user;
        private GameCatalog _gameCatalog;

        public NetworkManager(TheUser user, GameCatalog gameCatalog, GameBuildSettings gameBuildSettings, NetworkSettings networkSettings)
        {
            _gameCatalog = gameCatalog;
            _user = user;
            _gameBuildSettings = gameBuildSettings;
            _networkSettings = networkSettings;

            _playFabManager = new PlayFabManager(this, _networkSettings);
        }


        public void c_OnPlayFabLogin(object sender, PlayFabLoginEventArgs e)
        {
            _user.UpdateUserLoginData(e.PlayFabID, e.FirstTimeLogin, e.LastLogIn);

            _photonManager = new PhotonManager(_gameBuildSettings);
            _playFabManager.FetchPlayFabAccount();
            _playFabManager.FetchPlayFabCatalog();
            _playFabManager.FetchPlayFabInventory();

            Debug.Log("NetworkManager: PlayFab Login Success with " + e.PlayFabID);
            SceneManager.LoadScene("ProfileScene");   //need to get rid of it here
        }

        public void c_OnPlayFabUserInfoFetch(object sender, PlayFabGetAccountSuccessEventArgs e)
        {
            _user.UpdateUserInfo(e.UserName, e.CreationDate);
            Debug.Log("NetworkManager: PlayFab User Info Received");
        }

        public void c_OnPlayFabCatalogFetch(object sender, PlayFabGetCatalogSuccessEventArgs e)
        {
            foreach (CatalogItem item in e.CatalogItemsList)
            {
                GameItem gItem = new GameItem();
                gItem.CatalogItem = item;
                _gameCatalog.AddToGameCatalog(gItem);
            }
            Debug.Log("NetworkManager: PlayFab Catalog Received");
        }

        public void c_OnPlayFabInventoryFetch(object sender, PlayFabGetUserInventorySuccessEventArgs e)
        {
            var inventory = new Dictionary<string, int>();
            foreach (ItemInstance item in e.InventoryItemsList)
            {
                inventory.Add(item.ItemId, item.RemainingUses.Value);
            }
            _user.UserPossessions.CreateInventory(inventory);

            _user.UserPossessions.CreateWallet(e.WalletList);

            Debug.Log($"NetworkManager: PlayFab User Inventory Received. Items: {_user.UserPossessions.UserInventory.Count}");
            Debug.Log($"NetworkManager: PlayFab User Wallet Received. Items: {_user.UserPossessions.UserWallet.Count}");
        }


        private void ErasePlayFabAccount()
        {
            PlayerPrefs.DeleteAll();
            _user = new TheUser();
            SceneManager.LoadScene("TitleScene");   //SCENE SHOULD NOT BE HERE
        }

    }
}

