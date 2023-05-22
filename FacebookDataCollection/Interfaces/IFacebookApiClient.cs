using FacebookDataCollection.Models.FacebookModels;
using System;

namespace FacebookDataCollection.Interfaces
{
    public interface IFacebookApiClient
    {
        /// <summary>
        /// Gets the Facebook login URL for authentication and authorization.
        /// </summary>
        /// <param name="redirectUri">The redirect URI after a successful login.</param>
        /// <returns>The Facebook login URL.</returns>
        string GetLoginUrl(Uri redirectUri);

        /// <summary>
        /// Gets the Facebook access token using the authorization code.
        /// </summary>
        /// <param name="code">The authorization code received after a successful login.</param>
        /// <param name="redirectUri">The redirect URI after a successful login.</param>
        /// <returns>The Facebook access token.</returns>
        string GetAccessToken(string code, Uri redirectUri);

        /// <summary>
        /// Gets the Facebook user data using the access token.
        /// </summary>
        /// <param name="accessToken">The Facebook access token.</param>
        /// <returns>The Facebook user data.</returns>
        FacebookData GetFacebookData(string accessToken);
    }
}
