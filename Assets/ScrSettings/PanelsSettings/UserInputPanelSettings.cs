using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "UserInputPanelSettings", menuName = "Settings/Panels/UserInputPanelSettings")]
    public class UserInputPanelSettings : ScriptableObject
    {

        [SerializeField] public int _smth1;
        [SerializeField] public int _smth2;
        [SerializeField] public float _fireRate;
        [SerializeField] public int _burstCount;
        [SerializeField] public float _angleDeviation;
    }

}
