using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class PhotonManager
    {
        private GameBuildSettings _gameBuildSettings;
        private PhotonLogin _photonLogin;

        public PhotonManager(GameBuildSettings gameBuildSettings)
        {
            _gameBuildSettings = gameBuildSettings;
            Debug.Log("PhotonManager initialized!!!!");
        }
    }
}

