
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace WrongOrbit 
{
    public class PhotonLogin : MonoBehaviourPunCallbacks
    {
        string _gameVersion = "1"; //hardcode
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true; //later to class init

        }
        // Start is called before the first frame update
        void Start()
        {
            Connect();
        }

        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = _gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster() was called by PUN");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("PHOTON Disconnected: " + cause.ToString());
        }


    }
}


