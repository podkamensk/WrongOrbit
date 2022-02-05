using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class TheUser
    {
        private UserLoginData _userLoginData;
        private UserInfo _userInfo;
        private UserPossessions _userPossessions;



        public UserLoginData UserLoginData { get => _userLoginData; }
        public UserInfo UserInfo { get => _userInfo; }
        public UserPossessions UserPossessions { get => _userPossessions; }

        public TheUser()
        {
            _userLoginData = new UserLoginData();
            _userInfo = new UserInfo();
            _userPossessions = new UserPossessions();
        }

        public void UpdateUserLoginData(string userID, bool firstTimeLogin, DateTime? lastLogin)
        {
            _userLoginData.UpdateUserLoginData(userID, firstTimeLogin, lastLogin);
        }

        public void UpdateUserInfo(string userName, DateTime created)
        {
            _userInfo.UpdateUserInfo(userName, created);
        }

        public void CreateUserPossessions(Dictionary<string, int> inventory, Dictionary<string, int> wallet)
        {
            _userPossessions.CreateInventory(inventory);
            _userPossessions.CreateWallet(wallet);
        }
    }

}
