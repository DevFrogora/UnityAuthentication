using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using UnityEngine;

public class AuthManager :  IAuth
{

    public void RegisterAuthenticationEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            Debug.Log("Sign in anonymously succeeded!");
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
            //StatusTxt.text = "AccessToken : " + AuthenticationService.Instance.AccessToken;

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };

        AuthenticationService.Instance.Expired += () =>
        {
            Debug.Log("Player session could not be refreshed and expired.");
        };
    }


    public void GoogleSignIn()
    {
        Debug.Log("Currently we don't have any Google Sign In implementaion");
    }

    public void GuestSignIn()
    {
        new AnonymousSignIn().SignInAnonymouslyAsync();
    }
}
