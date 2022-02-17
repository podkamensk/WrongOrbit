
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class GameInitialize
    {

        public GameInitialize(Controllers controllers, Settings allSettings)
        {
            var coroutineRunner = GameObject.Instantiate(allSettings.ServicesSet._coroutineRunnerDummy).AddComponent<CoroutineRunner>();
            var UIFactory = new UIFactory(allSettings.UISet);

            var UIManager = new UIManager(UIFactory);
            var gameCatalog = new GameCatalog();
            var user = new TheUser();
            var networkManager = new NetworkManager(user, gameCatalog, allSettings.GameBuildSet, allSettings.NetworkSet);
            var gameDirector = new GameDirector(user, gameCatalog, UIManager, networkManager, coroutineRunner);


            //Adding IContoller controllers to the respective lists of Controllers Class
            //controllers.Add(playerInit.GetPlayer());
            Debug.Log("Game initialized");
        }
       

    }
}

