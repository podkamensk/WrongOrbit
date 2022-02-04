using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{

    [SerializeField] private Button _buttonErase;
    [SerializeField] private TMP_Text _greetText;
    [SerializeField] private TMP_Text _createdText;

    // Start is called before the first frame update
    void Start()
    {
        _buttonErase.onClick.AddListener(TaskOnClickErase);
        _greetText.text = "";
        _createdText.text = "";
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), OnGetAccountSuccess, OnFailure);
    }

    private void OnGetAccountSuccess(GetAccountInfoResult result)
    {
        UserAccountInfo user = result.AccountInfo;
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
