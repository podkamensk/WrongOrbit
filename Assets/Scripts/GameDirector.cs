using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class GameDirector
    {
        private TheUser _user;
        private GameCatalog _gameCatalog;
        private UIManager _managerUI;
        private NetworkManager _networkManager;
        private CoroutineRunner _coroutineRunner;
        private SceneClicker _sceneClicker;


        public GameDirector(TheUser user, GameCatalog gameCatalog, UIManager managerUI, NetworkManager networkManager, CoroutineRunner coroutineRunner)
        {
            _user = user;
            _gameCatalog = gameCatalog;
            _managerUI = managerUI;
            _networkManager = networkManager;
            _coroutineRunner = coroutineRunner;
            _sceneClicker = new SceneClicker(coroutineRunner);
            OpenTitleScreen();
        }

        public void OpenTitleScreen()
        {
            //_managerUI.InitiatePanel(PanelType.Bootstrap);
            _managerUI.InitiatePanel(PanelType.Profile);
        }
    }
}

