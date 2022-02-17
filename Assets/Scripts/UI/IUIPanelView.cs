

using UnityEngine;

namespace WrongOrbit
{
    internal interface IUIPanelView
    {
        public IUIPanelController Controller { set; }
        public void LockPanel();
        public void UnlockPanel();
        public void DestroyPanel();

        public void CreatePanelLocker(GameObject parentPanel, Vector2 pivot, Vector2 size, Color lockColor);
    }
}

