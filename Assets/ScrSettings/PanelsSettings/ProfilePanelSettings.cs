using TMPro;
using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "ProfilePanelSettings", menuName = "Settings/Panels/ProfiePanelSettings")]
    public class ProfilePanelSettings : ScriptableObject
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

        [SerializeField] public Vector2 _inventoryNamesStep;
        [SerializeField] public TextAlignmentOptions _inventoryNamesAlignment;
        [SerializeField] public int _inventoryNamesFontHeight;
        [SerializeField] public Color _inventoryNamesColor;

        [SerializeField] public Texture2D _buttonsImage;
        [SerializeField] public Vector2 _buttonsImageSize;
        [SerializeField] public Vector2 _buttonsImagePivot;
        [SerializeField] public Vector2 _buttonsImageCoordsDeviation;
        [SerializeField] public TextAlignmentOptions _buttonsLabelAlignment;
        [SerializeField] public int _buttonsLabelFontHeight;

        [SerializeField] public string _singleButtonLabelText;
        [SerializeField] public Color _singleButtonLabelColor;
        [SerializeField] public string _multiButtonLabelText;
        [SerializeField] public Color _multiButtonLabelColor;
        [SerializeField] public string _shopButtonLabelText;
        [SerializeField] public Color _shopButtonLabelColor;
        [SerializeField] public string _nameChangeButtonLabelText;
        [SerializeField] public Color _nameChangeButtonLabelColor;
        [SerializeField] public string _deleteButtonLabelText;
        [SerializeField] public Color _deleteButtonLabelColor;

        [SerializeField] public Vector2 _currencyPanelImageSizeCoeff;
        [SerializeField] public Vector2 _currencyPanelImagePivot;
        [SerializeField] public Vector2 _currencyPanelImageCoordsDeviation;
        [SerializeField] public Color _currencyPanelColor;

        [SerializeField] public Vector2 _currencyNamesStep;
        [SerializeField] public Vector2 _currencyQtyStep;
        [SerializeField] public TextAlignmentOptions _currencyNamesAlignment;
        [SerializeField] public TextAlignmentOptions _currencyQtyAlignment;
        [SerializeField] public int _currencyNamesFontHeight;
        [SerializeField] public Color _currencyNamesColor;



    }

}

