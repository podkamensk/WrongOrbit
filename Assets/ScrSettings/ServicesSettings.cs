using System;
using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "ServicesSettings", menuName = "Settings/ServicesSettings")]
    public sealed class ServicesSettings : ScriptableObject
    {
        [SerializeField] public GameObject _coroutineRunnerDummy;

    }
}
