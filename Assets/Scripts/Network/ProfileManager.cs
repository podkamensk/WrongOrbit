using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WrongOrbit
{
    public class ProfileManager : MonoBehaviour
    {

        [SerializeField] private Button _buttonErase;
        [SerializeField] private TMP_Text _greetText;
        [SerializeField] private TMP_Text _createdText;

        private CatalogManager _catalogManager;
        private InventoryManager _inventoryManager;

        // Start is called before the first frame update
        void Start()
        {
            _catalogManager = new CatalogManager();
            _inventoryManager = new InventoryManager();
            _buttonErase.onClick.AddListener(TaskOnClickErase);
            _greetText.text = "";
            _createdText.text = "";
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccountSuccess, OnFailure);
        }

        private void OnGetAccountSuccess(GetAccountInfoResult result)
        {
            UserAccountInfo user = result.AccountInfo;
            _inventoryManager.LoadUserInventory();
            _catalogManager.LoadCatalog();
            _greetText.text = $"Welcome, {user.PlayFabId} !";
            _createdText.text = $"Since: {user.Created}";
            Debug.Log($"Account data retrieved");
        }
        private void OnFailure(PlayFabError error)
        {
            Debug.Log($"Error getting account data: {error.GenerateErrorReport()}");
        }

        private void ErasePlayFabAccount()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("TitleScene");
        }

        private void TaskOnClickErase()
        {
            ErasePlayFabAccount();
        }
    }
}

