using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameBuildSettings", menuName = "Settings/GameBuildSettings")]
public sealed class GameBuildSettings : ScriptableObject
{
    [SerializeField] public string _buildVersion;
}
