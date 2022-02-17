namespace WrongOrbit
{
    internal interface IUIPanel
    {
        public IUIPanelController Controller { get; set; }

        public void LockPanelCommand();
        public void UnlockPanelCommand();
        public void DestroyPanelCommand();
    }

}

