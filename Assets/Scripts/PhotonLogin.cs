
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

namespace WrongOrbit 
{

    public class PhotonLogin : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text _statusText;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;

        private Color _textColorDefault = Color.black;
        private Color _textColorConnected = Color.green;
        private Color _textColorDisconnected = Color.red;

        string _gameVersion = "1"; //hardcode
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            _button.onClick.AddListener(TaskOnClick);

            if (PhotonNetwork.IsConnected)
            {
                _statusText.text = "Photon: connected";
                _statusText.color = _textColorConnected;
                _buttonText.text = "disconnect";
            }
            else
            {
                _statusText.text = "Photon: disconnected";
                _statusText.color = _textColorDefault;
                _buttonText.text = "connect";
            }

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
            _statusText.text = "Photon: connected";
            _statusText.color = _textColorConnected;
            _buttonText.text = "disconnect";
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("PHOTON Disconnected: " + cause.ToString());
            _statusText.text = "Photon: disconnected";
            _statusText.color = _textColorDisconnected;
            _buttonText.text = "connect";
        }

        public void TaskOnClick()
        {
            if (PhotonNetwork.IsConnected)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
            _buttonText.text = "wait";
        }
    }
}


