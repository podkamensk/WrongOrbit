using PlayFab.ClientModels;

namespace WrongOrbit
{
    internal sealed class GameItem
    {
        private CatalogItem _catalogItem;
        public CatalogItem CatalogItem { get => _catalogItem; set => _catalogItem = value; }
    }
}
