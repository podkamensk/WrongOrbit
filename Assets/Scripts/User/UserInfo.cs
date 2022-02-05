using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class UserInfo
    {
        private string _userName;
        private DateTime _creationDate;

        public void UpdateUserInfo(string userName, DateTime created)
        {
            _userName = userName;
            _creationDate = created;
            Debug.Log($"The USER: User Info Received: name {_userName}, created {_creationDate}");
        }
    }
}

