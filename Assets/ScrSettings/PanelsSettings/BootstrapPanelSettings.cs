using TMPro;
using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "BootstrapPanelSettings", menuName = "Settings/Panels/BootstrapPanelSettings")]
    public class BootstrapPanelSettings : ScriptableObject
    {

        [SerializeField] public Texture2D _bootstrapImage;
        [SerializeField] public Vector2 _bootstrapImagePivot;

        [SerializeField] public Vector2 _enterPanelImageSize;
        [SerializeField] public Vector2 _enterPanelImagePivot;
        [SerializeField] public Vector2 _enterPanelImageCoordsDeviation;
        [SerializeField] public Color _enterPanelColor;

        [SerializeField] public Texture2D _enterButtonImage;
        [SerializeField] public Vector2 _enterButtonImageSize;
        [SerializeField] public Vector2 _enterButtonImagePivot;
        [SerializeField] public Vector2 _enterButtonImageCoordsDeviation;

        [SerializeField] public string _enterButtonLabelText;
        [SerializeField] public TextAlignmentOptions _enterButtonLabelAlignment;
        [SerializeField] public Color _enterButtonLabelColor;
        [SerializeField] public int _enterButtonLabelFontHeight;


        [SerializeField] public string _gameTitleText;
        [SerializeField] public TextAlignmentOptions _gameTitleAlignment;
        [SerializeField] public Vector2 _gameTitlePivot;
        [SerializeField] public Vector2 _gameTitleCoordsDeviation;
        [SerializeField] public Color _gameTitleColor;
        [SerializeField] public int _gameTitleFontHeight;
    }

}

