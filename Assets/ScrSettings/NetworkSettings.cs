using System;
using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "NetworkSettings", menuName = "Settings/NetworkSettings")]
    public sealed class NetworkSettings : ScriptableObject
    {
        [SerializeField] public string _prefsKey;
        [SerializeField] public string _playfabTitleID;

    }
}
