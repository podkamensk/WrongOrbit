using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class CatalogManager
    {
        private readonly Dictionary<string, CatalogItem> _catalog;

        public CatalogManager()
        {
            _catalog = new Dictionary<string, CatalogItem>();
        }

        public void LoadCatalog()
        {
            PlayFabClientAPI.GetCatalogItems(new GetCatalogItemsRequest(), OnGetCatalogSuccess, OnFailure);
            Debug.Log("Loading the catalog");
        }
        
        private void OnGetCatalogSuccess(GetCatalogItemsResult result)
        {
            HandleCatalog(result.Catalog);
            Debug.Log($"Catalog was loaded successfully with {result.Catalog.Count} items!");
        }

        private void OnFailure(PlayFabError error)
        {
            var errorMessage = error.GenerateErrorReport();
            Debug.LogError($"Something went wrong: {errorMessage}");
        }

        private void HandleCatalog(List<CatalogItem> catalog)
        {
            foreach (var item in catalog)
            {
                _catalog.Add(item.ItemId, item);
                Debug.Log($"Catalog item {item.ItemId} was added successfully!");
            }
        }
    }
}