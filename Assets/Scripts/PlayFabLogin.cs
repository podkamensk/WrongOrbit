using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace WrongOrbit
{
    
    public class PlayFabLogin : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statusText;
        [SerializeField] public Button _button;
        [SerializeField] private TMP_Text _buttonText;
        

        private ColorBlock _colors;
        private Color _textColorDefault = Color.black;
        private Color _textColorConnected = Color.green;

        private void Awake()
        {
            _button.onClick.AddListener(TaskOnClick);

            _statusText.text = "Playfab: disconnected";
            _buttonText.text = "connect";

            _statusText.color = _textColorDefault;

        }

        private void OnLoginSuccess(LoginResult result)
        {
            _statusText.text = "Playfab: connected";
            _buttonText.text = "refresh";
            _statusText.color = _textColorConnected;
            Debug.Log("PlayFab Login Success");

        }

        private void OnLoginFailure(PlayFabError error)
        {
            _statusText.text = "Playfab: disconnected";
            _buttonText.text = "refresh";
            _statusText.color = _textColorDefault;
            Debug.LogError($"Fail: {error}");
        }

        public void TaskOnClick()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = "D2004";
                Debug.Log("Title ID was installed");
            }

            var request = new LoginWithCustomIDRequest { CustomId = "RomanTestCustomID", CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
            _statusText.text = "Playfab: connecting...";
            _buttonText.text = "wait";
            _statusText.color = _textColorDefault;
        }
    }
}