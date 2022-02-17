using Photon.Realtime;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WrongOrbit
{

    internal sealed class NetworkManager
    {
        private PlayFabManager _playFabManager;
        private PhotonManager _photonManager;
        
        private TheUser _user;
        private GameCatalog _gameCatalog;
        private List<RoomInfo> _roomList;

        public NetworkManager(TheUser user, GameCatalog gameCatalog, GameBuildSettings gameBuildSettings, NetworkSettings networkSettings)
        {
            _user = user;
            _gameCatalog = gameCatalog;

            _playFabManager = new PlayFabManager(this, networkSettings);
            _photonManager = new PhotonManager(this, gameBuildSettings);
        }


        public void GameServerConnect()
        {
            _photonManager.ConnectToMaster();
        }
        public void GameServerDisonnect()
        {
            _photonManager.DisconnectFromPhoton();
        }
        public bool CheckGameServerConnection()
        {
            return _photonManager.CheckConnection();
        }
        public void JoinGameLobby()
        {
            _photonManager.JoinLobby();
        }
        public void LeaveGameLobby()
        {
            _photonManager.LeaveLobby();
        }

        public void EraseUserAccount()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("NetworkManager: PlayerPrefs Deleted");
        }


        public void c_OnPlayFabLogin(object sender, PlayFabLoginEventArgs e)
        {
            _user.UpdateUserLoginData(e.PlayFabID, e.FirstTimeLogin, e.LastLogIn);
            Debug.Log("NetworkManager: PlayFab Login Success with " + e.PlayFabID);

            _playFabManager.FetchPlayFabAccount();
            _playFabManager.FetchPlayFabCatalog();
            _playFabManager.FetchPlayFabInventory();
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
            Debug.Log($"NetworkManager: PlayFab Catalog Received. Catalog items: {_gameCatalog.CatalogItems.Count}");
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

        public void c_OnConnectedToGameServer(object sender, EventArgs e)
        {
            Debug.Log($"NetworkManager: Connected to Game Server");
        }
        public void c_OnDisconnectedToGameServer(object sender, EventArgs e)
        {
            Debug.Log($"NetworkManager: Connected to Game Server");
        }
        public void c_OnLobbyEnter(object sender, EventArgs e)
        {
            Debug.Log($"NetworkManager: Entered the Lobby");
        }
        public void c_OnLobbyLeft(object sender, EventArgs e)
        {
            Debug.Log($"NetworkManager: Left the Lobby");
        }
        public void c_OnRoomListUpdate(object sender, PhotonRoomListUpdateEventArgs e)
        {
            _roomList = e.RoomInfoList;
            Debug.Log($"NetworkManager: Room List Updated. Quantity: {_roomList.Count}");
        }
    }
}

