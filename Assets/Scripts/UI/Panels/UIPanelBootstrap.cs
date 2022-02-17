using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UIPanelBootstrap : IUIPanel
    {
        private UIPanelBootstrapController _controller;

        public UIPanelBootstrap()
        {
        }

        public IUIPanelController Controller { get => _controller; set => _controller = (UIPanelBootstrapController)value; }

        public void OnEnterButtonClick()
        {
            Debug.Log("Enter Button Clicked");
        }

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
    }
}

