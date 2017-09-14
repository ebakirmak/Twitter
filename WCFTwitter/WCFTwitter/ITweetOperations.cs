using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITweetOperations" in both code and config file together.
    [ServiceContract]
    public interface ITweetOperations
    {
        [OperationContract]
        bool TweetDelete(int UserID, int TweetID);

        [OperationContract]
        bool TweetSend(int UserID, string tweet);

        /*Düzeltme olabilir*/
        [OperationContract]
        List<GetTweets_Result1> TweetView(int ID);
    }
}
