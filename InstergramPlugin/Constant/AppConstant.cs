using System;
namespace XamarinKit.Constant
{
    public static class AppConstant
    {
        public static string username = "abc";
        public static string Password = "abc";

      public enum InstaLoginResult
        {
            Success,
            BadPassword,
            ChallengeRequired,
            CheckpointLoggedOut,
            Exception,
            InactiveUser,
            InvalidUser,
            LimitError,
            TwoFactorRequired

        }
    }
}
