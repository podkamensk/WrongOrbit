using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class ProfileManager
    {

        public ProfileManager()
        {
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccountSuccess, OnFailure);
        }

        private void OnGetAccountSuccess(GetAccountInfoResult result)
        {
            PlayFabGetAccountSuccessEventArgs args = new PlayFabGetAccountSuccessEventArgs();
            args.UserName = result.AccountInfo.Username;
            args.CreationDate = result.AccountInfo.Created;
            OnPlayFabGetAccountInfoSuccess(args);
        }
        private void OnFailure(PlayFabError error)
        {
            Debug.Log($"PlayFab: Profile Manager: Error getting account data: {error.GenerateErrorReport()}");
        }

        public void OnPlayFabGetAccountInfoSuccess(PlayFabGetAccountSuccessEventArgs e)
        {
            EventHandler<PlayFabGetAccountSuccessEventArgs> handler = PlayFabGetAccountSuccess;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PlayFabGetAccountSuccessEventArgs> PlayFabGetAccountSuccess;

    }
}

