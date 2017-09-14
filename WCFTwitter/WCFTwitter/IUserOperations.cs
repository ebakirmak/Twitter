using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserOperations" in both code and config file together.
    [ServiceContract]
    public interface IUserOperations
    {
        
        [OperationContract]
        int Login(string Email, string Password);

        [OperationContract]
        bool PasswordChange(int ID,string CurrentPassword, string NewPassoword);

        [OperationContract]
        bool PasswordChangeMailSend(string Email);

        [OperationContract]
        bool SignUp(string Name, string Surname, string Email, string Password);

        [OperationContract]
        bool UsernameCreate(int userID, string Username);

        [OperationContract]
        List<GetUsers_Result> GetUsers();



    }
}
