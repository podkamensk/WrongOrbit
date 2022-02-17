using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UIManager
    {
        private List<IUIPanel> _activeUIPanels;
        private UIFactory _uiFactory;
        public UIManager(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _activeUIPanels = new List<IUIPanel>();
        }

        public void InitiatePanel(PanelType panelType)
        {
            _activeUIPanels.Add(_uiFactory.CreatePanel(panelType));
        }

    }
}

