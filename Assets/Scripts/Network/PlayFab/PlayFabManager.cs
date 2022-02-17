

namespace WrongOrbit
{
    internal sealed class PlayFabManager
    {
        private NetworkManager _networkManager;
        private NetworkSettings _networkSettings;
        

        public PlayFabManager(NetworkManager networkManager, NetworkSettings networkSeettings)
        {
            _networkManager = networkManager;
            _networkSettings = networkSeettings;
        }

        public void PlayFabLogin()
        {
            var playFabLogin = new PlayFabLogin(_networkSettings._prefsKey, _networkSettings._playfabTitleID);
            playFabLogin.PlayFabLoginSuccess += _networkManager.c_OnPlayFabLogin;
        }


        public void FetchPlayFabAccount()
        {
            var profileManager = new ProfileManager();
            profileManager.PlayFabGetAccountSuccess += _networkManager.c_OnPlayFabUserInfoFetch;
        }

        public void FetchPlayFabCatalog()
        {
            var catalogManager = new CatalogManager();
            catalogManager.PlayFabGetCatalogSuccess += _networkManager.c_OnPlayFabCatalogFetch;
        }

        public void FetchPlayFabInventory()
        {
            var inventoryManager = new InventoryManager();
            inventoryManager.PlayFabGetInventorySuccess += _networkManager.c_OnPlayFabInventoryFetch;
        }


    }
}

