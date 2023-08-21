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
    // Start is called before the first frame update
    private void OnEnable()
    {
        loginScreenUIDocument = GetComponent<UIDocument>();
        if (loginScreenUIDocument != null )
        {
            googleSignInButton = loginScreenUIDocument.rootVisualElement.Q<VisualElement>("GoogleSignInBtn");
            if( googleSignInButton != null )
            {
                googleSignInButton.RegisterCallback<ClickEvent>(OnGoogleSignInBtnClicked);
            }
            anonymousSignInButton = loginScreenUIDocument.rootVisualElement.Q<Button>("AnonymousSignInBtn");
            if (googleSignInButton != null)
            {
                anonymousSignInButton.RegisterCallback<ClickEvent>(OnAnonymousSignInBtnClicked);
            }
        }
    }

    private void OnAnonymousSignInBtnClicked(ClickEvent evt)
    {
        Debug.Log(evt.currentTarget);

    }

    private void OnGoogleSignInBtnClicked(ClickEvent evt)
    {
        Debug.Log(evt.currentTarget);
    }

    void Start()
    {
        
    }
}
