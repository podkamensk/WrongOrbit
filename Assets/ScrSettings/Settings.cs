using UnityEngine;
using System.IO;

namespace WrongOrbit
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Settings/AllSettings")]
    internal sealed class Settings : ScriptableObject
    //The class proveds acces to the settings (e.g. Camera Settings)
    {
        [SerializeField] private string _networkSettingsPath;
        [SerializeField] private string _gameBuildSettingsPath;
        [SerializeField] private string _uiSettingsPath;
        [SerializeField] private string _servicesSettingsPath;
        //[SerializeField] private string _cameraSettingsPath;

        private NetworkSettings _networkSettings;
        private GameBuildSettings _gameBuildSettings;
        private UISettings _uiSettings;
        private ServicesSettings _servicesSettings;
        //private CameraSettings _cameraSet;

        public NetworkSettings NetworkSet
        {
            get
            {
                if (_networkSettings == null)
                {
                    _networkSettings = Load<NetworkSettings>("Settings/" + _networkSettingsPath);
                }

                return _networkSettings;
            }
        }

        public GameBuildSettings GameBuildSet
        {
            get
            {
                if (_gameBuildSettings == null)
                {
                    _gameBuildSettings = Load<GameBuildSettings>("Settings/" + _gameBuildSettingsPath);
                }

                return _gameBuildSettings;
            }
        }
        public UISettings UISet
        {
            get
            {
                if (_uiSettings == null)
                {
                    _uiSettings = Load<UISettings>("Settings/" + _uiSettingsPath);
                }

                return _uiSettings;
            }
        }
        public ServicesSettings ServicesSet
        {
            get
            {
                if (_servicesSettings == null)
                {
                    _servicesSettings = Load<ServicesSettings>("Settings/" + _servicesSettingsPath);
                }

                return _servicesSettings;
            }
        }
        /*
        public CameraSettings CameraSet
        {
            get
            {
                //if (_playerDat == null)
                //{
                _cameraSet = Load<CameraSettings>("Settings/" + _cameraSettingsPath);
                //}

                return _cameraSet;
            }
        }*/

        //Clearly I don't understand this syntax
        private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}