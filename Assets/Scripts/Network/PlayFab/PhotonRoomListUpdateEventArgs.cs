
using Photon.Realtime;
using System;
using System.Collections.Generic;

namespace WrongOrbit
{
    internal sealed class PhotonRoomListUpdateEventArgs : EventArgs
    {
        public List<RoomInfo> RoomInfoList { get; set; }
    }
}