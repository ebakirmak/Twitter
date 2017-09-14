using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFavoritesOperations" in both code and config file together.
    [ServiceContract]
    public interface IFavoritesOperations
    {
        [OperationContract]
        bool FavoriteAdd(int TweetID, int UserID);

        [OperationContract]
        bool FavoriteDelete(int TweetID, int UserID);
    }
}
