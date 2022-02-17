
namespace WrongOrbit
{
    internal sealed class UIPanelBootstrapController : IUIPanelController
    {
        private UIPanelBootstrap _model;
        private UIPanelBootstrapView _view;

        public IUIPanelView View { get => _view; set => _view = (UIPanelBootstrapView)value; }

        public UIPanelBootstrapController(UIPanelBootstrap model, UIPanelBootstrapView view)
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

        public void EnterButtonClickCommunication()
        {
            _model.OnEnterButtonClick();
        }
    }
}

