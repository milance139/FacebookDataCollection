using System;
using System.Collections.Generic;
using Facebook;
using Newtonsoft.Json;
using FacebookDataCollection.Interfaces;
using FacebookDataCollection.Models;
using FacebookDataCollection.Models.FacebookModels;

namespace FacebookDataCollection.FacebookApiClient
{
    public class FacebookApiClient : IFacebookApiClient
    {
        private readonly string _appID;
        private readonly string _appSecret;
        private readonly FacebookClient _facebookClient;

        public FacebookApiClient(string appID, string appSecret)
        {
            _appID = appID;
            _appSecret = appSecret;
            _facebookClient = new FacebookClient();
        }

        public string GetLoginUrl(Uri redirectUri)
        {
            var loginUrl = _facebookClient.GetLoginUrl(new Dictionary<string, object>
            {
                { "client_id", _appID },
                { "redirect_uri", redirectUri.AbsoluteUri },
                { "response_type", "code" },
                { "scope", "email" }
            });
            return loginUrl.AbsoluteUri;
        }

        public string GetAccessToken(string code, Uri redirectUri)
        {
            dynamic result = _facebookClient.Post("oauth/access_token", new Dictionary<string, object>
            {
                { "client_id", _appID },
                { "client_secret", _appSecret },
                { "redirect_uri", redirectUri.AbsoluteUri },
                { "code", code }
            });

            return result.access_token;
        }

        public FacebookData GetFacebookData(string accessToken)
        {
            _facebookClient.AccessToken = accessToken;
            string dataJson = _facebookClient.Get("me?fields=first_name,last_name,email,birthday,hometown,posts").ToString();
            FacebookData facebookData = JsonConvert.DeserializeObject<FacebookData>(dataJson);
            return facebookData;
        }
    }
}
