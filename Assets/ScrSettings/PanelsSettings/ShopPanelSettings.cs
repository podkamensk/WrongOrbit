using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "ShopPanelSettings", menuName = "Settings/Panels/ShopPanelSettings")]
    public class ShopPanelSettings : ScriptableObject
    {

        [SerializeField] public int _smth1;
        [SerializeField] public int _smth2;
        [SerializeField] public float _fireRate;
        [SerializeField] public int _burstCount;
        [SerializeField] public float _angleDeviation;
    }

}
