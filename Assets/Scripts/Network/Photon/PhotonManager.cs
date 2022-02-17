using Photon.Pun;

namespace WrongOrbit
{
    internal sealed class PhotonManager
    {
        private NetworkManager _networkManager;
        private GameBuildSettings _gameBuildSettings;

        private PhotonLogin _photonLogin;
        private RoomManager _roomManager;

        public PhotonManager(NetworkManager networkManager, GameBuildSettings gameBuildSettings)
        {
            _networkManager = networkManager;
            _gameBuildSettings = gameBuildSettings;

            _photonLogin = new PhotonLogin(gameBuildSettings._buildVersion);
            PhotonNetwork.AddCallbackTarget(_photonLogin);
            _photonLogin.PhotonConnectionSuccess += _networkManager.c_OnConnectedToGameServer;
            _photonLogin.PhotonDisconnected += _networkManager.c_OnDisconnectedToGameServer;

            _roomManager = new RoomManager();
            PhotonNetwork.AddCallbackTarget(_roomManager);
            _roomManager.PhotonLobbyEnter += _networkManager.c_OnLobbyEnter;
            _roomManager.PhotonLobbyLeft += _networkManager.c_OnLobbyLeft;
            _roomManager.PhotonRoomInfoUpdate += _networkManager.c_OnRoomListUpdate;

        }

        public void ConnectToMaster()
        {
            _photonLogin.Connect();
        }

        public void DisconnectFromPhoton()
        {
            _photonLogin.Disconnect();
        }

        public bool CheckConnection()
        {
            return PhotonNetwork.IsConnected;
        }

        public void JoinLobby()
        {
            _roomManager.JoinLobby();
        }

        public void LeaveLobby()
        {
            _roomManager.LeaveLobby();
        }

    }
}

