using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class CatalogManager
    {

        public CatalogManager()
        {
            LoadCatalog();
        }

        public void LoadCatalog()
        {
            PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(), OnGetCatalogSuccess, OnFailure);
        }
        
        private void OnGetCatalogSuccess(GetCatalogItemsResult result)
        {

            PlayFabGetCatalogSuccessEventArgs args = new PlayFabGetCatalogSuccessEventArgs();
            args.CatalogItemsList = result.Catalog;
            OnPlayFabGetCatalogSuccess(args);
        }

        private void OnFailure(PlayFabError error)
        {
            var errorMessage = error.GenerateErrorReport();
            Debug.LogError($"PlayFab Catalog ManagerSomething went wrong: {errorMessage}");
        }


        public void OnPlayFabGetCatalogSuccess(PlayFabGetCatalogSuccessEventArgs e)
        {
            EventHandler<PlayFabGetCatalogSuccessEventArgs> handler = PlayFabGetCatalogSuccess;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PlayFabGetCatalogSuccessEventArgs> PlayFabGetCatalogSuccess;
    }
}