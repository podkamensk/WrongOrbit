using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UIPanelProfileController : IUIPanelController
    {
        private UIPanelProfile _model;
        private UIPanelProfileView _view;
        public IUIPanelView View { get => _view; set => _view = (UIPanelProfileView)value; }

        public UIPanelProfileController(UIPanelProfile model, UIPanelProfileView view)
        {
            _model = model;
            _view = view;
        }

        public IUIPanel GetModel()
        {
            return _model;
        }

        public void LockPanelComms()
        {
            _view.LockPanel();
        }

        public void UnlockPanelComms()
        {
            _view.UnlockPanel();
        }

        public void DestroyPanelComms()
        {
            _view.DestroyPanel();
        }

        public void ChangeNameButtonClickFeedback()
        {
            _model.OnChangeNameButtonClick();
        }
        public void ShopButtonClickFeedback()
        {
            _model.OnShopButtonClick();
        }
        public void SingleButtonClickFeedback()
        {
            _model.OnSingleButtonClick();
        }
        public void OnlineButtonClickFeedback()
        {
            _model.OnOnlineButtonClick();
        }

        public void DeleteProfileButtonClickFeedback()
        {
            _model.OnDeleteProfileButtonClick();
        }
    }
}

