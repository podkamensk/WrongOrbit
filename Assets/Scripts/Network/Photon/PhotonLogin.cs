
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System;

namespace WrongOrbit
{

    internal sealed class PhotonLogin : IConnectionCallbacks
    {
        private string _gameVersion;
        

        public PhotonLogin(string buildVersion)
        {
            _gameVersion = buildVersion;
        }


        public void Connect()
        {
            if (!PhotonNetwork.IsConnected)
            {
                Debug.Log("Photon Connecting using settings");
                PhotonNetwork.GameVersion = _gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                OnConnectedToMaster();
            }
        }

        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public void OnConnectedToMaster()
        {
            OnPhotonConnected(new EventArgs());
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            OnPhotonDisconnected(new EventArgs());
        }


        public void OnConnected()
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
            Debug.Log("PhotonLogin: Custom auth failed (?????)");
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
            Debug.Log("PhotonLogin: Custom auth response (?????)");
        }



        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            
        }


        public void OnPhotonConnected(EventArgs e)
        {
            EventHandler<EventArgs> handler = PhotonConnectionSuccess;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnPhotonDisconnected(EventArgs e)
        {
            EventHandler<EventArgs> handler = PhotonDisconnected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgs> PhotonConnectionSuccess;
        public event EventHandler<EventArgs> PhotonDisconnected;
    }
}


