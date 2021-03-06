﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCTwitter.ServiceUserToUser {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUserToUser.IUserToUserOperations")]
    public interface IUserToUserOperations {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserToUserOperations/Follow", ReplyAction="http://tempuri.org/IUserToUserOperations/FollowResponse")]
        bool Follow(int FollowingID, int FollowerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserToUserOperations/Follow", ReplyAction="http://tempuri.org/IUserToUserOperations/FollowResponse")]
        System.Threading.Tasks.Task<bool> FollowAsync(int FollowingID, int FollowerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserToUserOperations/Unfollow", ReplyAction="http://tempuri.org/IUserToUserOperations/UnfollowResponse")]
        bool Unfollow(int FollowingID, int FollowerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserToUserOperations/Unfollow", ReplyAction="http://tempuri.org/IUserToUserOperations/UnfollowResponse")]
        System.Threading.Tasks.Task<bool> UnfollowAsync(int FollowingID, int FollowerID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserToUserOperationsChannel : MVCTwitter.ServiceUserToUser.IUserToUserOperations, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserToUserOperationsClient : System.ServiceModel.ClientBase<MVCTwitter.ServiceUserToUser.IUserToUserOperations>, MVCTwitter.ServiceUserToUser.IUserToUserOperations {
        
        public UserToUserOperationsClient() {
        }
        
        public UserToUserOperationsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserToUserOperationsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserToUserOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserToUserOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Follow(int FollowingID, int FollowerID) {
            return base.Channel.Follow(FollowingID, FollowerID);
        }
        
        public System.Threading.Tasks.Task<bool> FollowAsync(int FollowingID, int FollowerID) {
            return base.Channel.FollowAsync(FollowingID, FollowerID);
        }
        
        public bool Unfollow(int FollowingID, int FollowerID) {
            return base.Channel.Unfollow(FollowingID, FollowerID);
        }
        
        public System.Threading.Tasks.Task<bool> UnfollowAsync(int FollowingID, int FollowerID) {
            return base.Channel.UnfollowAsync(FollowingID, FollowerID);
        }
    }
}
