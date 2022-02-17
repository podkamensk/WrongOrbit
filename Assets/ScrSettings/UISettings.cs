using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "UISettings", menuName = "Settings/UISettings")]
    public sealed class UISettings : ScriptableObject

    {
        [SerializeField] private string _bootstrapPanelSettingsPath;
        [SerializeField] private string _profilePanelSettingsPath;
        [SerializeField] private string _lobbyPanelSettingsPath;
        [SerializeField] private string _shopPanelSettingsPath;
        [SerializeField] private string _userInputPanelSettingsPath;
        private BootstrapPanelSettings _bootstrapPanelSettings;
        private ProfilePanelSettings _profilePanelSettings;
        private LobbyPanelSettings _lobbyPanelSettings;
        private ShopPanelSettings _shopPanelSettings;
        private UserInputPanelSettings _userInputPanelSettings;


        public BootstrapPanelSettings BootstrapPanelSettings
        {
            get
            {
                if (_bootstrapPanelSettings == null)
                {
                    _bootstrapPanelSettings = Load<BootstrapPanelSettings>("Settings/" + _bootstrapPanelSettingsPath);
                }

                return _bootstrapPanelSettings;
            }
        }

        public ProfilePanelSettings ProfilePanelSettings
        {
            get
            {
                if (_profilePanelSettings == null)
                {
                    _profilePanelSettings = Load<ProfilePanelSettings>("Settings/" + _profilePanelSettingsPath);
                }

                return _profilePanelSettings;
            }
        }

        public LobbyPanelSettings LobbyPanelSettings
        {
            get
            {
                if (_lobbyPanelSettings == null)
                {
                    _lobbyPanelSettings = Load<LobbyPanelSettings>("Settings/" + _lobbyPanelSettingsPath);
                }

                return _lobbyPanelSettings;
            }
        }

        public ShopPanelSettings ShopPanelSettings
        {
            get
            {
                if (_shopPanelSettings == null)
                {
                    _shopPanelSettings = Load<ShopPanelSettings>("Settings/" + _shopPanelSettingsPath);
                }

                return _shopPanelSettings;
            }
        }

        public UserInputPanelSettings UserInputPanelSettings
        {
            get
            {
                if (_userInputPanelSettings == null)
                {
                    _userInputPanelSettings = Load<UserInputPanelSettings>("Settings/" + _userInputPanelSettingsPath);
                }

                return _userInputPanelSettings;
            }
        }


        //Clearly I don't understand this syntax
        private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }

}

