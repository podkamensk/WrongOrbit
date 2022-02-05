
using System;

namespace WrongOrbit
{
    internal sealed class PlayFabLoginEventArgs : EventArgs
    {
        public string PlayFabID { get; set; }
        public bool FirstTimeLogin { get; set; }
        public DateTime? LastLogIn { get; set; }
    }
}

