using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MainLoginScreenUI : MonoBehaviour
{
    UIDocument loginScreenUIDocument;
    VisualElement googleSignInButton;
    Button anonymousSignInButton;

    IAuth authManager;
    ServiceInitialization serviceInitialization;
    // Start is called before the first frame update
    private async void OnEnable()
    {
        authManager = new AuthManager();
        serviceInitialization = new ServiceInitialization();
        loginScreenUIDocument = GetComponent<UIDocument>();

        if (loginScreenUIDocument != null )
        {
            googleSignInButton = loginScreenUIDocument.rootVisualElement.Q<VisualElement>("GoogleSignInBtn");
            anonymousSignInButton = loginScreenUIDocument.rootVisualElement.Q<Button>("AnonymousSignInBtn");

            if( googleSignInButton != null ) googleSignInButton.RegisterCallback<ClickEvent>(OnGoogleSignInBtnClicked);
            if (anonymousSignInButton != null)  anonymousSignInButton.RegisterCallback<ClickEvent>(OnAnonymousSignInBtnClicked);

        }
        await serviceInitialization.UnityServiceInitialization();
        if(serviceInitialization.isUnityServiceInitialized) authManager.RegisterAuthenticationEvents();
    }

    private void OnAnonymousSignInBtnClicked(ClickEvent evt)
    {
        Debug.Log(evt.currentTarget);
        authManager.GuestSignIn();
    }

    private void OnGoogleSignInBtnClicked(ClickEvent evt)
    {
        authManager.GoogleSignIn();
    }

}
