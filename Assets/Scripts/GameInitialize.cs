
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class GameInitialize
    {

        public GameInitialize(Controllers controllers, Settings allSettings)
        {
            var UIManager = new UIManager();
            var gameCatalog = new GameCatalog();
            var user = new TheUser();
            var networkManager = new NetworkManager(user, gameCatalog, allSettings.GameBuildSet, allSettings.NetworkSet);



            //Adding IContoller controllers to the respective lists of Controllers Class
            //controllers.Add(playerInit.GetPlayer());
            Debug.Log("Game initialized");
        }
       

    }
}

