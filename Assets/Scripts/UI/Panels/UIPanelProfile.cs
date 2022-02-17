using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UIPanelProfile : IUIPanel
    {
        private UIPanelProfileController _controller;

        public UIPanelProfile()
        {
        }

        public IUIPanelController Controller { get => _controller; set => _controller = (UIPanelProfileController)value; }


        public void DestroyPanelCommand()
        {
            _controller.DestroyPanelComms();
        }

        public void LockPanelCommand()
        {
            _controller.LockPanelComms();
        }

        public void UnlockPanelCommand()
        {
            _controller.UnlockPanelComms();
        }

        public void OnShopButtonClick()
        {
            Debug.Log("Shop Browse requested");
        }
        public void OnSingleButtonClick()
        {
            Debug.Log("Singlepayer requested");
        }
        public void OnOnlineButtonClick()
        {
            Debug.Log("Online Game requested");
        }
        public void OnChangeNameButtonClick()
        {
            Debug.Log("ChangeName Requested");
        }
        public void OnDeleteProfileButtonClick()
        {
            Debug.Log("Delete Profile Requested");
        }
    }
}

