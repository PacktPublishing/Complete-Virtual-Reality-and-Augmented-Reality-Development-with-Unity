using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform;

public class OculusEntitlementCheck : MonoBehaviour
{

    void Awake()
    {
        try
        {
            Core.AsyncInitialize();
            Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCallback);
        }
        catch (UnityException e)
        {
            Debug.LogError("Oculus Platform failed to initialize due to exception.");
            Debug.LogException(e);
            // Immediately quit the application
            UnityEngine.Application.Quit();
        }
    }

    void EntitlementCallback(Message msg)
    {
        if (msg.IsError)
        {
            Debug.LogError("Oculus entitlement check FAILED.");
            UnityEngine.Application.Quit();
        }
        else
        {
            Debug.Log("Oculus entitlement passed.");
        }
    }
}
