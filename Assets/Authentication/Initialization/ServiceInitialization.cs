using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;

public class ServiceInitialization 
{
    public bool isUnityServiceInitialized = false;
    public async Task UnityServiceInitialization()
    {
        try
        {
            await UnityServices.InitializeAsync();
            isUnityServiceInitialized = true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
