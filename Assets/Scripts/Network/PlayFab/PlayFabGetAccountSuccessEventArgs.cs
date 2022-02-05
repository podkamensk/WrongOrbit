
using System;

namespace WrongOrbit
{
    internal sealed class PlayFabGetAccountSuccessEventArgs : EventArgs
    {
        public string UserName{ get; set; }
        public DateTime CreationDate { get; set; }
    }
}