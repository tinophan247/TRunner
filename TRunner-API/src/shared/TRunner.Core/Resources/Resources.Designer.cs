﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TRunner.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TRunner.Core.Resources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connect successful.
        /// </summary>
        public static string HealthCheck_Success {
            get {
                return ResourceManager.GetString("HealthCheck_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sport name has already existed!.
        /// </summary>
        public static string Sports_Create_CheckNameUnique {
            get {
                return ResourceManager.GetString("Sports_Create_CheckNameUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create new sport.
        /// </summary>
        public static string Sports_Create_Failed {
            get {
                return ResourceManager.GetString("Sports_Create_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not found any Sport Types!.
        /// </summary>
        public static string SportTypes_GetAll_NotFound {
            get {
                return ResourceManager.GetString("SportTypes_GetAll_NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success.
        /// </summary>
        public static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unauthorized.
        /// </summary>
        public static string Unauthorized {
            get {
                return ResourceManager.GetString("Unauthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User id should larger 0.
        /// </summary>
        public static string User_GetById {
            get {
                return ResourceManager.GetString("User_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong username or password, try again!.
        /// </summary>
        public static string User_Login_Wrong_Username_Password {
            get {
                return ResourceManager.GetString("User_Login_Wrong_Username_Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not found user.
        /// </summary>
        public static string User_Notfound {
            get {
                return ResourceManager.GetString("User_Notfound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Refresh token is invalid.
        /// </summary>
        public static string User_RefreshToken_Invalid {
            get {
                return ResourceManager.GetString("User_RefreshToken_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create user.
        /// </summary>
        public static string User_Register_Create_User_Failed {
            get {
                return ResourceManager.GetString("User_Register_Create_User_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User is already existed.
        /// </summary>
        public static string User_Register_Duplicate {
            get {
                return ResourceManager.GetString("User_Register_Duplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not found user role.
        /// </summary>
        public static string User_Register_UserRole_NotFound {
            get {
                return ResourceManager.GetString("User_Register_UserRole_NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to remove old refresh tokens.
        /// </summary>
        public static string User_Remove_RefreshToken_Failed {
            get {
                return ResourceManager.GetString("User_Remove_RefreshToken_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token revoked.
        /// </summary>
        public static string User_RevokeToken_Success {
            get {
                return ResourceManager.GetString("User_RevokeToken_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Token is required.
        /// </summary>
        public static string User_RevokeToken_Token_Required {
            get {
                return ResourceManager.GetString("User_RevokeToken_Token_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to update user.
        /// </summary>
        public static string User_Update_Failed {
            get {
                return ResourceManager.GetString("User_Update_Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create workout summary.
        /// </summary>
        public static string Workout_Summary_Create_Failed {
            get {
                return ResourceManager.GetString("Workout_Summary_Create_Failed", resourceCulture);
            }
        }
    }
}
