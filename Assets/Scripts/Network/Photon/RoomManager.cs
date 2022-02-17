
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;

namespace WrongOrbit
{
    internal sealed class RoomManager : ILobbyCallbacks, IMatchmakingCallbacks
    {
        private LoadBalancingClient _loadBalancingClient;

        public RoomManager()
        {
            _loadBalancingClient = new LoadBalancingClient();
        }

        public void JoinLobby()
        {
            PhotonNetwork.JoinLobby();
        }
        public void LeaveLobby()
        {
            PhotonNetwork.LeaveLobby();
        }

        public void OnJoinedLobby()
        {
            OnLobbyEnter(new EventArgs());
        }


        public void OnLeftLobby()
        {
            OnLobbyLeft(new EventArgs());
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            var args = new PhotonRoomListUpdateEventArgs();
            args.RoomInfoList = roomList;
            OnRoomListUpdate(args);
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {

        }


        public void OnLobbyEnter(EventArgs e)
        {
            EventHandler<EventArgs> handler = PhotonLobbyEnter;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnLobbyLeft(EventArgs e)
        {
            EventHandler<EventArgs> handler = PhotonLobbyLeft;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnRoomListUpdate(PhotonRoomListUpdateEventArgs e)
        {
            EventHandler<PhotonRoomListUpdateEventArgs> handler = PhotonRoomInfoUpdate;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgs> PhotonLobbyEnter;
        public event EventHandler<EventArgs> PhotonLobbyLeft;
        public event EventHandler<PhotonRoomListUpdateEventArgs> PhotonRoomInfoUpdate;













        public void CreateRoom(string roomName, byte maxPlayers)
        {
            var rmOptions = new RoomOptions();
            rmOptions.MaxPlayers = maxPlayers;
            rmOptions.IsOpen = true;

            EnterRoomParams enterRoomParams = new EnterRoomParams();
            enterRoomParams.RoomName = roomName;
            enterRoomParams.RoomOptions = rmOptions;
            _loadBalancingClient.OpCreateRoom(enterRoomParams);
        }


        public void OpenRoom(Room room)
        {
            room.IsOpen = true;
        }
        public void CloseRoom(Room room)
        {
            room.IsOpen = false;
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            throw new System.NotImplementedException();
        }

        public void OnCreatedRoom()
        {
            throw new System.NotImplementedException();
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnJoinedRoom()
        {
            throw new System.NotImplementedException();
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            throw new System.NotImplementedException();
        }

        public void OnLeftRoom()
        {
            throw new System.NotImplementedException();
        }



    }

}

