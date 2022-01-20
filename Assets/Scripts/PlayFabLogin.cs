using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace WrongOrbit
{
    public class PlayFabLogin : MonoBehaviour
    {
        private void Start()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            {
                PlayFabSettings.staticSettings.TitleId = "D2004";
                Debug.Log("Title ID was installed");
            }

            var request = new LoginWithCustomIDRequest { CustomId = "RomanTestCustomID", CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("PlayFab Login Success");
        }

        private void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError($"Fail: {error}");
        }
    }
}