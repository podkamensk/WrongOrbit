using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace WrongOrbit
{
    
    public class PlayFabLogin : MonoBehaviour
    {
        [SerializeField] public Button _button;
        [SerializeField] private TMP_Text _buttonText;

        private string _prefsKey;

        private void Awake()
        {
            _prefsKey = "unique-user-id";
            _button.onClick.AddListener(TaskOnClick);

            _buttonText.text = "ENTER";

        }

        public void LogIn()
        {
            bool savedIDExists = PlayerPrefs.HasKey(_prefsKey);
            var id = PlayerPrefs.GetString(_prefsKey, Guid.NewGuid().ToString());

            var request = new LoginWithCustomIDRequest { CustomId = id, CreateAccount = !savedIDExists };
            PlayFabClientAPI.LoginWithCustomID(request, result =>
            {
                OnLoginSuccess(result);
                CreateAccount(savedIDExists, id);
            },
            OnLoginFailure);

        }

        private void OnLoginSuccess(LoginResult result)
        {
            SceneManager.LoadScene("ProfileScene");
            Debug.Log("PlayFab Login Success");
        }

        private void OnLoginFailure(PlayFabError error)
        {

            Debug.LogError($"Fail: {error}");
            _buttonText.text = "TRY AGAIN";
        }

        public void CreateAccount(bool exists, string id)
        {
            if (!exists)
            {
                PlayerPrefs.SetString(_prefsKey, id);
                Debug.Log($"Created new account: {id}");
            }
            else
                Debug.Log($"Proceed with existing account: {id}");
        }

        public void TaskOnClick()
        {
            

            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = "D2004";
                Debug.Log("Title ID was installed");
            }

            LogIn();

        }
    }
}