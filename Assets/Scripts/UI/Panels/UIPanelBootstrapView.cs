using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WrongOrbit
{
    internal sealed class UIPanelBootstrapView : IUIPanelView
    {
        private UIPanelBootstrapController _controller;
        private List<GameObject> _gameObjectList;
        private GameObject _panelLocker;


        private Image _image;
        private Image _panelEnter;
        private TextMeshProUGUI _gameTitle;
        private Button _button;
        private Image _buttonImage;
        private TextMeshProUGUI _buttonTitle;


        public IUIPanelController Controller { set => _controller = (UIPanelBootstrapController)value; }

        public UIPanelBootstrapView(BootstrapPanelSettings panelSettings)
        {
            _gameObjectList = new List<GameObject>();

            //FIND CANVAS
            var canvas = GameObject.Find("Canvas");
            float scrWidth = canvas.GetComponent<RectTransform>().rect.width;
            float scrHeight = canvas.GetComponent<RectTransform>().rect.height;
            float aspectRatio = scrWidth / scrHeight;

            //IMAGE

            float sourceAspect = panelSettings._bootstrapImage.width / panelSettings._bootstrapImage.height;

            Sprite sprite;
            float offset;
            if (sourceAspect >= aspectRatio)
            {
                offset = (panelSettings._bootstrapImage.width - panelSettings._bootstrapImage.height * aspectRatio) / 2;
                sprite = Sprite.Create(panelSettings._bootstrapImage, new Rect(offset, 0, panelSettings._bootstrapImage.height * aspectRatio, panelSettings._bootstrapImage.height), panelSettings._bootstrapImagePivot);
            }
            else
            {
                offset = (panelSettings._bootstrapImage.height - panelSettings._bootstrapImage.width / aspectRatio) / 2;
                sprite = Sprite.Create(panelSettings._bootstrapImage, new Rect(0, offset, panelSettings._bootstrapImage.width, panelSettings._bootstrapImage.width / aspectRatio), panelSettings._bootstrapImagePivot);
            }


            var imageObj = new GameObject();
            _image = imageObj.AddComponent<Image>();
            _image.sprite = sprite;
            imageObj.transform.SetParent(canvas.transform);
            imageObj.transform.localPosition = Vector2.zero;
            _image.rectTransform.pivot = panelSettings._bootstrapImagePivot;
            _image.rectTransform.sizeDelta = new Vector2(scrWidth, scrHeight);
            _gameObjectList.Add(imageObj);

            // PANEL 
            var panelEnterObj = new GameObject();
            _panelEnter = panelEnterObj.AddComponent<Image>();
            panelEnterObj.transform.SetParent(imageObj.transform);
            panelEnterObj.transform.localPosition = panelSettings._enterPanelImageCoordsDeviation;
            _panelEnter.rectTransform.pivot = panelSettings._enterPanelImagePivot;
            _panelEnter.rectTransform.sizeDelta = panelSettings._enterPanelImageSize;
            _panelEnter.color = panelSettings._enterPanelColor;
            _gameObjectList.Add(panelEnterObj);

            //TITLE TEXT
            var gameTitleObj = new GameObject();
            gameTitleObj.transform.SetParent(panelEnterObj.transform);
            gameTitleObj.transform.localPosition = panelSettings._gameTitleCoordsDeviation;

            _gameTitle = gameTitleObj.AddComponent<TextMeshProUGUI>();
            _gameTitle.rectTransform.pivot = panelSettings._gameTitlePivot;
            _gameTitle.rectTransform.sizeDelta = panelSettings._enterPanelImageSize;
            _gameTitle.alignment = panelSettings._gameTitleAlignment;
            _gameTitle.fontSize = panelSettings._gameTitleFontHeight;
            _gameTitle.color = panelSettings._gameTitleColor;
            _gameTitle.text = panelSettings._gameTitleText;
            _gameObjectList.Add(gameTitleObj);

            //BUTTON
            var buttonObj = new GameObject();
            buttonObj.transform.SetParent(panelEnterObj.transform);
            buttonObj.transform.localPosition = panelSettings._enterButtonImageCoordsDeviation;

            _button = buttonObj.AddComponent<Button>();
            _button.onClick.AddListener(onEnterButtonClick);
            _buttonImage = buttonObj.AddComponent<Image>();
            _buttonImage.sprite = Sprite.Create(panelSettings._enterButtonImage, new Rect(0f, 0f, panelSettings._enterButtonImageSize.x, panelSettings._enterButtonImageSize.y), panelSettings._enterButtonImagePivot);
            _buttonImage.rectTransform.sizeDelta = panelSettings._enterButtonImageSize;
            _gameObjectList.Add(buttonObj);

            //BUTTNON TEXT
            var buttonTitleObj = new GameObject();
            buttonTitleObj.transform.SetParent(buttonObj.transform);
            buttonTitleObj.transform.localPosition = Vector2.zero;
            _buttonTitle = buttonTitleObj.AddComponent<TextMeshProUGUI>();

            _buttonTitle.rectTransform.pivot = panelSettings._enterButtonImagePivot;
            _buttonTitle.alignment = panelSettings._enterButtonLabelAlignment;
            _buttonTitle.fontSize = panelSettings._enterButtonLabelFontHeight;
            _buttonTitle.color = panelSettings._enterButtonLabelColor;
            _buttonTitle.text = panelSettings._enterButtonLabelText;
            _gameObjectList.Add(buttonTitleObj);

            CreatePanelLocker(panelEnterObj, panelSettings._enterPanelImagePivot, panelSettings._enterPanelImageSize, new Color(250, 250, 250, 0.5f));
        }


        public void CreatePanelLocker(GameObject parentPanel, Vector2 pivot, Vector2 size, Color lockColor)
        {
            _panelLocker = new GameObject();
            _panelLocker.transform.SetParent(parentPanel.transform);
            _panelLocker.transform.localPosition = Vector2.zero;
            Image img = _panelLocker.AddComponent<Image>();
            img.rectTransform.pivot = pivot;
            img.rectTransform.sizeDelta = size;
            img.color = lockColor;  
            _panelLocker.SetActive(false);
        }

        public void DestroyPanel()
        {
            foreach (GameObject gameObject in _gameObjectList)
            {
                GameObject.Destroy(gameObject);
            }
            _gameObjectList = null;
            GameObject.Destroy(_panelLocker);
        }

        public void LockPanel()
        {
            if (_panelLocker != null)
                _panelLocker.SetActive(true);
        }

        public void UnlockPanel()
        {
            if (_panelLocker != null)
                _panelLocker.SetActive(false);
        }


        public void onEnterButtonClick()
        {
            _controller.EnterButtonClickCommunication();
        }
    } 
}

