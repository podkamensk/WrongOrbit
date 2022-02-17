
namespace WrongOrbit
{
    internal interface IUIPanelController
    {
        public IUIPanelView View {get;set;}
        public IUIPanel GetModel();
        public void LockPanelComms();
        public void UnlockPanelComms();
        public void DestroyPanelComms();
    }
}

