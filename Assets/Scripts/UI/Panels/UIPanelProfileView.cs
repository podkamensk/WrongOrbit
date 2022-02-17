using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WrongOrbit
{
    internal sealed class UIPanelProfileView : IUIPanelView
    {
        private UIPanelProfileController _controller;
        private List<GameObject> _gameObjectList;
        private GameObject _panelLocker;

        private Image _image;
        private Image _panelMain;
        private Image _panelIventory;
        private Image _panelCurrency;


        public IUIPanelController Controller { set => _controller = (UIPanelProfileController)value; }

        public UIPanelProfileView(ProfilePanelSettings panelSettings)
        {
            _gameObjectList = new List<GameObject>();

            //FIND CANVAS
            var canvas = GameObject.Find("Canvas");
            float scrWidth = canvas.GetComponent<RectTransform>().rect.width;
            float scrHeight = canvas.GetComponent<RectTransform>().rect.height;
            float aspectRatio = scrWidth / scrHeight;

            //IMAGE

            float sourceAspect = panelSettings._bgImage.width / panelSettings._bgImage.height;

            Sprite sprite;
            float offset;
            if (sourceAspect >= aspectRatio)
            {
                offset = (panelSettings._bgImage.width - panelSettings._bgImage.height * aspectRatio) / 2;
                sprite = Sprite.Create(panelSettings._bgImage, new Rect(offset, 0, panelSettings._bgImage.height * aspectRatio, panelSettings._bgImage.height), panelSettings._bgImagePivot);
            }
            else
            {
                offset = (panelSettings._bgImage.height - panelSettings._bgImage.width / aspectRatio) / 2;
                sprite = Sprite.Create(panelSettings._bgImage, new Rect(0, offset, panelSettings._bgImage.width, panelSettings._bgImage.width / aspectRatio), panelSettings._bgImagePivot);
            }


            var imageObj = new GameObject();
            _image = imageObj.AddComponent<Image>();
            _image.sprite = sprite;
            imageObj.transform.SetParent(canvas.transform);
            imageObj.transform.localPosition = Vector2.zero;
            _image.rectTransform.pivot = panelSettings._bgImagePivot;
            _image.rectTransform.sizeDelta = new Vector2(scrWidth, scrHeight);
            _gameObjectList.Add(imageObj);

            // MAIN PANEL 
            var panelMainObj = new GameObject();
            _panelMain = panelMainObj.AddComponent<Image>();
            panelMainObj.transform.SetParent(imageObj.transform);
            panelMainObj.transform.localPosition = panelSettings._mainPanelImageCoordsDeviation;
            _panelMain.rectTransform.pivot = panelSettings._mainPanelImagePivot;
            _panelMain.rectTransform.sizeDelta = new Vector2(panelSettings._mainPanelImageSizeCoeff.x * scrWidth, panelSettings._mainPanelImageSizeCoeff.y * scrHeight);
            _panelMain.color = panelSettings._mainPanelColor;
            _gameObjectList.Add(panelMainObj);

            //INVENTORY PANEL
            var panelInventoryObj = new GameObject();
            _panelIventory = panelInventoryObj.AddComponent<Image>();
            panelInventoryObj.transform.SetParent(panelMainObj.transform);
            panelInventoryObj.transform.localPosition = panelSettings._inventoryPanelImageCoordsDeviation;
            _panelIventory.rectTransform.pivot = panelSettings._inventoryPanelImagePivot;
            _panelIventory.rectTransform.sizeDelta = new Vector2(panelSettings._inventoryPanelImageSizeCoeff.x * _panelIventory.rectTransform.sizeDelta.x, panelSettings._inventoryPanelImageSizeCoeff.y * _panelIventory.rectTransform.sizeDelta.y);
            _panelIventory.color = panelSettings._inventoryPanelColor;
            _gameObjectList.Add(panelInventoryObj);

            //CURRENCY PANEL
            var panelCurrencyObj = new GameObject();
            _panelCurrency = panelCurrencyObj.AddComponent<Image>();
            panelCurrencyObj.transform.SetParent(panelMainObj.transform);
            panelCurrencyObj.transform.localPosition = panelSettings._currencyPanelImageCoordsDeviation;
            _panelCurrency.rectTransform.pivot = panelSettings._currencyPanelImagePivot;
            _panelCurrency.rectTransform.sizeDelta = new Vector2(panelSettings._currencyPanelImageSizeCoeff.x * _panelIventory.rectTransform.sizeDelta.x, panelSettings._currencyPanelImageSizeCoeff.y * _panelIventory.rectTransform.sizeDelta.y);
            _panelCurrency.color = panelSettings._currencyPanelColor;
            _gameObjectList.Add(panelCurrencyObj);


            CreatePanelLocker(panelMainObj, panelSettings._mainPanelImagePivot, _panelMain.rectTransform.sizeDelta, new Color(250, 250, 250, 0.5f));
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

        public void OnShopButtonClick()
        {
            _controller.ShopButtonClickFeedback();
        }
        public void OnSingleButtonClick()
        {
            _controller.SingleButtonClickFeedback();
        }
        public void OnOnlineButtonClick()
        {
            _controller.OnlineButtonClickFeedback();
        }
        public void OnChangeNameButtonClick()
        {
            _controller.ChangeNameButtonClickFeedback();
        }
        public void OnDeleteProfileButtonClick()
        {
            _controller.DeleteProfileButtonClickFeedback();
        }
    }
}

