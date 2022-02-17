using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System;

namespace WrongOrbit
{

    internal sealed class PlayFabLogin
    {
        private string _prefsKey;
        private string _titleID;

        public PlayFabLogin(string prefsKey, string titleID)
        {
            _prefsKey = prefsKey;
            _titleID = titleID;

            LogIn();
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
            PlayFabLoginEventArgs args = new PlayFabLoginEventArgs();
            args.PlayFabID = result.PlayFabId;
            args.FirstTimeLogin = result.NewlyCreated;
            args.LastLogIn = result.LastLoginTime;
            OnPlayFabLogin(args);
        }

        private void OnLoginFailure(PlayFabError error)
        {

            Debug.LogError($"Fail: {error}");
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
                PlayFabSettings.staticSettings.TitleId = _titleID;
                Debug.Log("Title ID was installed");
            }

            LogIn();

        }
        public void OnPlayFabLogin(PlayFabLoginEventArgs e)
        {
            EventHandler<PlayFabLoginEventArgs> handler = PlayFabLoginSuccess;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PlayFabLoginEventArgs> PlayFabLoginSuccess;
    }
}