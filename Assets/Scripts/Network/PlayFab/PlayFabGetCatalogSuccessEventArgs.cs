using PlayFab.ClientModels;
using System;
using System.Collections.Generic;

namespace WrongOrbit
{
    public class PlayFabGetCatalogSuccessEventArgs : EventArgs
    {
        public List<CatalogItem> CatalogItemsList { get; set; }
    }
}
