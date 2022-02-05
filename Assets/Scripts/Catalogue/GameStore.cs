using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class GameStore
    {
        private List<GameItem> _storeItems;
        public List<GameItem> StoreItems {get => _storeItems; }

        public void AddToGameStore(GameItem gameItem)
        {
            _storeItems.Add(gameItem);
            Debug.Log($"Item {gameItem.CatalogItem.DisplayName} was added to the Game Store");
        }

    }


}

