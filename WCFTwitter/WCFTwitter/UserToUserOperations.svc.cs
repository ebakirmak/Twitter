using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserToUserOperations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserToUserOperations.svc or UserToUserOperations.svc.cs at the Solution Explorer and start debugging.
    public class UserToUserOperations : IUserToUserOperations
    {
        TwitterEntities userToUserEdmx = new TwitterEntities();
        //Follower=Takipçi,Following=TakipEdilen
        //Takip Etmek
        public bool Follow(int FollowingID, int FollowerID)
        {
            UserToUsers takipEt = new UserToUsers();            
            try
            {
                takipEt.FollowerUser = FollowerID;
                takipEt.FollowingUser = FollowingID;
                userToUserEdmx.UserToUsers.Add(takipEt);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                userToUserEdmx.SaveChanges();
            }
            return true;
        }

        public bool Unfollow(int FollowerID,int FollowingID )
        {
            WCFTwitter.UserToUsers takipEt = new WCFTwitter.UserToUsers();
            try
            {
                takipEt = userToUserEdmx.UserToUsers.Where(x => x.FollowerUser == FollowerID && x.FollowingUser == FollowingID).FirstOrDefault();
                userToUserEdmx.UserToUsers.Remove(takipEt);

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                userToUserEdmx.SaveChanges();
            }
            return true;
        }


    }
}
