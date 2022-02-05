using System;
using UnityEngine;

public class UserLoginData
{
    private string _userID;
    private bool _firstTimeLogin;
    public DateTime? _lastLogin;

    public string PlayFabID { get => _userID; }
    public bool FirstTimeLogin { get => _firstTimeLogin; }
    public DateTime? LastLogIn { get => _lastLogin; }

    public void UpdateUserLoginData(string user, bool firstTime, DateTime? lastLogin)
    {
        _userID = user;
        _firstTimeLogin = firstTime;
        _lastLogin = lastLogin;

        Debug.Log("The USER: User Login Data Received");
    }
}
