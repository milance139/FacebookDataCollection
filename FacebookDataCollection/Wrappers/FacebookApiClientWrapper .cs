using FacebookDataCollection.Interfaces;
using FacebookDataCollection.Models.FacebookModels;
using System;
using FacebookDataCollection.FacebookApiClient;

namespace DataCollectionTask.Wrappers
{
    public class FacebookApiClientWrapper : IFacebookApiClient
    {
        private readonly FacebookApiClient _facebookApiClient;

        public FacebookApiClientWrapper(string appID, string appSecret)
        {
            _facebookApiClient = new FacebookApiClient(appID, appSecret);
        }

        public string GetLoginUrl(Uri redirectUri)
        {
            return _facebookApiClient.GetLoginUrl(redirectUri);
        }

        public string GetAccessToken(string code, Uri redirectUri)
        {
            return _facebookApiClient.GetAccessToken(code, redirectUri);
        }

        public FacebookData GetFacebookData(string accessToken)
        {
            return _facebookApiClient.GetFacebookData(accessToken);
        }
    }
}