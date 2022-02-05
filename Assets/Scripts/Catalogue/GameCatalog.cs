using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class GameCatalog
    {
        private List<GameItem> _catalogItems;
        public List<GameItem> CatalogItems { get => _catalogItems; }

        public GameCatalog()
        {
            _catalogItems = new List<GameItem>();
        }

        public void AddToGameCatalog(GameItem gameItem)
        {
            _catalogItems.Add(gameItem);
            Debug.Log($"Item {gameItem.CatalogItem.DisplayName} was added to the Game Catalog");
        }
    }
}
