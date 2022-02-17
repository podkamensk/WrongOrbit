using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UIFactory
    {
        private readonly UISettings _uiSettings;


        public UIFactory (UISettings uiSettings)
        {
            _uiSettings = uiSettings;
        }

        public IUIPanel CreatePanel(PanelType panelType)
        {
            IUIPanel panel;
            IUIPanelView view;
            switch (panelType)
            {
                case PanelType.Bootstrap:
                    panel = new UIPanelBootstrap();
                    view = new UIPanelBootstrapView(_uiSettings.BootstrapPanelSettings);
                    panel.Controller = new UIPanelBootstrapController((UIPanelBootstrap)panel, (UIPanelBootstrapView)view);
                    view.Controller = panel.Controller;
                    return panel;

                case PanelType.Profile:
                    panel = new UIPanelProfile();
                    view = new UIPanelProfileView(_uiSettings.ProfilePanelSettings);
                    panel.Controller = new UIPanelProfileController((UIPanelProfile)panel, (UIPanelProfileView)view);
                    view.Controller = panel.Controller;
                    return panel;

                case PanelType.Store:
                    panel = new UIPanelProfile();
                    return panel;
                case PanelType.Lobby:
                    panel = new UIPanelProfile();
                    return panel;
                case PanelType.UserInput:
                    panel = new UIPanelProfile();
                    return panel;
                default:
                    panel = new UIPanelProfile();
                    return panel;
            }

        }
        
    }
}


