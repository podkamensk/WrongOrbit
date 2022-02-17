using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "LobbyPanelSettings", menuName = "Settings/Panels/LobbyPanelSettings")]
    public class LobbyPanelSettings : ScriptableObject
    {
        [SerializeField] public Texture2D _bgImage;
        [SerializeField] public Vector2 _bgImagePivot;

        [SerializeField] public Vector2 _mainPanelImageSizeCoeff;
        [SerializeField] public Vector2 _mainPanelImagePivot;
        [SerializeField] public Vector2 _mainPanelImageCoordsDeviation;
        [SerializeField] public Color _mainPanelColor;

        [SerializeField] public Vector2 _inventoryPanelImageSizeCoeff;
        [SerializeField] public Vector2 _inventoryPanelImagePivot;
        [SerializeField] public Vector2 _inventoryPanelImageCoordsDeviation;
        [SerializeField] public Color _inventoryPanelColor;






        [SerializeField] public int _smth1;
        [SerializeField] public int _smth2;
        [SerializeField] public float _fireRate;
        [SerializeField] public int _burstCount;
        [SerializeField] public float _angleDeviation;
    }

}

