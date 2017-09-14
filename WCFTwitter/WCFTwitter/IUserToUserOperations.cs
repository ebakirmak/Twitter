﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserToUserOperations" in both code and config file together.
    [ServiceContract]
    public interface IUserToUserOperations
    {
        [OperationContract]
        bool Follow(int FollowingID, int FollowerID);

        [OperationContract]
        bool Unfollow(int FollowingID, int FollowerID);
    }
}